using Microsoft.AspNetCore.Mvc;

namespace Logsistemas.Treinamento.Backend.Onboarding._1.API.Controllers
{
    //Define que as rotas daqui devem ser mapeadas na API entre outras coisas https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0#apicontroller-attribute
    [ApiController]
    /* Sufixo na rota
     * A URi de todas as rotas nesse controller terão esse prefixo em seu nome
     * Neste caso é utilizado um template onde ele remove a palava controller do nome do controller
     * Sufixo será: /client
     */
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        /* Nome das rotas
         * É o sufixo do Route do controller + o Route da função
         */

        #region BuscaTodos

        /* Retorna todos os registros - Não contém nenhuma definição de route ou query
         *
         * [HttpGet]
         * É criado uma rota GET que não possui nome específico
         * Como não possui nome específico o nome dela será o sufixo do controller apenas
         * Rota: [GET] /client
         *
         * ActionResult
         * define o status code da resposta entre outras coisas
         * https://www.macoratti.net/15/10/mvc_rmact1.htm#:~:text=A%20classe%20ActionResult%20%C3%A9%20uma%20classe%20abstrata%20que%20possui%20diversos%20sub%20tipos%20e%20temos%20uma%20classe%20apropriada%20para%20cada%20tipo%20de%20retorno%20que%20%C3%A9%20derivada%20dessa%20classe.%20Abaixo%20vemos%20os%20principais%20tipos%20de%20retorno%3A
         */

        [HttpGet]
        [Route("")]
        public ActionResult BuscaTodos()
        {
            return NoContent(); //Status code: 204
        }

        #endregion BuscaTodos

        #region BuscaPorId - Route param

        /* Retorna um registro - Contém definição de route param
         *
         * {id:int}
         * Define um parâmetro de rota com o nome id
         * Rota: [GET] /client/10
         * Se não passar o id na rota, irá para outra rota, no caso a rota: [GET] /client
         *
         * Parametro int id
         * O nome do parâmetro tendo o mesmo da rota,
         * o valor que estiver na rota virá para esse parâmetro,
         * automaticamente ele vincula
         *
         * ActionResult<int> = Defini que o body da response será um Integer
         *
         * ---
         *
         * [FromRoute] int id
         * Especificando que o valor do parâmetro id virá do route
         * O nome que está no Route deve ser o mesmo do parâmetro
         *
         * [FromRoute(Name = "idcliente")] int id
         * Especificando que o valor do parâmetro id virá
         * do parametro route com nome idcliente
         */

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<int> BuscaPorId(int id)
        //public ActionResult<int> GetById2([FromRoute] int id)
        //public ActionResult<int> GetById3([FromRoute(Name = "idcliente")] int id)
        {
            return Ok(id);
        }

        #endregion BuscaPorId - Route param

        #region FiltraSimples - Query param

        /* Filtra vários registros - Contém definição de Query
         *
         * [Route("filtra-simples")]
         * Adiciona um nome da rota
         * Rota: [GET] /client/filtra-simples
         *
         * [FromQuery] string nome
         * Defini um parametro Query do tipo string com o nome cidade
         * Será vinculada automaticamente com estes parametros
         */

        [HttpGet]
        [Route("filtra-simples")]
        public ActionResult FiltraSimples([FromQuery] string cidade, [FromQuery] int idade)
        {
            return Ok(new { cidade, idade });
        }

        #endregion FiltraSimples - Query param

        #region FiltraCompleto - Query param com classe

        /* Filtra vários registros - Contém definição de Query
         *
         * [FromQuery] ClientePesquisaCompletaPayload filtros
         * Defini todas as propriedades publicas da classe ClientePesquisaFiltrosPayload como parametros Query
         * A classe será criada automaticamente e preenchida com os valores que vierem no query params
         */

        [HttpGet]
        [Route("filtra-completo")]
        public ActionResult FiltraCompleto([FromQuery] ClientePesquisaCompletaPayload filtros)
        {
            return Ok(filtros);
        }

        #endregion FiltraCompleto - Query param com classe

        #region Inserir - Body

        /* Insere - Contém definição de Body
         *
         * [FromBody] ClienteInserirPayload dadosInserir
         * Defini todas as propriedades publicas da classe ClienteInserirPayload como
         * propriedados do json que deve vir no body
         * A classe será criada automaticamente e preenchida com os valores que vierem no body
         */

        [HttpPost]
        [Route("")]
        public ActionResult Insere([FromBody] ClienteInserirPayload dadosInserir)
        {
            return Created("", dadosInserir);
        }

        #endregion Inserir - Body

        #region Alterar - Body e Route

