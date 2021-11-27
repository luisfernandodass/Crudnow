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
        <div style="background-color: #FFFFFF; border-radius: 5px; width: 800px; padding: 24px 48px; margin: auto; position: relative; border: 2px solid gray;">
            <asp:Label runat="server" CssClass="label" Width="300px">Buscar pelo CPF</asp:Label>
            <br />
            <asp:TextBox ID="txtBuscarPeloCPF" CssClass="txtBox" runat="server" Width="180px" Height="32px"></asp:TextBox>
            <asp:ImageButton ID="ImageButtonConsulte" runat="server" OnClick="btnConsulte_Click" Height="24px"
                ImageUrl="./images/search-icon.png" Width="24px" />
            <asp:ImageButton ID="ImageButtonAltere" runat="server" OnClick="btnAltere_Click" Height="24px"
                ImageUrl="./images/edit-icon.png" Width="24px" />
            <asp:ImageButton ID="ImageButtonExclua" runat="server" OnClick="btnExclua_Click" Height="24px"
                ImageUrl="./images/trash-icon.png" Width="24px" />

            <p class="legend"><b>Dados pessoais</b></p>

            <asp:Label runat="server" CssClass="label" Width="780px">Nome</asp:Label>
            <br />
            <asp:TextBox ID="txtNome" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">CPF</asp:Label>
            <br />
            <asp:TextBox ID="txtCPF" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Text="Tipo Tel." Width="780px"></asp:Label>
            <br />
            <asp:ListBox ID="txtTipoTel" runat="server" Width="780px" Height="21px">
                <asp:ListItem Value="Residencial"></asp:ListItem>
                <asp:ListItem Value="Comercial"></asp:ListItem>
                <asp:ListItem Value="Recado"></asp:ListItem>
            </asp:ListBox>
            <asp:Label runat="server" CssClass="label" Width="780px">DDD</asp:Label>
            <br />
            <asp:TextBox ID="txtDDD" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">Telefone</asp:Label>
            <br />
            <asp:TextBox ID="txtTelefone" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>

            <p class="legend"><b>Endereço</b></p>

            <asp:Label runat="server" CssClass="label" Width="780px">Logradouro</asp:Label>
            <br />
            <asp:TextBox ID="txtLogradouro" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">Nº</asp:Label>
            <br />
            <asp:TextBox ID="txtNumeroLogradouro" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">Bairro</asp:Label>
            <br />
            <asp:TextBox ID="txtBairro" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">CEP</asp:Label>
            <br />
            <asp:TextBox ID="txtCEP" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">Cidade</asp:Label>
            <br />
            <asp:TextBox ID="txtCidade" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Label runat="server" CssClass="label" Width="780px">UF</asp:Label>
            <br />
            <asp:TextBox ID="txtUF" CssClass="txtBox" runat="server" Width="780px" Height="32px"></asp:TextBox>
            <asp:Button ID="btnInsira" runat="server" Text="Cadastrar" BackColor="#0066CC" Width="788px"
                OnClick="btnInsira_Click" Height="48px" ForeColor="White" BorderWidth="0px" />
        </div>
    </form>
</body>
</html>
