<%@ Page Title="添加公交" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="addbus.aspx.cs" Inherits="Aspx_addbus" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%=Title %></h1>
        <table>
        <tr>
            <td style="text-align:left;vertical-align:top;width:100px">
                <uc:admin runat="server" />
            </td>
            <td>
                <label>公交名称：</label>        
                <asp:TextBox ID="txtBusName" runat="server" placeholder="59路" />
                <br />
                <label>公交类型：</label>
                <asp:DropDownList ID="ddlBusClass" runat="server">
                    <asp:ListItem Value="城区普线" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="郊区普线"></asp:ListItem>
                    <asp:ListItem Value="旅游线路"></asp:ListItem>
                    <asp:ListItem Value="城区专线"></asp:ListItem>
                    <asp:ListItem Value="远城区线"></asp:ListItem>
                    <asp:ListItem Value="无轨电车"></asp:ListItem>
                    <asp:ListItem Value="轨道交通"></asp:ListItem>
                    <asp:ListItem Value="轮渡"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <label>票&nbsp &nbsp &nbsp &nbsp 制：</label>
                <asp:DropDownList ID="ddlRatebz" runat="server">
                    <asp:ListItem Value="一票制" Selected ="True"></asp:ListItem>
                    <asp:ListItem Value="梯形票价"></asp:ListItem>
                    <asp:ListItem Value="按里程"></asp:ListItem>
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
                <br />
            <asp:Button runat="server" ID="btnAdd" Text="确定添加" OnClick="btnAdd_Click" />
            <asp:Button runat="server" ID="btnReturn" Text="返回"  OnClick="btnReturn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>