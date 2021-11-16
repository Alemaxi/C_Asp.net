using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Models
{
    //Entity endereco's mapping
    public class Endereco
    {
        public long? EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        [ForeignKey("dono")]
        public Pessoa Dono { get; set; }
    }
}
