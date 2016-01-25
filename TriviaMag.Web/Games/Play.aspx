<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="TriviaMag.Web.Games.Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="playGameView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
        <ItemTemplate>
            <h3>
                <strong><%# Item.Creator.UserName %></strong> vs <strong><%# Item.Receiver.UserName %></strong>
            </h3>
        </ItemTemplate>
    </asp:FormView>
    <div id="questions">
        <asp:Label ID="QuestionLabel" runat="server"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList" runat="server" SelectMethod="GetAnswersData"></asp:RadioButtonList>
    </div>
    <asp:Button runat="server" ID="SubmitAnswerButton" Text="Submit Answer" OnClick="SubmitAnswerButton_Click"/>
</asp:Content>
