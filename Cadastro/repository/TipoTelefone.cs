using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class TipoTelefone
    {
        protected int id;
        public String tipo;
        public TipoTelefone()
        {
        }

        public TipoTelefone(int id, string tipo)
        {
            this.id = id;
            this.tipo = tipo;
        }


        public override bool Equals(object obj)
        {
            return obj is TipoTelefone telefone &&
                   id == telefone.id &&
                   tipo == telefone.tipo;
        }

        public override int GetHashCode()
        {
            int hashCode = -954804385;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tipo);
            return hashCode;
        }
    }
}
