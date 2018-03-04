using AgendaMedicaDomain.Dto;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.UnitOfWork;
using AgendaMedicaRules.Regras;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaMedicaInterface.Controllers
{
    [RoutePrefix("medico")]
    public class MedicoController : ApiController
    {
        private readonly UnitOfWorkAgenda _uow;

        public MedicoController()
        {
            _uow = new UnitOfWorkAgenda(new ContextoDb());
        }

        [HttpGet]
        [Route("GetAllMedicos")]
        public HttpResponseMessage GetAllMedicos()
        {
            var response = _uow.MedicoRepositorio.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("RegistroNovoMedico")]
        public HttpResponseMessage RegistroNovoMedico(MedicoDto medicoDto)
        {
            if (medicoDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var medico = MedicoRegras.CreateInstance.Add(medicoDto);
            _uow.MedicoRepositorio.Adicionar(medico);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

        [HttpPut]
        [Route("AlterarMedico")]
        public HttpResponseMessage AlterarMedico(MedicoDto medicoDto)
        {
            if (medicoDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var medico = MedicoRegras.CreateInstance.Edit(medicoDto);
            _uow.MedicoRepositorio.Atualizar(medico);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

        [HttpDelete]
        [Route("RemoverMedico/{idMedico}")]
        public HttpResponseMessage RemoverMedico(int idMedico)
        {
            var medicoId = MedicoRegras.CreateInstance.Delete(idMedico);
            _uow.MedicoRepositorio.Excluir(medico => medico.IdMedico == medicoId);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
