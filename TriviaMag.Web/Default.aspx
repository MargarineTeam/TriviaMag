<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TriviaMag.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="text-center">
        <div class="row">
        <a href="Games/Create.aspx" class="btn btn-success btn-lg playGamebtn">Play</a>

        </div>
        <img src="images/triviamagHome.png" />
        <h1 style="color: #4F3F50;" class="homeMag">Mag</h1>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12 text-center">
            <h2 style="color: #353654" class="gettingStarted">The coolest game online... if you are <span style="color: #F8969C;">SMART</span></h2>
            <h1 style="color: #353654" class="gettingStarted">enough!</h1>
        </div>
        <br />
        <br />
        <br />
        <br />
        <asp:LoginView ID="LoginView2" runat="server" ViewStateMode="Disabled">
            <LoggedInTemplate>
                <div class="text-center">
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
