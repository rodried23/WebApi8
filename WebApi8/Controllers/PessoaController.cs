using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Autor;
using WebApi8.Dto.Pessoa;
using WebApi8.Models;
using WebApi8.Services.Autor;
using WebApi8.Services.Pessoa;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;

        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet("ListarPessoas")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> ListarPessoas()
        {
            var pessoas = await _pessoaInterface.ListarPessoas();
            return Ok(pessoas);
        }

        [HttpGet("BuscarPessoaPorId/{idPessoa}")]
        public async Task<ActionResult<ResponseModel<PessoaModel>>> BuscarPessoaPorId(int idPessoa)
        {
            var pessoa = await _pessoaInterface.BuscarPessoaPorId(idPessoa);
            return Ok(pessoa);
        }

        [HttpGet("BuscarPessoaPorCpf/{cpf}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarPessoaPorCPF(string cpf)
        {
            var pessoa = await _pessoaInterface.BuscarPessoaPorCpf(cpf);
            return Ok(pessoa);
        }

        [HttpPost("CadastrarPessoa")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> CadastrarPessoa(PessoaCriacaoDto pessoaCriacaoDto)
        {
            var pessoas = await _pessoaInterface.CadastrarPessoa(pessoaCriacaoDto);
            return Ok(pessoas);
        }

        [HttpPut("EditarPessoa")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> EditarAutor(PessoaEdicaoDto pessoaEdicaoDto)
        {
            var pessoas = await _pessoaInterface.EditarPessoa(pessoaEdicaoDto);
            return Ok(pessoas);
        }


        [HttpDelete("ExcluirPessoa")]
        public async Task<ActionResult<ResponseModel<List<PessoaModel>>>> ExcluirPessoa(int idPessoa)
        {
            var pessoas = await _pessoaInterface.ExcluirCadastroPessoa(idPessoa);
            return Ok(pessoas);
        }


    }
}
