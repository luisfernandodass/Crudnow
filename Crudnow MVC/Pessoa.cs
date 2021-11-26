using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudnow_MVC
{
    public class Pessoa
    {
        protected int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public Endereco endereco = new Endereco();
        public Telefone telefones = new Telefone();
        public override bool Equals(object obj)
        {
            bool saida = false;
            if(typeof(Pessoa) == obj.GetType())
            {
                Pessoa pessoa = (Pessoa)obj;
                if(this.nome.Equals(pessoa.nome) && this.telefones == pessoa.telefones)
                {
                    saida = true;
                }
            }
            return saida;
        }

        public override string ToString()
        {
            return nome + " - " + telefones;
        }
    }
}
