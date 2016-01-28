<%@ Page Title="500InternalServerError" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="TriviaMag.Web.Error._500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-offset-4">
            <h1 style="color: red">Error: 500</h1>
            <h1 style="color: red">Something went wrong!</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2">
            <h3 style="color: darkred">Internal server error!</h3>
        </div>
    </div>
</asp:Content>
