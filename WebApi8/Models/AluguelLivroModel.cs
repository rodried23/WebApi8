namespace WebApi8.Models
{
    public class AluguelLivroModel
    {
        public int Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataDevolucao { get; set; }
        public ICollection<LivroModel> IdLivro { get; set;}
        public PessoalModel IdPessoa { get; set; }
    }
}
