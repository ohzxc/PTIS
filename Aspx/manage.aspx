<%@ Page Title="后台管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="Aspx_manage" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<script src="../Scripts/user.js"></script>-->
    <h1><%=Title %></h1>
    <table>
       <tr>
           <td style="text-align:left;vertical-align:top;width:100px">
               <uc:admin runat="server" />
           </td>
           <td style="vertical-align:top">
               <label>欢迎来到公交信息管理平台，
                   <br />请点击左侧导航进行管理。
               </label>
           </td>
       </tr>
   </table>
</asp:Content>