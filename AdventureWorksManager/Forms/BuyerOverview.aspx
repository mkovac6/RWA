<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyerOverview.aspx.cs" Inherits="AdventureWorksManager.Forms.BuyerOverview" %>

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
         <asp:LinkButton runat="server"  Text="Buyers" CssClass="navLink nav-item" Font-Underline="false"/>

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

        <div class="container">
            
           <span>Filter by:</span>

            
            <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>

            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" ></asp:DropDownList>
            
            
            <asp:LinkButton ID="btnName" runat="server" OnCommand="SetSortParameter" CommandArgument="True">Name</asp:LinkButton>
            <asp:LinkButton ID="btnLastName" runat="server" OnCommand="SetSortParameter" CommandArgument="False">Lastname</asp:LinkButton>
            
           
            <asp:DataGrid runat="server" id="dgBuyers" BorderColor="black"
           BorderWidth="1"
           CellPadding="3" CellSpacing="8" AutoGenerateColumns="false" CssClass="table" >
                
                
                <Columns>
                    <asp:BoundColumn DataField="IDKupac" HeaderText="ID" ItemStyle-Width="50">
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="FirstName" HeaderText="Name" >
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="LastName" HeaderText="Lastname">
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="Email" HeaderText="Email">
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="Phone" HeaderText="Phone">
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="City" HeaderText="City" ItemStyle-Width="100">
                    </asp:BoundColumn>
                   <asp:BoundColumn DataField="Country" HeaderText="Country">
                    </asp:BoundColumn>
                   
                  
                    <asp:TemplateColumn ItemStyle-Width="50">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" OnCommand="RedirectToEditPage"  CommandArgument= '<%# Eval("IDKupac") %>' Text="Edit" CssClass="btn btn-primary" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-Width="50">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" OnCommand="RedirectToRecordsPage"  CommandArgument= '<%# Eval("IDKupac") %>' Text="Bills" CssClass="btn btn-info" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>

            </asp:DataGrid>
            
            <asp:DataList id="dlBuyers" CssClass="MyTable" runat="server">

               

                <HeaderTemplate>
                   
                    
                
                   <td >ID</td>
                
                
                   <td >Name</td>
                
                
                   <td >Lastname</td>
                
               
                   <td >Email</td>
                
               
                   <td >Phone</td>
               
                
                   <td>City</td>
                
              
                   <td>Country</td>
                            
            
                </HeaderTemplate>
                
             <ItemTemplate >
                 <p><%# Eval("IDKupac") %></p>
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("IDKupac") %>'></asp:Label>
             
                     <p> <%# Eval("FirstName") %></p>
             
                     <p> <%# Eval("LastName") %></p>
             
                     <p>  <%# Eval("Email") %></p>
              
                     <p>  <%# Eval("Phone") %></p>
               
                    <p>  <%# Eval("City") %></p>
               
                     <p> <%# Eval("Country") %></p>
                   <asp:LinkButton runat="server" OnCommand="RedirectToEditPage"  CommandArgument= '<%# Eval("IDKupac") %>' >Edit</asp:LinkButton>                    

                </ItemTemplate>
               
            </asp:DataList>

            <asp:LinkButton ID="btn10" runat="server" OnCommand="SetListLength" CommandArgument="10">10</asp:LinkButton>
            <asp:LinkButton ID="btn25" runat="server" OnCommand="SetListLength" CommandArgument="25">25</asp:LinkButton>
            <asp:LinkButton ID="btn50" runat="server" OnCommand="SetListLength" CommandArgument="50">50</asp:LinkButton>

        </div>
    </form>
</body>
</html>
