using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudnow_MVC
{
    public class Telefone
    {
        protected int id { get; set; }
        public string numero { get; set; }
        public string ddd { get; set; }
        public TipoTelefone tipo { get; set; }
    }
}
