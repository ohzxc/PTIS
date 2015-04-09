<%@ Page Title="删除路线" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="deletebus.aspx.cs" Inherits="Aspx_deletebus" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>删除公交路线</h1>
    <div>
        <br />
        <label>公交名称：</label>
        <asp:TextBox ID="txtBusName" runat="server" placeholder="59路" />
        <br />
        <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" />
        <asp:button runat="server" ID="btnReturn" Text="返回" OnClick="btnReturn_Click" />
    </div>
</asp:Content>