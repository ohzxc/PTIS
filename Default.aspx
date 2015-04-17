<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>武汉公共交通查询</h1>
        <p class="lead">提供武汉市公共交通基本查询和管理功能。</p>
    </div>
    <div ><a style="background-color:black" href="Aspx/user">查询入口</a> <a href="Aspx/admin">管理入口</a></div>
</asp:Content>
