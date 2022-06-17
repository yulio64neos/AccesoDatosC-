<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebPruebaAccesoDat.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Adobo .NET</h1>
            <asp:Button ID="btnDatos" runat="server" Text="Probar acceso a datos" OnClick="btnDatos_Click" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="1075px"></asp:TextBox>
            <br />
            <asp:Button ID="btnProfe" runat="server" Text="Insertar Profesor" OnClick="btnProfe_Click" />
        </div>
    </form>
</body>
</html>
