<%@ Control  AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs" Inherits="TriviaMag.Web.Controls.FileUpload" %>

<asp:FileUpload ID="ImageUpload" runat="server"/>
<asp:RequiredFieldValidator ID="RequiredFieldImage" Visible="false" ControlToValidate="ImageUpload" CssClass="label label-danger pull-righ" ErrorMessage="Image is required!" Display="Dynamic" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>