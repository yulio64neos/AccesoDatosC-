<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebPruebaAccesoDat.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>ADO a CLASES</h2>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Consulta simple en el DATASET" OnClick="Button1_Click" />
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="688px"></asp:TextBox>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
