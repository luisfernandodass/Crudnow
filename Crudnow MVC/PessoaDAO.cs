using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudnow_MVC
{
    public interface PessoaDAO
    {
        void insira(Pessoa pessoa);
        Pessoa consulte(string cpf);
        void altere(Pessoa pessoa);
        void exclua(Pessoa pessoa);
    }
}
