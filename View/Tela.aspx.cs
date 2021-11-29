using Crudnow_MVC;
using Crudnow_MVC.modelo.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class Tela : System.Web.UI.Page
    { 
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Crudnow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SimuladorDAO dao = new SimuladorDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnInsira_Click(object sender, EventArgs e) // inserir
        {
            Pessoa p = new Pessoa();
            TipoTelefone t = new TipoTelefone();
            p.nome = txtNome.Text;
            p.cpf = txtCPF.Text;
            p.telefones.ddd = txtDDD.Text;
            p.telefones.numero = txtTelefone.Text;

         //   p.telefones.tipo.tipo = txtTipoTel.Text;

            t.tipo = txtTipoTel.Text;
            p.endereco.logradouro = txtLogradouro.Text;
            p.endereco.numero = txtNumeroLogradouro.Text;
            p.endereco.bairro = txtBairro.Text;
            p.endereco.cep = txtCEP.Text;
            p.endereco.cidade = txtCidade.Text;
            p.endereco.estado = txtUF.Text;
            dao.insira(p, t);
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTipoTel.Text = "";
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
        }

       protected void btnConsulte_Click(object sender, ImageClickEventArgs e) // consultar
        {
            Pessoa p = new Pessoa();
            p = dao.consulte(txtBuscarPeloCPF.Text);
            txtNome.Text = p.nome;
            txtCPF.Text = p.cpf;
            txtDDD.Text = p.telefones.ddd;
            txtTelefone.Text = p.telefones.numero;
          //  txtTipoTel.Text = p.telefones.tipo.tipo;
            txtLogradouro.Text = p.endereco.logradouro;
            txtNumeroLogradouro.Text = p.endereco.numero;
            txtBairro.Text = p.endereco.bairro;
            txtCEP.Text = p.endereco.cep;
            txtCidade.Text = p.endereco.cidade;
            txtUF.Text = p.endereco.estado;
        }
      
        protected void btnAltere_Click(object sender, ImageClickEventArgs e) // alterar
        {
            Pessoa p = new Pessoa();
            TipoTelefone t = new TipoTelefone();
            p.nome = txtNome.Text;
            p.cpf = txtCPF.Text;
            p.telefones.ddd = txtDDD.Text;
            p.telefones.numero = txtTelefone.Text;
            t.tipo = txtTipoTel.Text;
            p.endereco.logradouro = txtLogradouro.Text;
            p.endereco.numero = txtNumeroLogradouro.Text;
            p.endereco.bairro = txtBairro.Text;
            p.endereco.cep = txtCEP.Text;
            p.endereco.cidade = txtCidade.Text;
            p.endereco.estado = txtUF.Text;
            dao.altere(p, t);
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTipoTel.Text = "";
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
/*
            string sql =
          "UPDATE bdcadastro SET NOME='" + txtNome.Text +
          "', CPF= '" + txtCPF.Text +
          "', DDD='" + txtDDD.Text +
          "', TELEFONE='" + txtTelefone.Text +
          "', TIPO_TELEFONE='" + txtTipoTel.Text +
          "', ENDERECO= '" + txtLogradouro.Text +
          "', NUMERO='" + txtNumeroLogradouro.Text +
          "', BAIRRO='" + txtBairro.Text +
          "', CEP='" + txtCEP.Text +
          "', CIDADE= '" + txtCidade.Text +
          "', UF='" + txtUF.Text +
          "' WHERE ID=" + txtBuscarPeloCPF.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con); // recebe a instrução sql e a conexão com o BD
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Seus dados foram atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
*/
        }
        
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            txtBuscarPeloCPF.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTipoTel.Text = "";
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
        }
        protected void btnExclua_Click(object sender, ImageClickEventArgs e) // excluir
        {
            Pessoa p = new Pessoa();
            txtNome.Text = p.nome;
            txtCPF.Text = p.cpf;
            txtDDD.Text = p.telefones.ddd;
            txtTelefone.Text = p.telefones.numero;
            // p.telefones.tipo = txtTipoTel.Text;
            txtLogradouro.Text = p.endereco.logradouro;
            txtNumeroLogradouro.Text = p.endereco.numero;
            txtBairro.Text = p.endereco.bairro;
            txtCEP.Text = p.endereco.cep;
            txtCidade.Text = p.endereco.cidade;
            txtUF.Text = p.endereco.estado;
            dao.exclua(p);
            txtBuscarPeloCPF.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTipoTel.Text = "";
            txtDDD.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtNumeroLogradouro.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
        }
    }
}