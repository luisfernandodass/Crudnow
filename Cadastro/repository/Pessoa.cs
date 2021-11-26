using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Pessoa
    {
        protected int id;
        public String nome;
        public long cpf;
        public Endereco endereco;
        public Telefone telefone;

        public Pessoa()
        {
        }
        public Pessoa(int id, string nome, long cpf, Endereco endereco, Telefone telefone)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        public override bool Equals(object obj)
        {
            return obj is Pessoa pessoa &&
                   id == pessoa.id &&
                   nome == pessoa.nome &&
                   cpf == pessoa.cpf &&
                   EqualityComparer<Endereco>.Default.Equals(endereco, pessoa.endereco) &&
                   EqualityComparer<Telefone>.Default.Equals(telefone, pessoa.telefone);
        }

        public override int GetHashCode()
        {
            int hashCode = -538714027;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
            hashCode = hashCode * -1521134295 + cpf.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Endereco>.Default.GetHashCode(endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<Telefone>.Default.GetHashCode(telefone);
            return hashCode;
        }
    }
}
