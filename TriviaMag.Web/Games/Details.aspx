<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TriviaMag.Web.Games.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="DetailsPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:FormView ID="GameDetailsView" runat="server" SelectMethod="GetGameData" ItemType="TriviaMag.Models.Game">
                <ItemTemplate>
                    <div>
                        <h3>
                            <strong><%#: Item.Creator.UserName %></strong> vs <strong><%#: Item.Receiver.UserName %></strong>
                        </h3>
                    </div>
                    <div class="col-md-6">
                        <h3>
                            <strong><%#: Item.CreatorScore %></strong> : <strong><%#: Item.ReceiverScore %></strong>
                        </h3>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
