<%@ Page Title="武汉市公共交通查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/StyleSheet.css" />
    <div class="jumbotron">
        <h1><%=Title %></h1>
        <p class="lead">提供武汉市公共交通基本查询和管理功能。</p>
        <div class="access" ><a href="Aspx/user">查询入口</a> <a href="Aspx/admin">管理入口</a></div>
    </div>
    
</asp:Content> 
