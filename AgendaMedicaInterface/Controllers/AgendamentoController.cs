using AgendaMedicaDomain.Dto;
using AgendaMedicaInfrastructure.Dao;
using AgendaMedicaInfrastructure.UnitOfWork;
using AgendaMedicaRules.Regras;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgendaMedicaInterface.Controllers
{
    [RoutePrefix("agendamento")]
    public class AgendamentoController : ApiController
    {
        private readonly UnitOfWorkAgenda _uow;

        public AgendamentoController()
        {
            _uow = new UnitOfWorkAgenda(new ContextoDb());
        }

        [HttpGet]
        [Route("GetAllAgendamentos")]
        public HttpResponseMessage GetAllAgendamentos()
        {
            var response = _uow.AgendamentoRepositorio.GetAllAgendamentos();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("RegistroNovoAgendamento")]
        public HttpResponseMessage RegistroNovoAgendamento(AgendamentoDto agendamentoDto)
        {
            if (agendamentoDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var agendamento = AgendamentoRegras.CreateInstance.Add(agendamentoDto);
            _uow.AgendamentoRepositorio.Adicionar(agendamento);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }

        [HttpPut]
        [Route("AlterarAgendamento")]
        public HttpResponseMessage AlterarAgendamento(AgendamentoDto agendamentoDto)
        {
            if (agendamentoDto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var agendamento = AgendamentoRegras.CreateInstance.Edit(agendamentoDto);
            _uow.AgendamentoRepositorio.Atualizar(agendamento);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }

        [HttpDelete]
        [Route("RemoverAgendamento/{idAgendamento}")]
        public HttpResponseMessage RemoverAgendamento(int idAgendamento)
        {
            var agendamentoId = AgendamentoRegras.CreateInstance.Delete(idAgendamento);
            _uow.AgendamentoRepositorio.Excluir(agendamento => agendamento.IdAgendamento == agendamentoId);
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
