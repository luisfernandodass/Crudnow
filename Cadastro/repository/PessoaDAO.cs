using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    interface PessoaDAO
    {
        void insira(Pessoa p);
        void altere(Pessoa p);
        void exclua(Pessoa p);
        Pessoa consulte(long cpf);
    }
}
