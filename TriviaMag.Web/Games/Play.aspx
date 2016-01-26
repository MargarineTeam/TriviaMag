<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="TriviaMag.Web.Games.Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager" runat="server" />--%>

    <asp:UpdatePanel runat="server" ID="QuestionUpdatePanel">
        <ContentTemplate>
            <h3>
                <strong><%# Eval("Creator.UserName") %></strong> vs <strong><%# Eval("Receiver.UserName") %></strong>
            </h3>
            <div>
                <asp:Label ID="QuestionLabel" runat="server"></asp:Label>
            </div>
            <asp:RadioButtonList ID="RadioButtonList" runat="server" SelectMethod="GetAnswersData"></asp:RadioButtonList>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:FormView ID="playGameView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
       
    </asp:FormView>--%>
    <%--<div id="clientQuestion">
        <asp:Label ID="QuestionLabel" runat="server"></asp:Label>
    </div>
    <div id="clientAnswers">
        <asp:RadioButtonList ID="RadioButtonList" runat="server" SelectMethod="GetAnswersData"></asp:RadioButtonList>
    </div>
    <span id="clientAnswerSubmit">
    <asp:Button runat="server" ID="SubmitAnswerButton" Text="Submit Answer" OnClick="SubmitAnswerButton_Click"/>
    </span>--%>
</asp:Content>
