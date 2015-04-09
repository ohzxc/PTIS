<%@ Page Title="修改公交信息" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="updatebus.aspx.cs" Inherits="Aspx_updatebus" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>修改公交信息</h1>
    <div>
        <label>选择公交：</label>
        <asp:DropDownList ID="ddlBusName" runat="server" Width="150" ></asp:DropDownList>
        <br />
        <label>公交类型：</label>
        <asp:DropDownList ID="ddlBusClass" runat="server">
            <asp:ListItem Value="普线车" Selected="True"></asp:ListItem>
            <asp:ListItem Value="专线车"></asp:ListItem>
            <asp:ListItem Value="无轨电车"></asp:ListItem>
            <asp:ListItem Value="轨道交通"></asp:ListItem>
            <asp:ListItem Value="轮渡"></asp:ListItem>        
        </asp:DropDownList>
        <br />
        <label>票&nbsp &nbsp &nbsp &nbsp 制：</label>
        <asp:DropDownList ID="ddlRatebz" runat="server">
            <asp:ListItem Value="请选择" Selected ="True"></asp:ListItem>
            <asp:ListItem Value="一票制"></asp:ListItem>
            <asp:ListItem Value="其它"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <label>补充说明：</label>
        <asp:TextBox ID="txtRate" runat="server"/>
        <br />
        <label>运行时间：</label>
        <asp:TextBox ID="txtStartTime" runat="server" placeholder="06:00" />&nbsp 到&nbsp 
        <asp:TextBox ID="txtEndTime" runat="server" placeholder="21:00"/>
        <br />
        <label>站&nbsp &nbsp &nbsp &nbsp 点：</label>
        <asp:TextBox ID="txtRoute" runat="server" placeholder="站点一-站点二-站点三" Height="50px" Width="256px" />
    </div>
    <asp:Button ID="btnUpdate" runat="server" Text="确定" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnReturn" runat="server" Text="取消" />
</asp:Content>
