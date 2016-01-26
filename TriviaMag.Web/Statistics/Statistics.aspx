<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Statistics.aspx.cs" inherits="TriviaMag.Web.Statistics.Statistics" %>

<%@ OutputCache CacheProfile="ShortLived" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">

 <div class="jumbotron text-center" style="background-color: #7B4253;">
        <h1 style="color: #E8CD86;" class="homeMag">Statistics</h1>
        <hr style="border-top-color: #E8CD86"/>
     <asp:ListView ID="PendingGames" runat="server"
                                            SelectMethod="GetStats"
                                            ItemType="TriviaMag.Services.Statistics"
                                            AllowPaging="True"
                                            EnableSortingAndPagingCallback="True"
                                            AutoGenerateColumns="false">
                                            <LayoutTemplate>            
                                              <div class="row" style="color: rgb(216, 175, 72);">
                                                <div class="col-md-4 ">
                                                   <asp:Literal Text="Category" runat="server" />
                                                </div>
                                                <div class="col-md-4">
                                                      <asp:Literal Text="Games played" runat="server" />
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Literal Text="Percentage" runat="server" />
                                                </div>
                                             </div>
                                                    <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                                </table>
                                            </LayoutTemplate>

                                            <ItemTemplate runat="server">
                                                  <div class="row">
                                                     <div class="col-md-4 statsTExt">
                                                          <img  src="../images/<%#: Item.Name %>.jpg" class="statsImg text-center img-circle"/>
                                                     </div>
                                                      <div class="col-md-4 statsTExt">
                    
                                                           <asp:Label Text='<%#: Item.Games %>' runat="server" />
                                                     </div>
                                                      <div class="col-md-4 statsTExt">
                                                          <asp:Label Text='<%#: Item.Percentage %>' runat="server" />%
                                                     </div>
                                                  </div>
                                            </ItemTemplate>

                                            <EmptyDataTemplate runat="server">
                                                <h5 class="content-empty text-center">No pending games available</h5>
                                            </EmptyDataTemplate>
                                        </asp:ListView>
    </div>

</asp:content>
