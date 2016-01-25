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
                        <asp:ImageButton ID="ArtCategory" runat="server" ImageUrl="~/images/art.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Art" CommandName="Art" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton ID="HistoryCategory" runat="server" ImageUrl="~/images/history.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="History" CommandName="History" />
                    </div>
                    <div class="col-md-4">
                        <asp:ImageButton ID="SportCategory" runat="server" ImageUrl="~/images/sport.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Sport" CommandName="Sport" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:ImageButton ID="SienceCategory" runat="server" ImageUrl="~/images/science.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Science" CommandName="Science" />
                    </div>
                    <div class="col-md-6">
                        <asp:ImageButton ID="EntertainmentCategory" runat="server" ImageUrl="~/images/entertainment.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Entertainment" CommandName="Entertainment" />
                    </div>
                </div>
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" SelectMethod="GetUsers">
            <Columns>
                <asp:ButtonField DataTextField="Username" HeaderText="Username" ButtonType="Button" CommandName="Select" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
                <asp:CommandField ShowSelectButton="True"   SelectText="Take" ControlStyle-CssClass="btn btn-success"/>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
