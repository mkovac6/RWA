<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBuyer.aspx.cs" Inherits="AdventureWorksManager.Forms.EditBuyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/TableStyle.css" rel="stylesheet" />
    <style>
       
        nav{
            height:56px;
        }

        .navLink{

            margin:10px;
            color: #919496;
        }
        .navLink:visited{
             color: #919496;
        }
        .navLink:hover{
            color:#C7C8C9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">


         <nav class="navbar navbar-expand navbar-dark bg-dark">
        <ul id="navList" class="nav navbar-nav navbar-inverse navbar-custom">
        <li class="nav-item">
         <asp:LinkButton runat="server" OnCommand="RedirectToUsersPage"  Text="Buyers" CssClass="navLink nav-item" Font-Underline="false"/>

        </li>
        <li class="nav-item">
             <asp:LinkButton runat="server" OnCommand="RedirectToCategoriesPage" Text="Categories" CssClass="navLink nav-item"  Font-Underline="false" />
        </li>
        <li class="nav-item">
            <asp:LinkButton runat="server" OnCommand="RedirectToSubcategoriesPage" Text="Subcategories" CssClass="navLink nav-item" Font-Underline="false" />
        </li>
        <li class="nav-item">
            <asp:LinkButton runat="server" OnCommand="RedirectToProductsPage" Text="Products" CssClass="navLink nav-item" Font-Underline="false" />
        </li>
    </ul>
       
    </nav>

        <div class="form-horizontal">
            <asp:Label ID="lblID" runat="server" Text="Editing User ID: "></asp:Label>

            <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Firstname:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" Display="None" ErrorMessage="Please enter a name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
             </div>

             <div class="form-group">
            <asp:Label ID="lblLastname" runat="server" Text="Lastname"></asp:Label>
            <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLname" runat="server" Display="None" ErrorMessage="Please enter a lastname" ControlToValidate="txtLastname"></asp:RequiredFieldValidator>

             </div>
            
                 <div class="form-group">

            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ErrorMessage="Please enter an email" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regvEmail" runat="server" Display="None" ErrorMessage="Please enter a valid email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            
             </div>

                 <div class="form-group">

            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Display="None" ErrorMessage="Please enter a phone number" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
             </div>

                 <div class="form-group">

            <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
             </div>

                 <div class="form-group">

            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
            <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
             </div>
           
                 <div class="form-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

             </div>
        </div>
        <div>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
