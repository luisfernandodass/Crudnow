using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class CadastroDAO : PessoaDAO
    {
        private static SqlConnection con;

        public CadastroDAO()
        {
            if(con == null)
            {
                try
                {
                    SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
                    cs.DataSource = "CADSTR_CLIENT";
                    cs.InitialCatalog = "Pessoa";
                    cs.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                    cs.TrustServerCertificate = true;

                    con = new SqlConnection(cs.ConnectionString);
                    con.Open();
                }
                catch (SqlException e)
                {
                    Console.Error.WriteLine("Ocorreu uma exceção de BD" + e.Message);
                    throw new ApplicationException("Ocorreu uma exceção de BD" + e.Message);
                }
            }
        }
        void PessoaDAO.insira(Pessoa p)
        {
            insertDataTabelaEndereco(p);
            insertDataTabelaPessoa(p);
            insertDataTabelaTelefone(p);
            insertDataTabelaPessoaTelefone();
        }
        void PessoaDAO.altere(Pessoa p)
        {
            throw new NotImplementedException();
        }

        Pessoa PessoaDAO.consulte(long cpf)
        {
            Pessoa pessoa = new Pessoa();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select p FROM Pessoa p WHERE p.cpf = " + cpf;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pessoa.nome = reader.GetString(0);
                pessoa.cpf = reader.GetInt64(1);
                pessoa.endereco.logradouro = reader.GetString();
                pessoa.endereco.numero = reader.GetInt32();
                pessoa.endereco.bairro = reader.GetString();
                pessoa.endereco.cep = reader.GetInt32();
                pessoa.endereco.cidade = reader.GetString();
                pessoa.endereco.estado = reader.GetString();
                pessoa.telefone.ddd = reader.GetInt32();
                pessoa.telefone.numero = reader.GetInt32();
                pessoa.telefone.tipo = reader.GetInt32();
            }

            return pessoa;
        }

        void PessoaDAO.exclua(Pessoa p)
        {
            throw new NotImplementedException();
        }      
        void insertDataTabelaPessoa(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa (nome, cpf, endereco) " +
                "VALUES ('" + p.nome + "', " + p.cpf + ",(SELECT (Id) FROM Endereco)); ";
            cmd.ExecuteNonQuery();
        }
       
        void insertDataTabelaEndereco(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Endereco (logradouro, numero, cep, bairro, cidade, estado) " +
                 "VALUES ('" + p.endereco.logradouro + "', " + p.endereco.numero + ", " + p.endereco.cep +
                 ", " + p.endereco.bairro + ", " + p.endereco.cidade + ", " + p.endereco.estado + ");";
            cmd.ExecuteNonQuery();
        }
        void insertDataTabelaTelefone(Pessoa p)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Telefone (numero, ddd, tipo) " +
                "VALUES ('" + p.telefone.numero + "', " + p.telefone.ddd + ", (SELECT (Id) FROM Tipo_Telefone)); ";
            cmd.ExecuteNonQuery();
        }
        void insertDataTabelaPessoaTelefone()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa_Telefone(id_pessoa, id_telefone) " +
                "Id, Id FROM Pessoa, Telefone";
            cmd.ExecuteNonQuery();
        }

    }
}
