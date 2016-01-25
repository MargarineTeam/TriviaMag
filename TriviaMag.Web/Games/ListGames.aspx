<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="ListGames.aspx.cs" inherits="TriviaMag.Web.Games.ListGames" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
             <div class="row">
                 <div class="col-md-6">
                    <div class="panel panel-success successPanel">
                            <div class="panel-heading text-center">Pending Games</div>
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
                                                            <asp:Literal Text="Defender" runat="server"/>
                                                        </th>
                                                        <th class="text-center">
                                                            <asp:Literal Text="Attacker Points" runat="server" />
                                                        </th>
                                                        <th class="text-center">
                                                            <asp:Literal Text="Deffender Points" runat="server" />
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
                                                        <asp:HyperLink  NavigateUrl="~/Games/Play" class="btn btn-success" Text='Play' runat="server" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>

                                            <EmptyDataTemplate runat="server">
                                                <h5 class="content-empty text-center">No pending games available</h5>
                                            </EmptyDataTemplate>
                                        </asp:ListView>
                        </div>
                    </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
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
                                                            <asp:Literal Text="Defender" runat="server"/>
                                                        </th>
                                                        <th class="text-center">
                                                            <asp:Literal Text="Attacker Points" runat="server" />
                                                        </th>
                                                        <th class="text-center">
                                                            <asp:Literal Text="Deffender Points" runat="server" />
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
                                                </tr>
                                            </ItemTemplate>

                                            <EmptyDataTemplate runat="server">
                                                <h5 class="content-empty text-center">No such games available</h5>
                                            </EmptyDataTemplate>
                                        </asp:ListView>
                        </div>
                    </div>
                </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-danger">
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
                                                            <asp:Literal Text="Defender" runat="server"/>
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
                                                        <asp:Label Text='<%#: Item.Creator.UserName %>' runat="server" visible='<%# Item.CreatorScore > Item.ReceiverScore %>' />
                                                        <asp:Label Text='<%#: Item.Receiver.UserName %>' runat="server" visible='<%# Item.ReceiverScore > Item.CreatorScore %>'/>
                                                        
                                                    </td>
                                                </tr>
                                            </ItemTemplate>

                                            <EmptyDataTemplate runat="server">
                                                <h5 class="content-empty text-center">No finnished games available</h5>
                                            </EmptyDataTemplate>
                                        </asp:ListView>
                        </div>
                    </div>
                </div>
        </div>
    </section>
</asp:content>
