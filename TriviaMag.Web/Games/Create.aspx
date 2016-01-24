<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="TriviaMag.Web.Games.Create" %>

<asp:Content ID="Create" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Create Game</legend>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TriviaMagConnectionString %>" SelectCommand="SELECT [UserName] FROM [AspNetUsers] ORDER BY [UserName]"></asp:SqlDataSource>--%>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" SelectMethod="GetUsers">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            </Columns>
        </asp:GridView>
       <%-- <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="">
        </asp:LinqDataSource>--%>
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
