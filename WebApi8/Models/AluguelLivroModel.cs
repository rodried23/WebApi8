namespace WebApi8.Models
{
    public class AluguelLivroModel
    {
        public int Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataDevolucao { get; set; }
        public ICollection<LivroModel> LivroId { get; set; }
        public PessoaModel PessoaId { get; set; }
    }
}
