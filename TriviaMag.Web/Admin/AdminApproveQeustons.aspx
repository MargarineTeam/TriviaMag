<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminApproveQeustons.aspx.cs" Inherits="TriviaMag.Web.Admin.AdminApproveQeustons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Approve fast</h1>
    <div class="jumbotron text-center" style="background-color: #463851;">

        <div class="row text-center">
            <div class="col-md-12">
                <div class="panel-heading text-center"><%: Title %></div>
                <asp:ListView ID="AllQuestions" runat="server"
                    SelectMethod="GetAllToBeApproved"
                    ItemType="TriviaMag.Models.Question"
                    AllowPaging="True"
                    EnableSortingAndPagingCallback="True"
                    AllowSorting="True"
                    DataKeyNames="Id"
                    AutoGenerateColumns="false">
                    <LayoutTemplate>
                        <table class="table" style="color: #DE5226;">
                            <tr>
                                <th class="text-center">
                                    <asp:LinkButton Text="Category" runat="server"
                                        ID="SortByModel"
                                        CommandName="Sort"
                                        CommandArgument="Description" />
                                </th>
                                <th class="text-center">
                                    <asp:Literal Text="Question" runat="server" />
                                </th>
                                <th class="text-center">
                                    <asp:Literal Text="True Answer" runat="server" />
                                </th>
                                <th class="text-center">
                                    <asp:Literal Text="Wrong Answer" runat="server" />
                                </th>
                                <th class="text-center">
                                    <asp:Literal Text="Wrong Answer" runat="server" />
                                </th>
                                <th class="text-center">
                                    <asp:Literal Text="Wrong Answer" runat="server" />
                                </th>
                                <th class="text-center"></th>
                            </tr>
                            <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate runat="server">
                        <tr>
                            <td>
                                <asp:Label Text='<%#: Item.Category %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%#: Item.Text %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%#: Item.TrueAnswer %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%#: Item.WrongAnswerOne %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%#: Item.WrongAnswerTwo %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%#: Item.WrongAnswerThree %>' runat="server" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-success" Text="Approve" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>

                    <EmptyDataTemplate runat="server">
                        <h5 class="content-empty">No items available</h5>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
