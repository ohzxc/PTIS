<%@ Page Title="联系方式" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1><%: Title %>.</h1>
        <p>Zhouxc Studio</p>
        <address>
            湖北武汉鲁磨路388号<br />
            中国地质大学<br />
            <strong>Email:</strong>   
            <a href="mailto:zhouxc@qq.com">zhouxc@qq.com</a><br />
        </address>
    </div>
</asp:Content>