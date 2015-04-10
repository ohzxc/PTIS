<%@ Page Title="添加管理员" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="addadmin.aspx.cs" Inherits="Aspx_addadmin" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>添加管理员</h1>
        <table>
        <tr>
            <td style="text-align:left;vertical-align:top;width:100px">
                <uc:admin runat="server" />
            </td>
            <td style="vertical-align:top">
                <label>用户名：</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <br />
                <label>昵&nbsp 称：</label>
                <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                <br />
                <label>密&nbsp 码：</label>
                <asp:TextBox ID="txtPSWD" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnAdd" Text="确定添加" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>