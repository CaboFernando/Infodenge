namespace Infodengue.Domain.Entities
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
