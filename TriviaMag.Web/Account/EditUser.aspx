<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="TriviaMag.Web.Account.EditUser" %>
<%@ Register TagPrefix="uc" TagName="FileUpload" Src="~/Controls/FileUpload.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit user information</h1>
    <hr />
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="username" CssClass="col-md-2 control-label">Username:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="username" CssClass="form-control" />
               
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="firstName" CssClass="col-md-2 control-label">First name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="firstName" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-2 control-label">Last name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="lastName" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Pasword:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" TextMode="Password" ID="password" CssClass="form-control" />
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="password" CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FileUploadControl" CssClass="col-md-2 control-label">Picture</asp:Label>
            <div class="col-md-10">
                <uc:FileUpload ID="FileUploadControl" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Submit" OnClick="UpdateUser" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
