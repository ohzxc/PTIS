<%@ Page Title="联系方式" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1><%: Title %>.</h1>
        <h2>Zhouxc Studio</h2>
        <address>
            湖北武汉鲁磨路<br />
            388号，中国地质大学<br />
        </address>
        <address>
            <strong>联系:</strong>   <a href="mailto:zhouxc@qq.com">zhouxc@qq.com</a><br />
        </address>
    </div>
</asp:Content>