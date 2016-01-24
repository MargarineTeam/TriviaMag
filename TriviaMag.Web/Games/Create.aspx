<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TriviaMag.Web.Games.Create" %>

<asp:Content ID="Create" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Create Game</legend>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3>Choose Category</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:ImageButton ID="ArtCategory" runat="server" ImageUrl="~/images/art.jpg" CssClass="img-responsive" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton ID="HistoryCategory" runat="server" ImageUrl="~/images/history.jpg" CssClass="img-responsive" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton ID="SportCategory" runat="server" ImageUrl="~/images/sport.png" CssClass="img-responsive" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:ImageButton ID="SienceCategory" runat="server" ImageUrl="~/images/science.jpg" CssClass="img-responsive" />
                    </div>
                    <div class="col-md-6">
                        <asp:ImageButton ID="EntertainmentCategory" runat="server" ImageUrl="~/images/entertainment.jpg" CssClass="img-responsive" />
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" SelectMethod="GetUsers">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            </Columns>
        </asp:GridView>
        <div class="form-group row">
            <div class="col-md-1">
                <asp:Label ID="CategoryLabel" runat="server" AssociatedControlID="CategoryDropdown" CssClass="control-label">Category:</asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="CategoryDropdown" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Text="- Select category -" />
                </asp:DropDownList>
            </div>
        </div>
    </fieldset>
</asp:Content>
