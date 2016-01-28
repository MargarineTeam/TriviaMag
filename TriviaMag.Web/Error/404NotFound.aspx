<%@ Page Title="404NotFound" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404NotFound.aspx.cs" Inherits="TriviaMag.Web.Error._404NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-offset-4">
            <h1 style="color: red">Error: 404</h1>
            <h1 style="color: red">Page Not Found!</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2">
            <h3 style="color: darkred">The URL you are trying to access is not available!</h3>
        </div>
    </div>
</asp:Content>
