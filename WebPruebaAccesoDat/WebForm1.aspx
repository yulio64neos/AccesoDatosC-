<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebPruebaAccesoDat.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>ADO en el formulario</h2>
    <form id="form1" runat="server">
        <div>
            <h1>Adobo .NET</h1>
            <asp:Button ID="btnDatos" runat="server" Text="Probar acceso a datos" OnClick="btnDatos_Click" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="1075px"></asp:TextBox>
            <br />
            <asp:Button ID="btnProfe" runat="server" Text="Insertar Profesor" OnClick="btnProfe_Click" />
            <br />
            <br />
            <asp:Button ID="btnConsulta" runat="server" Text="Consulta en DataReader" OnClick="btnConsulta_Click" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="154px" Width="807px"></asp:ListBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="972px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnDataSet" runat="server" Text="Consulta Dataset" OnClick="btnDataSet_Click" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
