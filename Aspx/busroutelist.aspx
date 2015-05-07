<%@ Page Title="线路列表" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="busroutelist.aspx.cs" Inherits="Aspx_busroutelist" %>
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
                <asp:DataGrid ID="dgBusRoute" PageSize="5" OnEditCommand="dgBusRoute_EditCommand" OnPageIndexChanged="dgBusRoute_PageIndexChanged" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" HorizontalAlign="Left" CellPadding="2" runat="server" >
                    <Columns>
                        <asp:BoundColumn DataField="qmroute_id" HeaderText="编号"></asp:BoundColumn>
                        <asp:HyperLinkColumn Text="名称" Target="_blank" DataNavigateUrlField="qmroute_name" DataNavigateUrlFormatString="showbusdetail.aspx?busname={0}" DataTextField="qmroute_name" HeaderText="名称"></asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="qmroute_address" HeaderText="站点"></asp:BoundColumn>
                        <asp:EditCommandColumn EditText="编辑" ></asp:EditCommandColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                </asp:DataGrid>
           </td>
        </tr>
    </table>
</asp:Content>