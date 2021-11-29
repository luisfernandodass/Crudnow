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
        } // novo registro
        protected void btnExclua_Click(object sender, ImageClickEventArgs e) // excluir
        {
            Pessoa p = new Pessoa();
            dao.exclua(txtBuscarPeloCPF.Text);
            txtNome.Text = p.nome;
            txtCPF.Text = p.cpf;
            txtDDD.Text = p.telefones.ddd;
            txtTelefone.Text = p.telefones.numero;
            // p.telefones.tipo = txtTipoTel.Text;
            txtLogradouro.Text = p.endereco.logradouro;
            p.endereco.numero = txtNumeroLogradouro.Text;
            txtBairro.Text = p.endereco.bairro;
            txtCEP.Text = p.endereco.cep;
            txtCidade.Text = p.endereco.cidade;
            txtUF.Text = p.endereco.estado;
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