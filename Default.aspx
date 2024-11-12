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
                    <asp:TextBox ID="txtusername" runat="server" Text='<%# Eval("UserName") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Visa Type">
                <ItemTemplate>
                    <asp:Label ID="password" runat="server" Text='<%# Eval("Password") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtpassword" runat="server" Text='<%# Eval("Password") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <!-- Command Field for Edit and Delete -->
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
   </asp:GridView>
 </div>
    <div class="row">
        <h3 class="text-center">
            Users Visa Applications
        </h3>
        <asp:GridView ID="appgrid" runat="server" AutoGenerateColumns="False" 
    OnRowCommand="appgrid_RowCommand" OnRowDeleting="appgrid_RowDeleting">
    <Columns>
        <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" ReadOnly="True" />
        <asp:BoundField DataField="UserName" HeaderText="User Name" />
        <asp:BoundField DataField="VisaType" HeaderText="Visa Type" />
        <asp:BoundField DataField="CountryOfApplication" HeaderText="Country of Application" />
        <asp:BoundField DataField="ApplicationStatus" HeaderText="Application Status" />
        <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ApplicationID") %>' Text="Edit" />
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ApplicationID") %>' Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
<div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="editModalLabel">Edit Visa Application</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:HiddenField ID="hfApplicationID" runat="server" />
        
        <!-- Form for editing fields -->
        <div class="form-group">
            <label>User Name</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label>Visa Type</label>
            <asp:DropDownList ID="ddlVisaType" runat="server" CssClass="form-control">
                <!-- Add dropdown options here -->
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label>Country of Application</label>
            <asp:TextBox ID="txtCountryOfApplication" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Application Status</label>
            <asp:DropDownList ID="ddlApplicationStatus" runat="server" CssClass="form-control">
                <!-- Add dropdown options here -->
            </asp:DropDownList>
        </div>

         <div class="form-group">
            <label>Passport Copy (PDF)</label>
            <asp:FileUpload ID="fuPassportCopy" runat="server" CssClass="form-control" />
            <asp:Label ID="lblCurrentFilePath" runat="server" Text="Current file: " Visible="false" />
            <asp:Literal ID="litCurrentFilePath" runat="server" />
        </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
      </div>
    </div>
  </div>
</div>
</asp:Content>
<!-- Bootstrap Modal for Editing -->

