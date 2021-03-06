﻿<%@ Page Title="编辑线路信息" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="editbusinfo.aspx.cs" Inherits="Aspx_editbusinfo" %>
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
                <asp:TextBox ID="txtBusName" runat="server" placeholder="59路" ReadOnly="True" />
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
                <asp:Button runat="server" ID="btnEdit" Text="确定修改" OnClick="btnEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>