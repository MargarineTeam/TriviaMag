<%@ Page Title="Create Question" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQuestion.aspx.cs" Inherits="TriviaMag.Web.CreateQuestion" %>

<asp:Content ID="CreateQuestion" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="jumbotron text-center" style="background-color: #7C4E5B;">

        <fieldset>
            <legend class="createQ">Create a new Question</legend>
            <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false">
                <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
            </asp:Panel>
            <div class="form-group row">
                <div class="col-md-1">
                    <asp:Label ID="categoryLabel" runat="server" AssociatedControlID="categoryDropdown" CssClass="control-label">Category:</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="categoryDropdown" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="- Select category -" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="textLabel" runat="server" AssociatedControlID="textTextbox" CssClass="control-label col-md-2">Question:</asp:Label>
                <asp:TextBox ID="textTextbox" runat="server" CssClass="form-control col-md-5" placeholder="Write your question"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="correctAnswerLabel" runat="server" AssociatedControlID="correctAnswerTextbox" ForeColor="Green" CssClass="control-label col-md-2">The correct answer:</asp:Label>
                <asp:TextBox ID="correctAnswerTextbox" runat="server" ForeColor="Green" CssClass="form-control col-md-3" placeholder="The Correct Answer"></asp:TextBox>
                <span class="col-md-1"></span>
                <asp:Label ID="FirstWrongAnswerLabel" runat="server" AssociatedControlID="FirstWrongAnswerTextbox" ForeColor="#8E1F1C" CssClass="control-label col-md-2">Wrong answer:</asp:Label>
                <asp:TextBox ID="FirstWrongAnswerTextbox" runat="server" ForeColor="#8E1F1C" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="SecondWrongAnswerLabel" runat="server" AssociatedControlID="SecondWrongAnswerTextbox" ForeColor="#8E1F1C" CssClass="control-label col-md-2">Wrong answer:</asp:Label>
                <asp:TextBox ID="SecondWrongAnswerTextbox" runat="server" ForeColor="#8E1F1C" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
                <span class="col-md-1"></span>
                <asp:Label ID="ThirdWrongAnswerLabel" runat="server" AssociatedControlID="ThirdWrongAnswerTextbox" ForeColor="#8E1F1C" CssClass="control-label col-md-2">Wrong answer:</asp:Label>
                <asp:TextBox ID="ThirdWrongAnswerTextbox" runat="server" ForeColor="#8E1F1C" CssClass="form-control col-md-3" placeholder="Wrong Answer"></asp:TextBox>
            </div>
            <asp:Button ID="submitQuestionBtn" runat="server" OnClick="SubmitQuestion" Text="Submit" CssClass="btn btn-info" />
        </fieldset>
    </div>
</asp:Content>
