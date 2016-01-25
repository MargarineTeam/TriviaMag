<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="ListGames.aspx.cs" inherits="TriviaMag.Web.Games.ListGames" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="finishedGames" runat="server" 
                DataKeyNames="GameId" GroupItemCount="4"
                ItemType="TriviaMag.Models.Game" SelectMethod="GetFinishedGames">
                  <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                 <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                 <ItemTemplate>
                        <td runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <span>
                                            <%#:Item.Category%>
                                        </span>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            </p>
                        </td>
                    </ItemTemplate>
                
            </asp:ListView>
        </div>
    </section>
</asp:content>
