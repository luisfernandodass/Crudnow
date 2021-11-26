using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Endereco
    {
        protected int id;
        public String logradouro;
        public int numero;
        public int cep;
        public String bairro;
        public String cidade;
        public String estado;

        public Endereco()
        {
        }

        public Endereco(int id, string logradouro, int numero, int cep, string bairro, string cidade, string estado)
        {
            this.id = id;
            this.logradouro = logradouro;
            this.numero = numero;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
        }

        public override bool Equals(object obj)
        {
            return obj is Endereco endereco &&
                   id == endereco.id &&
                   logradouro == endereco.logradouro &&
                   numero == endereco.numero &&
                   cep == endereco.cep &&
                   bairro == endereco.bairro &&
                   cidade == endereco.cidade &&
                   estado == endereco.estado;
        }

        public override int GetHashCode()
        {
            int hashCode = -204889321;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(logradouro);
            hashCode = hashCode * -1521134295 + numero.GetHashCode();
            hashCode = hashCode * -1521134295 + cep.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(bairro);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cidade);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(estado);
            return hashCode;
        }
    }
}
