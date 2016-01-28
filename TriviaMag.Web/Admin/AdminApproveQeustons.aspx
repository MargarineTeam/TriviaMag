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
                                        ID="SortByCategory"
                                        CommandName="Sort"
                                        CommandArgument="Category" />
                                </th>
                                <th class="text-center">
                                     <asp:LinkButton Text="Question" runat="server"
                                        ID="Question"
                                        CommandName="Sort"
                                        CommandArgument="Text" />
                                </th>
                                <th class="text-center">
                                     <asp:LinkButton Text="Answer" runat="server"
                                        ID="TrueAnswer"
                                        CommandName="Sort"
                                        CommandArgument="TrueAnswer" />
                                </th>
                                <th class="text-center">
                                    <%--<asp:Literal Text="Wrong Answer" runat="server" />--%>
                                    <asp:LinkButton Text="Wrong Answer" runat="server"
                                        ID="WrongAnswerOne"
                                        CommandName="Sort"
                                        CommandArgument="WrongAnswerOne" />
                                </th>
                                <th class="text-center">
                                    <asp:LinkButton Text="Wrong Answer" runat="server"
                                        ID="WrongAnswerTwo"
                                        CommandName="Sort"
                                        CommandArgument="WrongAnswerTwo" />
                                </th>
                                <th class="text-center">
                                    <asp:LinkButton Text="Wrong Answer" runat="server"
                                        ID="WrongAnswerThree"
                                        CommandName="Sort"
                                        CommandArgument="WrongAnswerThree" />
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
                                <asp:Button ID="ApproveQuestion" CssClass="btn btn-success" Text="Approve" runat="server" CommandArgument="<%# Item.Id %>" OnCommand="ApproveQuestion_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>

                    <EmptyDataTemplate runat="server">
                        <h5 class="content-empty">No items available</h5>
                    </EmptyDataTemplate>
                </asp:ListView>

            </div>
        </div>
        <div class="bs-component text-center">
            <asp:DataPager ID="DataPagerAll" PagedControlID="AllQuestions" PageSize="5" runat="server" CssClass="btn-group btn-group-sm">
                <Fields>
                    <asp:NextPreviousPagerField PreviousPageText="<" FirstPageText="<<" ShowPreviousPageButton="true"
                        ShowFirstPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false" ButtonType="Button"
                        ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />

                    <asp:NumericPagerField ButtonType="Button" CurrentPageLabelCssClass="btn btn-primary disabled" RenderNonBreakingSpacesBetweenControls="false"
                        NumericButtonCssClass="btn btn-default" ButtonCount="10" NextPageText="..." NextPreviousButtonCssClass="btn btn-default" />

                    <asp:NextPreviousPagerField NextPageText=">" LastPageText=">>" ShowNextPageButton="true"
                        ShowLastPageButton="true" ShowPreviousPageButton="false" ShowFirstPageButton="false" ButtonType="Button"
                        ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
