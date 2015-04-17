<%@ Page Title="chaxun" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="Aspx_user" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/user.js"></script>
    <div>   
        <div style="display:inline" onclick="displayhc()">换乘（站站）查询|</div>
        <div style="display:inline" onclick="displayxl()">线路查询|</div>
        <div style="display:inline" onclick="displayzd()">站点查询</div>
        <div id="hcframe" style="display:none" >
            <asp:TextBox ID="textqd" runat="server" placeholder="请输入起点"/>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="textqd" ServicePath="~/WebService.asmx" ServiceMethod="GetTextString" CompletionSetCount="10" MinimumPrefixLength="1"></cc1:AutoCompleteExtender>
            <input type="button" value="交换(待实现)" runat="server" onclick="btnExchange_Click" />
            <asp:TextBox ID="textzd" runat="server" placeholder="请输入终点"/>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="textzd" ServicePath="~/WebService.asmx" ServiceMethod="GetTextString" CompletionSetCount="10" MinimumPrefixLength="1"></cc1:AutoCompleteExtender>
            <br />
            <asp:button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" />
        </div>
        <div id="xlframe" style="display:none"" >
            <asp:TextBox ID="txtLineName" placeholder="请输入公交名称" runat="server"/>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtLineName" ServicePath="~/WebService.asmx" ServiceMethod="GetTextString2" CompletionSetCount="10" MinimumPrefixLength="1"></cc1:AutoCompleteExtender>
            <br />
            <asp:button ID="Button1" runat="server" Text="查询1" OnClick="btnFind_Click1" />
        </div>
        <div id="zdframe" style="display:block"" >
            <asp:TextBox ID="StationName" placeholder="请输入站点" runat="server" />
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="StationName" ServicePath="~/WebService.asmx" ServiceMethod="GetTextString" CompletionSetCount="10" MinimumPrefixLength="1"></cc1:AutoCompleteExtender>
            <br />
            <asp:button ID="Button2" runat="server" Text="查询2" OnClick="btnFind_Click2" />
        </div>
        <iframe id="frmResult" runat="server" style="height: 300px; width: 500px; border: none" ></iframe>
<!--   <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <asp:button ID="btnTest" runat="server" Text="查询" OnClick="btnFind_Click" AutoPostBack="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
-->
    </div>
</asp:Content>
