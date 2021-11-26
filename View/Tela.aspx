<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tela.aspx.cs" Inherits="View.Tela" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="styleSheet.css" />
    <title>Crudnow | Cadastre-se agora</title>
</head>
<body>
    <form id="form1" runat="server">
         
       

            <h1>Crudnow</h1>
            <div class="divBuscarPeloCPF">
                <asp:Label runat="server" CssClass="label" Width="180px" Height="22px">Buscar pelo CPF</asp:Label>
                <br />
                <asp:TextBox ID="txtBuscarPeloCPF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                    BorderColor="Gray"></asp:TextBox>
                <div class="divButtons">
             <asp:ImageButton ID="ImageButtonConsulte" runat="server" OnClick="btnConsulte_Click" Height="24px"
                    ImageUrl="./images/search-icon.png" Width="24px" />
                <asp:ImageButton ID="ImageButtonAltere" runat="server" OnClick="btnAltere_Click" Height="24px"
                    ImageUrl="./images/edit-icon.png" Width="24px" />
                <asp:ImageButton ID="ImageButtonExclua" runat="server" OnClick="btnExclua_Click" Height="24px"
                    ImageUrl="./images/trash-icon.png" Width="16px" />
        </div>
            </div>

        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Nome</asp:Label>
            <br />
            <asp:TextBox ID="txtNome" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">CPF</asp:Label>
            <br />
            <asp:TextBox ID="txtCPF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Text="Tipo Tel." Height="22px" Width="180px"></asp:Label>
            <br />
        <asp:ListBox ID="txtTipoTel" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px" BorderColor="Gray">
            <asp:ListItem Value="Residencial"></asp:ListItem>
            <asp:ListItem Value="Comercial"></asp:ListItem>
            <asp:ListItem Value="Recado"></asp:ListItem>
            </asp:ListBox>
           
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">DDD</asp:Label>
            <br />
            <asp:TextBox ID="txtDDD" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Telefone</asp:Label>
            <br />
            <asp:TextBox ID="txtTelefone" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Logradouro</asp:Label>
            <br />
            <asp:TextBox ID="txtLogradouro" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Nº</asp:Label>
            <br />
            <asp:TextBox ID="txtNumeroLogradouro" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Bairro</asp:Label>
            <br />
            <asp:TextBox ID="txtBairro" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">CEP</asp:Label>
            <br />
            <asp:TextBox ID="txtCEP" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">Cidade</asp:Label>
            <br />
            <asp:TextBox ID="txtCidade" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                BorderColor="Gray"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" CssClass="label" Height="22px" Width="180px">UF</asp:Label>
            <br />
            <asp:TextBox ID="txtUF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                BorderColor="Gray"></asp:TextBox>
        </div>
        <asp:Button ID="btnInsira" runat="server" Text="Cadastrar" BackColor="#0066CC" Width="185px"
            OnClick="btnInsira_Click" Height="36px" ForeColor="White" BorderWidth="0px" />
    </form>
</body>
</html>
