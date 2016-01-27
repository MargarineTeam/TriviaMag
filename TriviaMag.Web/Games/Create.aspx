<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TriviaMag.Web.Games.Create" %>

<asp:Content ID="Create" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false" CssClass="text-center">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <br />

        <asp:Panel ID="CategoriesPanel" runat="server">

            <div class="row text-center">
                <h1>Choose category</h1>
                <hr />
                <div class="jumbotron text-center" style="background-color: #463851;">

                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-2">
                            <asp:ImageButton ID="ArtCategory" runat="server" ImageUrl="~/images/art.jpg" CssClass="img-responsive img-rounded categoryImages" OnClick="ChooseCategory" CommandArgument="Art" CommandName="Art" />
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:ImageButton ID="HistoryCategory" runat="server" ImageUrl="~/images/history.jpg" CssClass="img-responsive img-rounded categoryImages" OnClick="ChooseCategory" CommandArgument="History" CommandName="History" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5"></div>
                        <div class="col-md-2">
                            <asp:ImageButton ID="SportCategory" runat="server" ImageUrl="~/images/sport.jpg" CssClass="img-responsive img-rounded categoryImages" OnClick="ChooseCategory" CommandArgument="Sport" CommandName="Sport" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-2">
                            <asp:ImageButton ID="SienceCategory" runat="server" ImageUrl="~/images/science.jpg" CssClass="img-responsive img-rounded categoryImages" OnClick="ChooseCategory" CommandArgument="Science" CommandName="Science" />
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:ImageButton ID="EntertainmentCategory" runat="server" ImageUrl="~/images/entertainment.jpg" CssClass="img-responsive img-rounded categoryImages" OnClick="ChooseCategory" CommandArgument="Entertainment" CommandName="Entertainment" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="UsersPanel" runat="server">

            <div class="row text-center">
                <div class="col-md-12">
                    <div class="panel-heading text-center">
                        <h1>Choose player to play with</h1>
                    </div>
                    <div class="jumbotron text-center" style="background-color: #463851;">

                        <asp:ListView ID="AllUsers" runat="server"
                            SelectMethod="GetUsers"
                            ItemType="TriviaMag.Models.User"
                            AllowPaging="True"
                            EnableSortingAndPagingCallback="True"
                            AllowSorting="True"
                            DataKeyNames="Id"
                            AutoGenerateColumns="false">
                            <LayoutTemplate>
                                <table class="table" style="color: #DE5226;">
                                    <tr>
                                        <th class="text-center">
                                            <asp:LinkButton Text="Username" runat="server"
                                                ID="SortByModel"
                                                CommandName="Sort"
                                                CommandArgument="Description" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="First name" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Last name" runat="server" />
                                        </th>
                                        <th class="text-center">
                                            <asp:Literal Text="Score" runat="server" />
                                        </th>
                                        <th class="text-center"></th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemplaceholder" runat="server" />
                                </table>
                            </LayoutTemplate>

                            <ItemTemplate runat="server">
                                <tr>
                                    <td>
                                        <asp:Label Text='<%#: Item.UserName %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Firstname %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Lastname %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text='<%#: Item.Score %>' runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="chooseBtn" CssClass="btn btn-success" Text="Choose" runat="server" CommandArgument="<%# Item.Id %>" OnCommand="GridView1_RowCommand" />
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
            <div class="bs-component text-center">
                <asp:DataPager ID="DataPagerAll" PagedControlID="AllUsers" PageSize="5" runat="server" CssClass="btn-group btn-group-sm">
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
        </asp:Panel>
        <div class="text-center">
            <asp:Button ID="CreateGame" runat="server" OnClick="CreateGame_Click" CssClass="btn btn-success StartGameBtn" Text="Start Game" />
        </div>

    </fieldset>
</asp:Content>
