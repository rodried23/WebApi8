using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Dto.Livro;
using WebApi8.Dto.Pessoa;
using WebApi8.Models;

namespace WebApi8.Services.Pessoa
{
    public class PessoaService : IPessoaInterface
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<PessoaModel>> BuscarPessoaPorCpf(string cpfPessoa)
        {
            ResponseModel<PessoaModel> resposta = new ResponseModel<PessoaModel>();
            try
            {
                var pessoa = await _context.Pessoas
                    .FirstOrDefaultAsync(pessoaBanco => pessoaBanco.CPF == cpfPessoa);

                if (pessoa == null)
                {
                    resposta.Mensagem = "Nenhum resgitro encontrado!";
                    return resposta;
                }

                resposta.Dados = pessoa;
                resposta.Mensagem = "Os dados da Pessoa foram retornados";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<PessoaModel>> BuscarPessoaPorId(int idPessoa)
        {
            ResponseModel<PessoaModel> resposta = new ResponseModel<PessoaModel>();
            try
            {
                var pessoa = await _context.Pessoas
                    .FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == idPessoa);

                if (pessoa == null)
                {
                    resposta.Mensagem = "Nenhum resgitro encontrado!";
                    return resposta;
                }

                resposta.Dados = pessoa;
                resposta.Mensagem = "Os dados da Pessoa foram retornados";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<PessoaModel>>> CadastrarPessoa(PessoaCriacaoDto pessoaCriacaoDto)
        {
            ResponseModel<List<PessoaModel>> resposta = new ResponseModel<List<PessoaModel>>();

            try
            {

                if (!ValidaCPF(pessoaCriacaoDto.CPF))
                {
                    resposta.Mensagem = "CPF inválido";
                    return resposta;
                }

                var pessoa = new PessoaModel()
                {
                    Nome = pessoaCriacaoDto.Nome,
                    Sobrenome = pessoaCriacaoDto.Sobrenome,
                    Idade = pessoaCriacaoDto.Idade,
                    Genero = pessoaCriacaoDto.Genero,
                    CPF = pessoaCriacaoDto.CPF
                };

                await _context.Pessoas.AddAsync(pessoa);

                resposta.Dados = await _context.Pessoas.ToListAsync();
                resposta.Mensagem = "Pessoa cadastrada com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PessoaModel>>> EditarPessoa(PessoaEdicaoDto pessoaEdicaoDto)
        {
            ResponseModel<List<PessoaModel>> resposta = new ResponseModel<List<PessoaModel>>();

            try
            {
                if (!ValidaCPF(pessoaEdicaoDto.CPF))
                {
                    resposta.Mensagem = "CPF inválido";
                    return resposta;
                }
                var pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == pessoaEdicaoDto.Id);

                if (pessoa == null)
                {
                    resposta.Mensagem = "Nenhum resgitro de Pessoa encontrado!";
                    return resposta;
                }

                pessoa.Nome = pessoaEdicaoDto.Nome;
                pessoa.Sobrenome = pessoaEdicaoDto.Sobrenome;
                pessoa.Idade = pessoaEdicaoDto.Idade;
                pessoa.CPF = pessoaEdicaoDto.CPF;
                pessoa.Genero = pessoaEdicaoDto.Genero;


                _context.Update(pessoa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pessoas.ToListAsync();
                resposta.Mensagem = "Pessoa Editada com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PessoaModel>>> ExcluirCadastroPessoa(int idPessoa)
        {
            ResponseModel<List<PessoaModel>> resposta = new ResponseModel<List<PessoaModel>>();

            try
            {
                var pessoa = await _context.Livros
                    .FirstOrDefaultAsync(pessoaBanco => pessoaBanco.Id == idPessoa);

                if (pessoa == null)
                {
                    resposta.Mensagem = "Nenhum resgitro encontrado!";
                    return resposta;
                }

                _context.Remove(pessoa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pessoas
                    .ToListAsync();
                resposta.Mensagem = "Cadastro de Pessoa removido com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PessoaModel>>> ListarPessoas()
        {
            ResponseModel<List<PessoaModel>> resposta = new ResponseModel<List<PessoaModel>>();
            try
            {
                var pessoas = await _context.Pessoas.ToListAsync();

                resposta.Dados = pessoas;
                resposta.Mensagem = "Todos os Cadastros foram retornados";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        private bool ValidaCPF(string cpf)
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !SeNumerico(cpf))
                return false;

            int[] cpfArray = new int[11];

            for (int i = 0; i < 11; i++)
                cpfArray[i] = int.Parse(cpf[i].ToString());

            int sum1 = 0;
            for (int i = 0; i < 9; i++)
                sum1 += cpfArray[i] * (10 - i);

            int digit1 = 11 - (sum1 % 11);
            if (digit1 >= 10)
                digit1 = 0;

            int sum2 = 0;
            for (int i = 0; i < 10; i++)
                sum2 += cpfArray[i] * (11 - i);

            int digit2 = 11 - (sum2 % 11);
            if (digit2 >= 10)
                digit2 = 0;

            return cpfArray[9] == digit1 && cpfArray[10] == digit2;
        }

        private static bool SeNumerico(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

    }
}
