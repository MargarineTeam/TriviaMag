<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="TriviaMag.Web.Unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>You are not authorized for this page!</h1>
    <h3>
        Please <a runat="server" href="~/Account/Register">Register</a> or <a runat="server" href="~/Account/Login">Login</a> to continue.                            
    </h3>
</asp:Content>
