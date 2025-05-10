using System;

namespace Infodengue.Application.DTOs
{
    public class RelatorioDto
    {
        public string Arbovirose { get; set; }
        public int CodigoIbge { get; set; }
        public string Municipio { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public string CpfSolicitante { get; set; }
    }
}
