<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VisaApplication._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h3 class="text-center">
            All Users
        </h3>
            <asp:GridView ID="userGrid" runat="server" AutoGenerateColumns="False" 
        OnRowEditing="userGrid_RowEditing" OnRowCancelingEdit="userGrid_RowCancelingEdit"
        OnRowUpdating="userGrid_RowUpdating" OnRowDeleting="userGrid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="username" runat="server" Text='<%# Eval("UserName") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="username" runat="server" Text='<%# Eval("UserName") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Visa Type">
                <ItemTemplate>
                    <asp:Label ID="password" runat="server" Text='<%# Eval("Password") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="password" runat="server" Text='<%# Eval("Password") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <!-- Command Field for Edit and Delete -->
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
   </asp:GridView>
 </div>
</asp:Content>
