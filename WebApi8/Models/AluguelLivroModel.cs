using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi8.Models
{
    public class AluguelLivroModel
    {
        public int Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataDevolucao { get; set; }
        public ICollection<LivroModel> Livro { get; set; }
        public PessoaModel Pessoa { get; set; }
    }
}
