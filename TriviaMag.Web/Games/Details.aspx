<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TriviaMag.Web.Games.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div>
                <asp:FormView ID="GameDetailsView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
                    <ItemTemplate>
                        <div class="text-center">
                            <h1>
                                <%#: Item.Creator.UserName %> <span style="font-style: italic">vs</span> <%#: Item.Receiver.UserName %>
                            </h1>
                        </div>
                        <div class="text-center">
                            <h3>
                                Score: <%#: Item.CreatorScore %> - <%#: Item.ReceiverScore %>
                            </h3>
                        </div>
                        <div class="text-center">
                            <h3>
                                <strong>Category: <%#: Item.Category %></strong>
                            </h3>
                        </div>
                    </ItemTemplate>
                </asp:FormView>
                <div class="text-center">
                    <h3>Status:
                        <asp:Label runat="server" ID="StatusLabel"></asp:Label>
                    </h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
