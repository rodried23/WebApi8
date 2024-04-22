using WebApi8.Dto.Pessoa;
using WebApi8.Models;


namespace WebApi8.Services.Pessoa
{
    public interface IPessoaInterface
    {
        Task<ResponseModel<List<PessoaModel>>> CadastrarPessoa(PessoaCriacaoDto pessoaCriacaoDto);
        Task<ResponseModel<List<PessoaModel>>> EditarPessoa(PessoaEdicaoDto pessoaEdicaoDto);
        Task<ResponseModel<List<PessoaModel>>> ExcluirCadastroPessoa(int idPessoa);
        Task<ResponseModel<List<PessoaModel>>> ListarPessoas();
        Task<ResponseModel<PessoaModel>> BuscarPessoaPorId(int idPessoa);
        Task<ResponseModel<PessoaModel>> BuscarPessoaPorCpf(string cpfPessoa);
    }
}
