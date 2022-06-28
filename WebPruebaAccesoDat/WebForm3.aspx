<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebPruebaAccesoDat.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="javascript/bootstrap.min.js"></script>
    <script src="javascript/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Probando elementos de Bootstrap</h1>
        <div>
            <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
              <div class="toast-header">
                <svg class="bg-placeholder-img rounded mr2" width="20" height="20"></svg>
                <strong class="mr-auto">Bootstrap</strong>
                <small>11 mins ago</small>
                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="toast-body">
                Hello, world! This is a toast message.
              </div>
            </div>
        </div>
    </form>
</body>
</html>
