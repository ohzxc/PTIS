<%@ Page Title="编辑线路" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="editbusroute.aspx.cs" Inherits="Aspx_editbusroute" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%=Title %></h1>
        <table>
        <tr>
            <td style="text-align:left;vertical-align:top;width:100px">
                <uc:admin runat="server" />
            </td>
            <td style="vertical-align:top">
                <label>公交名称：</label>        
                <asp:TextBox ID="txtBusName" runat="server" placeholder="59路" />
                <br />
                <label>站&nbsp &nbsp &nbsp &nbsp 点：</label>
                <asp:TextBox ID="txtRoute" runat="server" placeholder="站点一-站点二-站点三" Height="50px" Width="256px" TextMode="MultiLine" />
                <br />
                <asp:Button runat="server" ID="btnEdit" Text="确定修改" OnClick="btnEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
