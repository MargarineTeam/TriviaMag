<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Play.aspx.cs" Inherits="TriviaMag.Web.Games.Play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <asp:UpdatePanel ID="UpdatePanelTimer" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer runat="server" ID="gameTimer" Interval="100" OnTick="gameTimer_Tick"></asp:Timer>
                    <h3>
                        <asp:Label ID="TimerLabel" runat="server" Text="5"></asp:Label>
                    </h3>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="PleaseWorks" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:FormView ID="playGameView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
                        <ItemTemplate>
                            <h3>
                                <strong><%# Item.Creator.UserName %></strong> vs <strong><%#: Item.Receiver.UserName %></strong>
                            </h3>
                            <div>
                                <div class="QuestionText">
                                    <asp:Label ID="QuestionLabel" runat="server"><%#: GetQuestion() %></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                    <div class="row text-center">
                        <div class="col-lg-5 minusPaddingR">
                            <asp:Button ID="Btn1" CssClass="btn btn-info btn-block" runat="server" OnClick="SubmitAnswerButton_Click" />
                        </div>
                        <div class="col-lg-5 minusPaddingL">
                            <asp:Button ID="Btn2" CssClass="btn btn-info btn-block " runat="server" OnClick="SubmitAnswerButton_Click" />
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-lg-5 minusPaddingR">
                            <asp:Button ID="Btn3" CssClass="btn btn-info btn-block " runat="server" OnClick="SubmitAnswerButton_Click" />
                        </div>
                        <div class="col-lg-5 minusPaddingL">
                            <asp:Button ID="Btn4" CssClass="btn btn-info btn-block " runat="server" OnClick="SubmitAnswerButton_Click" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


