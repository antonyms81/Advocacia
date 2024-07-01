using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Domain.Entities
{
    public class ListaCliente
    {
        public string Nome { get; set; }
        public string Documento { get; set; }

        public List<Cliente> Clientes { get; set; } = new();
    }
}
