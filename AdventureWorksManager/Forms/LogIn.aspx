<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AdventureWorksManager.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblEmail" runat="server" class="form-label" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" class="form-label" Text="Password" ></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Log in" OnClick="LoginSubmit"/>
            <asp:Button ID="btnRegister" runat="server" class="btn btn-primary" Text="Register" OnClick="btnRegister_Click"/>
            <hr />
            <asp:Label ID="lblResult" runat="server" class="form-label" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
