using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Telefone { get; set; }

    }
}
