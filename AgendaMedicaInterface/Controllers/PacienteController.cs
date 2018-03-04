using AgendaMedicaDomain.Dto;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.UnitOfWork;
using AgendaMedicaRules.Regras;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaMedicaInterface.Controllers
{
    [RoutePrefix("paciente")]
    public class PacienteController : ApiController
    {
        private readonly UnitOfWorkAgenda _uow;

        public PacienteController()
        {
            _uow = new UnitOfWorkAgenda(new ContextoDb());
        }

        [HttpGet]
        [Route("GetAllPacientes")]
        public HttpResponseMessage GetAllPacientes()
        {
            var response = _uow.PacienteRepositorio.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("RegistroNovoPaciente")]
        public HttpResponseMessage RegistroNovoPaciente(PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var response = PacienteRegras.CreateInstance.Add(pacienteDto);
            _uow.PacienteRepositorio.Adicionar(response);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        [Route("AlterarPaciente")]
        public HttpResponseMessage AlterarPaciente(PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var paciente = PacienteRegras.CreateInstance.Edit(pacienteDto);
            _uow.PacienteRepositorio.Atualizar(paciente);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }

        [HttpDelete]
        [Route("RemoverPaciente/{idPaciente}")]
        public HttpResponseMessage RemoverPaciente(int idPaciente)
        {
            var pacienteId = PacienteRegras.CreateInstance.Delete(idPaciente);
            _uow.PacienteRepositorio.Excluir(paciente => paciente.IdPaciente == pacienteId);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
