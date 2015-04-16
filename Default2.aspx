<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1" ServicePath="~/WebService.asmx" CompletionSetCount="10" MinimumPrefixLength="1" ServiceMethod="GetTextString"></cc1:AutoCompleteExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>        
    </div>
    </form>
</body>
</html>
