<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListGames.aspx.cs" Inherits="TriviaMag.Web.Games.ListGames" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center" style="background-color: #463851;">
        <section>
            <div>
                <hgroup>
                    <h2><%: Page.Title %></h2>
                </hgroup>
                <div class="row">
                    <div class="panel panel-success">
                        <div class="panel-heading text-center">Your Turn</div>
                        <asp:ListView ID="PendingGames" runat="server"
                            SelectMethod="GridViewPendingGames"
                            ItemType="TriviaMag.Models.Game"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            DataKeyNames="Id"
                            AutoGenerateColumns="false">
                            <LayoutTemplate>
                                <table class="table table-striped table-hover">
                                    <tr>
                                        <th class="text-center">
                                            <asp:Literal Text="Category" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Defender" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Deffender Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Details" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Play :}" runat="server" />
                                        </th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate runat="server">
                                <tr class="text-center gamesListText" style="color: crimson;">
                                    <td>
                                        <asp:Label Text='<%#: Item.Category %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Creator.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Receiver.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.CreatorScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.ReceiverScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# string.Format("~/Games/Details?id={0}", Item.Id)%>' class="btn btn-info" Text='Details' />
                                    </td>
                                    <td>
                                        <asp:HyperLink runat="server" ID="PlayButton" NavigateUrl='<%# string.Format("~/Games/Play?id={0}", Item.Id)%>' class="btn btn-success" Text='Play' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate runat="server">
                                <h5 class="content-empty text-center">No pending games available</h5>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>

                </div>
                <div class="row">
                    <div class="panel panel-danger">
                        <div class="panel-heading text-center">Waiting for Opponent</div>
                        <asp:ListView ID="WaitingGames" runat="server"
                            SelectMethod="GridViewWaitingGames"
                            ItemType="TriviaMag.Models.Game"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            DataKeyNames="Id"
                            AutoGenerateColumns="false">
                            <LayoutTemplate>
                                <table class="table table-striped table-hover">
                                    <tr>
                                        <th class="text-center">
                                            <asp:Literal Text="Category" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Defender" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Deffender Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Details" runat="server" />
                                        </th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate runat="server">
                                <tr class="text-center gamesListText" style="color: crimson;">
                                    <td>
                                        <asp:Label Text='<%#: Item.Category %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Creator.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Receiver.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.CreatorScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.ReceiverScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# string.Format("~/Games/Details?id={0}", Item.Id)%>' class="btn btn-info" Text='Details' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate runat="server">
                                <h5 class="content-empty text-center">No such games available</h5>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="row">
                    <div class="panel panel-primary">
                        <div class="panel-heading text-center">Finished Games</div>
                        <asp:ListView ID="FinnishedGames" runat="server"
                            SelectMethod="GridViewFinishedGames"
                            ItemType="TriviaMag.Models.Game"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            DataKeyNames="Id"
                            AutoGenerateColumns="false">
                            <LayoutTemplate>
                                <table class="table table-striped table-hover">
                                    <tr>
                                        <th class="text-center">
                                            <asp:Literal Text="Category" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Defender" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Attacker Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Deffender Points" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Winner" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Details" runat="server" />
                                        </th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>

                            <ItemTemplate runat="server">
                                <tr class="text-center gamesListText" style="color: crimson;">
                                    <td>
                                        <asp:Label Text='<%#: Item.Category %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Creator.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Receiver.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.CreatorScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.ReceiverScore %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Creator.UserName %>' runat="server" Visible='<%# Item.CreatorScore > Item.ReceiverScore || (Item.CreatorScore == Item.ReceiverScore  && Item.CreatorTime < Item.ReceiverTime)%>' />
                                        <asp:Label Text='<%#: Item.Receiver.UserName %>' runat="server" Visible='<%# Item.ReceiverScore > Item.CreatorScore || (Item.ReceiverScore == Item.CreatorScore  && Item.CreatorTime > Item.ReceiverTime)%>' />
                                        <asp:Label Text='Tie' runat="server" Visible='<%# Item.ReceiverScore == Item.CreatorScore && Item.CreatorTime == Item.ReceiverTime%>' />

                                    </td>
                                    <td>
                                        <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# string.Format("~/Games/Details?id={0}", Item.Id)%>' class="btn btn-info" Text='Details' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate runat="server">
                                <h5 class="content-empty text-center">No finished games available</h5>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
