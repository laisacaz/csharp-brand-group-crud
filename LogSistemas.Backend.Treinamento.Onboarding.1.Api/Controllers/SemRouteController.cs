using Microsoft.AspNetCore.Mvc;

namespace Logsistemas.Treinamento.Backend.Onboarding._1.API.Controllers
{
    [ApiController]
    public class SemRouteController : ControllerBase
    {
        /* Neste cenário não temos o prefixo no controller,
         * portanto as rotas OBRIGATORIAMENTE deverão ter o [Route]
         * Caso contrário ocorrerá erro, pois não terá nome nenhum
         */

        [HttpGet]
        [Route("prefixo-no-route-function/sufixo")]
        public ActionResult GetComPrefixo()
        {
            return Ok();
        }

        [HttpPost]
        [Route("prefixo-no-route-function/sufixo")]
        public ActionResult PostComPrefixo()
        {
            return Ok();
        }

        [HttpGet]
        [Route("nome-rota-somente-na-function")]
        public ActionResult SomenteNome()
        {
            return Ok();
        }

        /* Neste caso eu deveria colocar o prefixo manualmente */
    }
}