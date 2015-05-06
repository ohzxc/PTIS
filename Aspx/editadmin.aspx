<%@ Page Title="修改管理员信息" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="editadmin.aspx.cs" Inherits="Aspx_editadmin" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%=Title %></h1>
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
                <asp:Button runat="server" ID="btnEdit" Text="确定修改" OnClick="btnEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>