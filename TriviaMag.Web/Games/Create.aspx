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
                        <asp:ImageButton ID="SportCategory" runat="server" ImageUrl="~/images/sport.png" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Sport" CommandName="Sport" />
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
        <asp:GridView
            ID="GridView1"
            runat="server"
            DataKeyNames="Id"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateColumns="False"
            SelectMethod="GetUsers"
            OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
                <asp:ButtonField HeaderText="Choice" ButtonType="Button" CommandName="Select" Text="Take" ControlStyle-CssClass="btn btn-info" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="CreateGame" runat="server"  CssClass="btn btn-success" Text="Create Game" OnClick="CreateGame_Click"/>
    </fieldset>
</asp:Content>
