<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<script src="../Scripts/jquery.autocomplete.js" ></script>
    <script src="../Scripts/jquery.bgiframe.min.js"></script>
    <script src="../Scripts/jquery.js"></script>
    <script src="../Scripts/thickbox-compressed.js"></script>
    <link rel="stylesheet" href="../Style/jquery.autocomplete.css" />
<script type="text/javascript">
    $(document).ready((function () {
        var data = ["河北省", "河南省", "山东", "山西", "天津"];
        $("#txtProvince").autocomplete(data);
    }
    ));
</script>
<body> 
<form id="form1" runat="server"> 
<div> 
省份：<input id="txtProvince" type="text" /> 
</div> 
<div> 
用户名：<input id="txtUser" type="text" /></div> 
</form> 
</body> 
</html>