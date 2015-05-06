<%@ Page Title="线路信息列表" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="businfolist.aspx.cs" Inherits="Aspx_businfolist" %>
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
           <td> 
                <asp:DataGrid ID="dgBusInfo" PageSize="5" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" HorizontalAlign="Left" CellPadding="2" runat="server" OnEditCommand="dgBusInfo_EditCommand" OnItemCommand="dgBusInfo_ItemCommand" OnPageIndexChanged="dgBusInfo_PageIndexChanged">
                    <Columns>
                        <asp:BoundColumn DataField="qmbus_id" HeaderText="编号"></asp:BoundColumn>
                        <asp:HyperLinkColumn Text="名称" Target="_blank" DataNavigateUrlField="qmbus_name" DataNavigateUrlFormatString="showbusdetail.aspx?busname={0}" DataTextField="qmbus_name" HeaderText="名称"></asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="qmbus_ratebz" HeaderText="票制"></asp:BoundColumn>
                        <asp:BoundColumn DataField="qmbus_rate" HeaderText="费用（元）"></asp:BoundColumn>
                        <asp:BoundColumn DataField="qmbus_starttime" HeaderText="首班时间"></asp:BoundColumn>
                        <asp:BoundColumn DataField="qmbus_endtime" HeaderText="末班时间"></asp:BoundColumn>
                        <asp:EditCommandColumn EditText="编辑" ></asp:EditCommandColumn>
                        <asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                </asp:DataGrid>
           </td>
        </tr>
    </table>
</asp:Content>