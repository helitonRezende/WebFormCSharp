using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtletaDTO
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DtNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public string Posicao { get; set; }
        public int NroCamisa { get; set; }

    }
}
