<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TriviaMag.Web.Games.Create" %>

<asp:Content ID="Create" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Create Game</legend>
        <asp:Panel ID="DivLabelErrorMessage" runat="server" Visible="false" CssClass="text-center">
            <asp:Label ID="LabelErrorMessage" runat="server" ClientIDMode="static" CssClass="label label-danger"></asp:Label>
        </asp:Panel>
        <br/>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 style="max-height: 7px">Choose Category</h3>
            </div>
            <div class="panel-body fixed-panel">
                <div class="row" style="max-height: 50px">
                    <div class="col-md-2">
                        <asp:ImageButton ID="ArtCategory" runat="server" ImageUrl="~/images/art.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Art" CommandName="Art" />
                    </div>
                    <div class="col-md-2">
                        <asp:ImageButton ID="HistoryCategory" runat="server" ImageUrl="~/images/history.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="History" CommandName="History" />
                    </div>
                    <div class="col-md-3">
                        <asp:ImageButton ID="SportCategory" runat="server" ImageUrl="~/images/sport.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Sport" CommandName="Sport" />
                    </div>
                    <div class="col-md-2">
                        <asp:ImageButton ID="SienceCategory" runat="server" ImageUrl="~/images/science.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Science" CommandName="Science" />
                    </div>
                    <div class="col-md-2">
                        <asp:ImageButton ID="EntertainmentCategory" runat="server" ImageUrl="~/images/entertainment.jpg" CssClass="img-responsive" OnClick="ChooseCategory" CommandArgument="Entertainment" CommandName="Entertainment" />
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 style="max-height: 7px">Choose Opponent</h3>
            </div>
            <div class="panel-body fixed-panel">
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
            </div>
        </div>
        <asp:Button ID="CreateGame" runat="server" OnClick="CreateGame_Click" CssClass="btn btn-success" Text="Create Game" />
    </fieldset>
</asp:Content>
