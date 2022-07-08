<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AdventureWorksManager.Forms.Register" %>

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
            <asp:Label ID="lblEmail" runat="server" Text="Email:" class="form-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ErrorMessage="Email is required" ControlToValidate="txtEmail" Text=""  />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" Text="" ErrorMessage="Enter a valid email address"  />

            <asp:Label ID="lblNickname" runat="server" Text="Nickname:" class="form-label"></asp:Label>
            <asp:TextBox ID="txtNickname" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNickname" runat="server" Display="None" ErrorMessage="Nickname is required" ControlToValidate="txtNickname" />

            <asp:Label ID="lblPassword" runat="server" Text="Password:" class="form-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None" ErrorMessage="Password is required" ControlToValidate="txtPassword" Text="" />

            <asp:Label ID="lblRepeatPassword" runat="server" Text="Repeat password:" class="form-label"></asp:Label>
            <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server" Display="None" ErrorMessage="Re-enter password" ControlToValidate="txtRepeatPassword" Text="" />
            <asp:CompareValidator ID="cvRepeatPassword" runat="server" Display="None" ErrorMessage="Repeated password must match original password" ControlToCompare="txtPassword" ControlToValidate="txtRepeatPassword" Text="" />


            <asp:Button ID="btnRegister" runat="server" class="btn btn-primary" Text="Register" OnClick="btnRegister_Click"/>

            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"  />
            </div>

        </div>
    </form>
</body>
</html>
