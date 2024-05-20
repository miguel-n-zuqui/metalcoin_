using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using MetalCoin.Application.Services;
using MetalCoin.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class CuponDescontoController : ControllerBase
    {
        private readonly ICuponsRepository _cuponsRepository;
        private readonly ICuponsServices _cuponsServices;

        public CuponDescontoController(ICuponsRepository cuponsRepository, ICuponsServices cuponsServices)
        {
            _cuponsRepository = cuponsRepository;
            _cuponsServices = cuponsServices;
        }

        [HttpGet]
        [Route("todos-cupom")]
        public async Task<ActionResult> ObterTodosCupons()
        {
            var listarCupons = await _cuponsRepository.ObterTodos();

            if (listarCupons.Count == 0) return NoContent();

            return Ok(listarCupons);
        }


        [HttpGet]
        [Route("todos-cupom-ativos")]
        public async Task<ActionResult> ObterTodosCuponsAtivos()
        {
            var listarCupons = await _cuponsRepository.BuscarCupomAtivos();


            return Ok(listarCupons);
        }
        [HttpGet]
        [Route("todos-cupom-desativados")]
        public async Task<ActionResult> ObterTodosCuponsDesativados()
        {
            var listarCupons = await _cuponsRepository.BuscarCupomIndisponiveis();


            return Ok(listarCupons);
        }
        [HttpGet]
        [Route("obter/{id:guid}")]
        public async Task<ActionResult> ObterUmCupom(Guid id)
        {
            var categoria = await _cuponsRepository.ObterPorId(id);
            if (categoria == null) return BadRequest("Cupom não encontrada");
            return Ok(categoria);
        }


        [HttpPost]
        [Route("cadastrar-cupom")]
        public async Task<ActionResult> CadastrarCupom([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("Informe o nome da cupom");

            var response = await _cuponsServices.CadastrarCupom(cupom);

            if (response == null) return BadRequest("Cupom já existe");

            return Created("cadastrar", response);
        }


        [HttpPut]
        [Route("atualizar-cupom")]
        public async Task<ActionResult> AtualizarCupom([FromBody] CupomAtualizarRequest cupom)
        {
            if (cupom == null) return BadRequest("Nenhum valor chegou na API");

            var response = await _cuponsServices.AtualizaCupom(cupom);

            return Ok(response);
        }

        [HttpPut]
        [Route("Utilizar-cupom")]
        public async Task<ActionResult> UtilizarCupom(string codigo)
        {
            if (codigo == null) return BadRequest("Nenhum codigo foi passado");

           var usarcupom = await _cuponsServices.UtilizarCupom(codigo);

            if (!usarcupom) return BadRequest("Esse cupom nao está liberado para uso");

            return Ok("Cupom utilizado com sucesso");
        }


        [HttpDelete]
        [Route("deletar/cupom/{id:guid}")]
        public async Task<ActionResult> RemoverCupom(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não informado");

            var resultado = await _cuponsServices.DeletarCupom(id);

            if (!resultado) return BadRequest("o cupom que está tentando deletar não existe");

            return Ok("Cupom deletada com sucesso");
        }

        [HttpPut]
        [Route("ativar-cupom")]
        public async Task<ActionResult> AtivarCupom(Guid id)
        {
            if (id == null) return BadRequest("Nenhum valor chegou na API");
            
            var resultado = await _cuponsServices.AtivarCupom(id);

            if (!resultado) return BadRequest("o cupom já está ativado");

            return Ok("Cupom ativado com sucesso");
        }

        [HttpPut]
        [Route("desativar-cupom")]
        public async Task<ActionResult> DesativarCupom(Guid id)
        {
            if (id == null) return BadRequest("Nenhum valor chegou na API");

            var resultado = await _cuponsServices.DesativarCupom(id);

            if (!resultado) return BadRequest("O cupom já está desativado");

            return Ok("Cupom desativado com sucesso");
        }


    }
}