        /* Alterar - Contém definição de Body e Route
         *
         *{id:int}
         * Define um parâmetro de rota com o nome id
         * Rota: [POST] /client/10
         *
         * [FromBody] ClienteAlterarPayload dadosAlterar
         * Defini todas as propriedades publicas da classe ClienteAlterarPayload como
         * propriedados do json que deve vir no body
         * A classe será criada automaticamente e preenchida com os valores que vierem no body
         *
         * NoContent()
         * Retorno sucesso mas sem dados na resposta
         */

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Altera([FromBody] ClienteAlterarPayload dadosAlterar)
        {
            return NoContent(); //Retorno sucesso mais sem dados na resposta
        }

        #endregion Alterar - Body e Route

        #region Exemplo completo

        /* Contém todas as definições
         *
         * Rota: [GET] aniversariantes/mes/8/ativo
         *
         * Route param
         * Query param
         * Body
         * Resposta
         *
         * Mesmo retornando dados, foi utilizado POST pois foi necessário
         * solicitar mais informações na requisição
         *
         * Isso pode acontecer.
         */

        [HttpPost]
        [Route("aniversariantes/mes/{mes:int}/ativo")]
        public ActionResult AnviersariantesAtivos(
            [FromRoute(Name = "mes")] int mesAniversario,
            [FromQuery] ClienteAniversariantePesquisaPayload outrosFiltrosPayload,
            [FromBody] DestinoDadosPayload enviarDadosPayload)
        {
            //Validação dos dados que vem da requisição
            if (mesAniversario is < 1 or > 12)
                return BadRequest("Mês de anviersário deve ser entre 1 e 12");

            if (outrosFiltrosPayload.IdCidade < 1)
                return BadRequest("Informe a cidade");

            //Executa o filtro
            List<Cliente>? clientes = BuscaAniversariantes(
                mes: mesAniversario,
                outrosFiltros: outrosFiltrosPayload);

            //Executa uma segunda operação
            if (enviarDadosPayload.EnviarEmail)
            {
                if (enviarDadosPayload.Emails.Any(email => string.IsNullOrEmpty(email)))
                    return BadRequest("Não pode informar email vazio");
                else
                {
                    //envia email
                }
            }

            //Responde a requisição
            if (clientes.Any())
                return Ok(clientes);
            else
                return NoContent();
        }

        #endregion Exemplo completo

        /* Essa rotina não é uma rota
         * Não possui [HttpGet] [HttpPost] e nem [Route]
         */

        private List<Cliente> BuscaAniversariantes(
            int mes,
            ClienteAniversariantePesquisaPayload outrosFiltros)
        {
            List<Cliente> dados = new List<Cliente>
            {
                new Cliente{Id = 1, Nome = "Alessandro", Casado = true, Ativo = true, Nascimento = new DateTime(1972, 2, 7)},
                new Cliente{Id = 1, Nome = "Fernando", Casado = true, Ativo = true, Nascimento = new DateTime(1993, 5, 7)},
                new Cliente{Id = 1, Nome = "Tiago", Casado = false, Ativo = true, Nascimento = new DateTime(1998, 6, 7)},
                new Cliente{Id = 1, Nome = "Daniel", Casado = true, Ativo = false, Nascimento = new DateTime(1990, 3, 7)},
                new Cliente{Id = 1, Nome = "Sidney", Casado = false, Ativo = true, Nascimento = new DateTime(1988, 4, 7)},
                new Cliente{Id = 1, Nome = "Laisa", Casado = false, Ativo = false, Nascimento = new DateTime(2000, 1, 7)},
                new Cliente{Id = 1, Nome = "Pedro", Casado = false, Ativo = false, Nascimento = new DateTime(2003, 10, 7)},
            };

            //Filtraria

            return dados;
        }
    }

    public class Cliente
    {
        public bool Ativo { get; set; }
        public bool Casado { get; set; }
        public int Id { get; set; }
        public string IdCidade { get; set; }
        public DateTime Nascimento { get; set; }
        public string Nome { get; set; }
    }

    public class ClienteAlterarPayload
    {
        public bool Ativo { get; set; }
        public bool Casado { get; set; }
        public int Id { get; set; }
        public string IdCidade { get; set; }
        public DateTime Nascimento { get; set; }
        public string Nome { get; set; }
    }

    public class ClienteAniversariantePesquisaPayload
    {
        public bool Casado { get; set; }
        public int IdCidade { get; set; }
    }

    public class ClienteInserirPayload
    {
        public bool Ativo { get; set; }
        public bool Casado { get; set; }
        public string IdCidade { get; set; }
        public DateTime Nascimento { get; set; }
        public string Nome { get; set; }
    }

    public class ClientePesquisaCompletaPayload
    {
        public bool Ativo { get; set; }
        public bool Casado { get; set; }
        public string IdCidade { get; set; }
        public int MesNascimento { get; set; }
        public string Nome { get; set; }
    }

    public class DestinoDadosPayload
    {
        public List<string> Emails { get; set; }
        public bool EnviarEmail { get; set; }
    }
}