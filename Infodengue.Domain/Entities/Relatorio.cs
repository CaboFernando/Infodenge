using Infodengue.Domain.Entities;

public class Relatorio
{
    public int Id { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public string Arbovirose { get; set; }
    public Solicitante Solicitante { get; set; }
    public int SolicitanteId { get; set; }
    public int SemanaInicio { get; set; }
    public int SemanaFim { get; set; }
    public int CodigoIbge { get; set; }
    public string Municipio { get; set; }
}
