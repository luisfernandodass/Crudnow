using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudnow_MVC.modelo.dal
{

    public class SimuladorDAO : PessoaDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Crudnow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection con;

        public SimuladorDAO()
        {
            if (con == null)
            {
                try
                {
                    SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                    cs.DataSource = "Crudnow";
                    cs.InitialCatalog = "PESSOA";
                    cs.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                    cs.TrustServerCertificate = true;
                    con = new SqlConnection(connectionString);
                    con.Open();
                }
                catch (SqlException e)
                {
                    Console.Error.WriteLine("Ocorreu uma exceção de BD" + e.Message);
                    throw new ApplicationException("Ocorreu uma exceção de BD" + e.Message);
                }
            }
        }
       
        public void insira(Pessoa pessoa, TipoTelefone telefones)
        {
            inserirTabelaEndereco(pessoa);
            inserirTabelaPessoa(pessoa);
            inserirTabelaTelefoneTipo(telefones);
            inserirTabelaTelefone(pessoa);
            inserirAtualizandoTabelaEndereco(pessoa);
            inserirTabelaPessoaTelefone();
        }
        public Pessoa consulte(string cpf)
        {
            Pessoa p = new Pessoa();
            consultarPessoa(cpf, p);
            return p;
        }
        public void altere(Pessoa pessoa, TipoTelefone telefones)
        {
            alterarTabelaPessoa(pessoa);
            alterarTabelaEndereco(pessoa);
            alterarTabelaTelefone(pessoa);
            alterarTabelaTelefoneTipo(telefones);
        }
        public void exclua(Pessoa pessoa)
        {
           // excluirTabelaTelefone();
            excluirTabelaPessoa(pessoa);
            // excluirTabelaEndereco();
        }

        // INICÍO dos métodos para inserir
        void inserirTabelaEndereco(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, CEP, BAIRRO, CIDADE, ESTADO) " +
                 "VALUES ('" 
                 + pessoa.endereco.logradouro + "', '" 
                 + pessoa.endereco.numero + "', '" 
                 + pessoa.endereco.cep + "', '" 
                 + pessoa.endereco.bairro + "', '" 
                 + pessoa.endereco.cidade + "', '" 
                 + pessoa.endereco.estado + "');";
            cmd.ExecuteNonQuery();
        }
        void inserirAtualizandoTabelaEndereco(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE PESSOA SET ENDERECO = (SELECT ENDERECO.ID FROM ENDERECO WHERE PESSOA.CPF = " + pessoa.cpf + ");";
            cmd.ExecuteNonQuery();
        }
        void inserirTabelaPessoa(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO PESSOA (NOME, CPF) VALUES ('" + pessoa.nome + "', '" + pessoa.cpf + "')";
            cmd.ExecuteNonQuery();
        }
        void inserirTabelaPessoaTelefone() 
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO PESSOA_TELEFONE (ID_PESSOA, ID_TELEFONE) (SELECT (SELECT ID FROM PESSOA), (SELECT ID FROM TELEFONE))";
            cmd.ExecuteNonQuery();
        }
        void inserirTabelaTelefone(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO TELEFONE (NUMERO, DDD, TIPO) " +
                "VALUES ('" + pessoa.telefones.numero + "', '" + pessoa.telefones.ddd + "', (SELECT ID FROM TELEFONE_TIPO)); ";
            cmd.ExecuteNonQuery();
        }
        void inserirTabelaTelefoneTipo(TipoTelefone telefones)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO TELEFONE_TIPO (TIPO) VALUES ('" + telefones.tipo + "');";
            cmd.ExecuteNonQuery();
        }
        // FIM dos métodos para inserir

        // INICÍO dos métodos para consultar
        Pessoa consultarPessoa(string cpf, Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PESSOA p JOIN ENDERECO e JOIN TELEFONE t ON (SELECT ENDERECO FROM PESSOA) = e.ID ON t.ID = (SELECT ID_TELEFONE FROM PESSOA_TELEFONE) WHERE CPF='" + cpf + "'";

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    p.nome = reader[1].ToString();
                    p.cpf = reader[2].ToString();
                    p.telefones.numero = reader[12].ToString();
                    p.telefones.ddd = reader[13].ToString();
                    p.endereco.logradouro = reader[5].ToString();
                    p.endereco.numero = reader[6].ToString();
                    p.endereco.bairro = reader[7].ToString();
                    p.endereco.cep = reader[8].ToString();
                    p.endereco.cidade = reader[9].ToString();
                    p.endereco.estado = reader[10].ToString();
                }
                else
                {
                    Console.WriteLine("ID não encontrado, verifique o número do ID que você pesquisou");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
                reader.Close();
            return p;
        }

        // FIM dos métodos para consultar

        // INICÍO dos métodos para alterar
        void alterarTabelaEndereco(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText =
            "UPDATE ENDERECO SET LOGRADOURO='" + pessoa.endereco.logradouro +
            "', NUMERO= '" + pessoa.endereco.numero +
            "', CEP='" + pessoa.endereco.cep +
            "', BAIRRO='" + pessoa.endereco.bairro +
            "', CIDADE='" + pessoa.endereco.cidade +
            "', ESTADO= '" + pessoa.endereco.estado +
            "' WHERE ID= (SELECT ID FROM PESSOA)";
            cmd.ExecuteNonQuery();
        }
        void alterarTabelaPessoa(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = 
            "UPDATE PESSOA SET NOME='" + pessoa.nome +
             "', CPF= '" + pessoa.cpf +
            "' WHERE ID= (SELECT ID FROM ENDERECO)";
            cmd.ExecuteNonQuery();
        }
        void alterarTabelaTelefone(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = 
            "UPDATE TELEFONE SET NUMERO='" + pessoa.telefones.numero +
            "', DDD= '" + pessoa.telefones.ddd +
            "' WHERE ID= (SELECT ID_TELEFONE FROM PESSOA_TELEFONE)";
            cmd.ExecuteNonQuery();
        }
        void alterarTabelaTelefoneTipo(TipoTelefone telefones)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = 
            "UPDATE TELEFONE_TIPO SET TIPO='" + telefones.tipo +
            "' WHERE ID= (SELECT TIPO FROM TELEFONE)";
            cmd.ExecuteNonQuery();
        }
        // FIM dos métodos para alterar

        // INICÍO dos métodos para excluir
        void excluirTabelaEndereco()
        {
            SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = " DELETE FROM ENDERECO WHERE ID IN (SELECT q.ID FROM ENDERECO q INNER JOIN PESSOA u on (u.ENDERECO = q.ID))";
            // cmd.CommandText = "DELETE FROM ENDERECO WHERE ID IN (SELECT ID FROM PESSOA) ";
            cmd.CommandText = "DELETE FROM ENDERECO";

            cmd.ExecuteNonQuery();
        }
        void excluirTabelaPessoa(Pessoa pessoa)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE PESSOA FROM PESSOA p JOIN ENDERECO e JOIN TELEFONE t ON (SELECT ENDERECO FROM PESSOA) = e.ID ON t.ID = (SELECT ID_TELEFONE FROM PESSOA_TELEFONE) WHERE CPF='" + pessoa.cpf + "'";
            // cmd.CommandText = "SELECT * FROM PESSOA p JOIN ENDERECO e JOIN TELEFONE t ON (SELECT ENDERECO FROM PESSOA) = e.ID ON t.ID = (SELECT ID_TELEFONE FROM PESSOA_TELEFONE) WHERE CPF='" + cpf + "'";
            // cmd.CommandText = "DELETE PESSOA FROM PESSOA WHERE ID=(SELECT ID_PESSOA FROM PESSOA_TELEFONE)";
            // cmd.CommandText = "DELETE PESSOA FROM PESSOA INNER JOIN ENDERECO ON ENDERECO.ID = PESSOA.ID";
            cmd.ExecuteNonQuery();
        }
        void excluirTabelaTelefone()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE TELEFONE FROM TELEFONE INNER JOIN TELEFONE_TIPO ON TELEFONE_TIPO.ID = TELEFONE.TIPO";
            cmd.ExecuteNonQuery();
        }
      
        // FIM dos métodos para excluir
    }
}
