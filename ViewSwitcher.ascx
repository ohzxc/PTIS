<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewSwitcher.ascx.cs" Inherits="ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> 视图 | <a href="<%: SwitchUrl %>" data-ajax="false">切换视图 <%: AlternateView %></a>
</div>
