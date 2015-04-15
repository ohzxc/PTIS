<%@ Page Title="chaxun" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="Aspx_user" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/user.js"></script>
    <script src="../Scripts/jquery.autocomplete.js" ></script>
    <script src="../Scripts/jquery.bgiframe.min.js"></script>
    <script src="../Scripts/jquery.js"></script>
    <script src="../Scripts/thickbox-compressed.js"></script>
    <link rel="stylesheet" href="../Style/jquery.autocomplete.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            var data = ["河北省", "河南省", "山东", "北京", "天津"];
            $("#textq").autocomplete("data");
        })
    </script>
    <div>
        
        <div style="display:inline" onmouseover="displayhc()">换乘查询</div>
        <div style="display:inline" onmouseover="displayxl()">线路查询</div>
        <div style="display:inline" onmouseover="displayzd()">站点查询</div>
        <div id="hcframe" style="display:block" >
            <input id="textq" type="text" />
            <input id="textqd" type="text" runat="server" placeholder="请输入起点"/>
            <input type="button" value="交换(待实现)" runat="server" onclick="btnExchange_Click" />
            <input id="textzd" type="text" runat="server" placeholder="请输入终点"/>
            <br />
            <asp:button ID="btnFind" runat="server" Text="查询" OnClick="btnFind_Click" />
        </div>
        <div id="xlframe" style="display:none"" >
            <input id="txtLineName" placeholder="请输入公交名称" runat="server"/>
            <br />
            <asp:button ID="Button1" runat="server" Text="查询1" OnClick="btnFind_Click1" />
        </div>
        <div id="zdframe" style="display:none"" >
            <input id="StationName" type="text" placeholder="请输入站点名称" runat="server" />
            <br />
            <asp:button ID="Button2" runat="server" Text="查询2" OnClick="btnFind_Click2" />
        </div>
        <iframe id="frmResult" runat="server" style="height: 500px; width: 500px" >

        </iframe>
<!--   <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <asp:button ID="btnTest" runat="server" Text="查询" OnClick="btnFind_Click" AutoPostBack="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
-->
    </div>
</asp:Content>
