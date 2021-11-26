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

       
        public void insira(Pessoa pessoa)
        {
            insertDataTabelaEndereco(pessoa);
            insertDataTabelaPessoa(pessoa);
            insertDataTabelaTelefone(pessoa);
            // insertDataTabelaPessoaTelefone(pessoa);
            updateDataTabelaEndereco(pessoa);
        }

        public Pessoa consulte(string cpf)
        {
            throw new NotImplementedException();
        }

        public void altere(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public void exclua(Pessoa p)
        {
            deleteDataTabelaPessoa(p);
            deleteDataTabelaEndereco(p);
        }

        void insertDataTabelaEndereco(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO ENDERECO (LOGRADOURO, NUMERO, CEP, BAIRRO, CIDADE, ESTADO) " +
                 "VALUES ('" 
                 + p.endereco.logradouro + "', '" 
                 + p.endereco.numero + "', '" 
                 + p.endereco.cep + "', '" 
                 + p.endereco.bairro + "', '" 
                 + p.endereco.cidade + "', '" 
                 + p.endereco.estado + "');";
            cmd.ExecuteNonQuery();
        }

        void insertDataTabelaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO TELEFONE (NUMERO, DDD) " +
                "VALUES ('" + p.telefones.numero + "', '" + p.telefones.ddd + "'); ";
            cmd.ExecuteNonQuery();
        }
        /*
        void insertDataTabelaPessoaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO PESSOA_TELEFONE(ID_PESSOA, ID_TELEFONE) SELECT p.ID, t.ID FROM PESSOA p, TELEFONE t WHERE p.CPF = " + p.cpf;
            cmd.ExecuteNonQuery();
        }
        */

        void insertDataTabelaPessoa(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO PESSOA (NOME, CPF) VALUES ('" + p.nome + "', '" + p.cpf + "')";
            cmd.ExecuteNonQuery();
        }

        void updateDataTabelaEndereco(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE PESSOA SET ENDERECO = (SELECT ENDERECO.ID FROM ENDERECO WHERE PESSOA.CPF = " + p.cpf + ");";
            cmd.ExecuteNonQuery();
        }


        void deleteDataTabelaEndereco(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE ENDERECO FROM ENDERECO e INNER JOIN PESSOA p ON e.ID = p.ENDERECO";
            cmd.ExecuteNonQuery();
        }

        void deleteDataTabelaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO TELEFONE (NUMERO, DDD) " +
                "VALUES ('" + p.telefones.numero + "', " + p.telefones.ddd + "); ";
            cmd.ExecuteNonQuery();
        }

        void deleteDataTabelaPessoaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO PESSOA_TELEFONE(ID_PESSOA, ID_TELEFONE) SELECT p.ID, t.ID FROM PESSOA p, TELEFONE t WHERE p.CPF = " + p.cpf;
            cmd.ExecuteNonQuery();
        }

        void deleteDataTabelaPessoa(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM PESSOA WHERE CPF=" + p.cpf;
            cmd.ExecuteNonQuery();
        }


    }
}
