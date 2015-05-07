<%@ Page Title="管理员列表" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="adminlist.aspx.cs" Inherits="Aspx_adminlist" %>
<%@ Register TagPrefix="uc" TagName="admin" Src="~/Controls/adminguide.ascx" %>
<asp:Content ID="BadyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        tr{background-color:#fff;}
        .alt{background-color:#ccc;}
    </style>
    <script>
        $(document).ready(function () {
            $('tr:odd').addClass('alt');
        });
    </script>
    <h1><%=Title %></h1>
    <table>
       <tr>
           <td style="text-align:left;vertical-align:top;width:100px">
               <uc:admin runat="server" />
           </td> 
           <td style="vertical-align:top">
               <asp:DataGrid ID="dgAdmin" PageSize="5" OnEditCommand="dgAdmin_EditCommand" OnPageIndexChanged="dgAdmin_PageIndexChanged" AutoGenerateColumns="False" OnItemCommand="dgAdmin_ItemCommand" AllowPaging="True" AllowSorting="True" HorizontalAlign="Left" CellPadding="2" runat="server">
                   <Columns>
                       <asp:BoundColumn DataField="qmadmin_id" HeaderText="编号"></asp:BoundColumn>
                       <asp:BoundColumn DataField="qmadmin_user" HeaderText="用户名"></asp:BoundColumn>
                       <asp:BoundColumn DataField="qmadmin_name" HeaderText="用户昵称"></asp:BoundColumn>
                       <asp:EditCommandColumn EditText="编辑"></asp:EditCommandColumn>
                       <asp:ButtonColumn CommandName="Delete" Text="删除"></asp:ButtonColumn>
                   </Columns>
                   <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
               </asp:DataGrid>
           </td>
       </tr>
    </table>
</asp:Content>