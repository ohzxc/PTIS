<%@ Page Title="联系方式" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Zhouxc Studio</h3>
    <address>
        湖北武汉鲁磨路<br />
        388号，中国地质大学<br />
        <abbr title="Phone">电话:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>联系:</strong>   <a href="mailto:zhouxc@qq.com">zhouxc@qq.com</a><br />
    </address>
</asp:Content>