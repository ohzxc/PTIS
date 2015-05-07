<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminguide.ascx.cs" Inherits="Controls_adminguide" %>
<div>
    <label>线路管理</label>
    <br />
    <a href="addbus">添加线路</a>
    <br />
    <a href="businfolist">线路信息列表</a>
    <br />
    <a href="busroutelist">线路列表</a>
    <br />
    <a href="stationlist">线路站点列表</a>
    <br />
    <label>账户管理</label>
    <br />
    <a href="adminlist">管理员列表</a>
    <br />
    <a href="addadmin">添加管理员</a>
    <br />
    <asp:button Font-Size="Small" Font-Bold="true" ID="btnSignout" runat="server" Text="退出登录" OnClick="btnSignout_Click" style="height: 21px" />
</div>
    