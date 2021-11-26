using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Telefone
    {
        protected int id;
        public int ddd;
        public int numero;
        public TipoTelefone tipo;

        public Telefone()
        {
        }

        public Telefone(int id, int ddd, int numero, TipoTelefone tipo)
        {
            this.id = id;
            this.ddd = ddd;
            this.numero = numero;
            this.tipo = tipo;
        }

        public override bool Equals(object obj)
        {
            return obj is Telefone telefone &&
                   id == telefone.id &&
                   ddd == telefone.ddd &&
                   numero == telefone.numero &&
                   EqualityComparer<TipoTelefone>.Default.Equals(tipo, telefone.tipo);
        }

        public override int GetHashCode()
        {
            int hashCode = 928232871;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + ddd.GetHashCode();
            hashCode = hashCode * -1521134295 + numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoTelefone>.Default.GetHashCode(tipo);
            return hashCode;
        }
    }
}
