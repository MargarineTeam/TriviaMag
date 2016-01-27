<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="TriviaMag.Web.Games.Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="PleaseWorks" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:FormView ID="playGameView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
                <ItemTemplate>
                    <h3>
                        <strong><%# Item.Creator.UserName %></strong> vs <strong><%#: Item.Receiver.UserName %></strong>
                    </h3>
                    <div>
                        <asp:Label ID="QuestionLabel" runat="server"> <%#: GetQuestion() %></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:FormView>
            <asp:RadioButtonList ID="RadioButtonList" runat="server" AutoPostBack="true">
            </asp:RadioButtonList>
            <asp:Button runat="server" ID="SubmitAnswerButton" Text="Submit Answer" OnClick="SubmitAnswerButton_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


