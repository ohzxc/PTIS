<%@ Page Title="guanli" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="Aspx_admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <label>用户名</label>
    <asp:TextBox ID="txtUserName" runat="server" type="text" />
    <br />
    <label>密码</label>
    <asp:TextBox ID="textPswd" runat="server" TextMode="Password" />
    <br />
    <asp:Button ID="btnLogin" Text="登陆" runat="server" OnClick="btnlogin_Click" />

</asp:Content>