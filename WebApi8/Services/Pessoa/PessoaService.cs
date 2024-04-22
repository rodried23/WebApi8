using WebApi8.Dto.Pessoa;
using WebApi8.Models;

namespace WebApi8.Services.Pessoa
{
    public class PessoaService : IPessoaInterface
    {
        public Task<ResponseModel<List<PessoaModel>>> BuscarPessoaPorCpf(string cpfPessoa)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PessoaModel>> BuscarPessoaPorId(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PessoaModel>>> CadastrarPessoa(PessoaCriacaoDto pessoaCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PessoaModel>>> EditarPessoa(PessoaEdicaoDto pessoaEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PessoaModel>>> ExcluirCadastroPessoa(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PessoaModel>>> ListarPessoas()
        {
            throw new NotImplementedException();
        }
    }
}
