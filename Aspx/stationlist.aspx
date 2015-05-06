<%@ Page Title="线路站点列表" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="stationlist.aspx.cs" Inherits="Aspx_stationlist" %>
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
               <asp:DataGrid ID="dgStationRoute" PageSize="10" OnPageIndexChanged="dgStationRoute_PageIndexChanged" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" HorizontalAlign="Left" CellPadding="2" runat="server">
                   <Columns>
                       <asp:BoundColumn DataField="qmstation_id" HeaderText="编号"></asp:BoundColumn>
                       <asp:BoundColumn DataField="qmstation_name" HeaderText="站名"></asp:BoundColumn>
                       <asp:BoundColumn DataField="qmstation_bus" HeaderText="经过的车次"></asp:BoundColumn>
                   </Columns>
                   <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
               </asp:DataGrid>
           </td>
       </tr>
    </table>
</asp:Content>