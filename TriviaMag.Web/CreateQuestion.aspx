<%@ Page Title="Create Question" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQuestion.aspx.cs" Inherits="TriviaMag.Web.CreateQuestion" %>

<asp:Content ID="CreateQuestion" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Create a new Question</legend>
        <div class="form-group row">
            <div class="col-md-1">
                <asp:Label ID="categoryLabel" runat="server" for="categoryDropdown" CssClass="control-label">Category:</asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="categoryDropdown" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <asp:Label ID="textLabel" runat="server" CssClass="control-label col-md-1">Question:</asp:Label>
            <asp:TextBox ID="textTextbox" runat="server" CssClass="form-control col-md-5" placeholder="Write your question"></asp:TextBox>
        </div>
        <div class="form-group row">
            <asp:Label ID="correctAnswerLabel" runat="server" CssClass="control-label col-md-1">The correct answer:</asp:Label>
            <asp:TextBox ID="correctAnswerTextbox" runat="server" CssClass="form-control col-md-3" placeholder="The Correct Answer"></asp:TextBox>
            <asp:Label ID="FirstWrongAnswerLabel" runat="server" CssClass="control-label col-md-1">Wrong answer:</asp:Label>
            <asp:TextBox ID="FirstWrongAnswerTextbox" runat="server" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
        </div>
        <div class="form-group row">
            <asp:Label ID="SecondWrongAnswerLabel" runat="server" CssClass="control-label col-md-1">Wrong answer:</asp:Label>
            <asp:TextBox ID="SecondWrongAnswerTextbox" runat="server" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
            <asp:Label ID="ThirdWrongAnswerLabel" runat="server" CssClass="control-label col-md-1">Wrong answer:</asp:Label>
            <asp:TextBox ID="ThirdWrongAnswerTextbox" runat="server" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
        </div>
    </fieldset>
</asp:Content>
