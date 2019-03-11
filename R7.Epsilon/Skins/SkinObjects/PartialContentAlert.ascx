﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%
var moduleId = default (int?);
if (!string.IsNullOrEmpty (Request.QueryString ["mid"])) {
	moduleId = int.Parse (Request.QueryString ["mid"]);
}
else if (!string.IsNullOrEmpty (Request.QueryString ["moduleid"])) {
	moduleId = int.Parse (Request.QueryString ["moduleid"]);
}
if (moduleId != null && string.IsNullOrEmpty (Request.QueryString ["ctl"])) {
	var content = Localizer.GetString ("PartialContentAlert.Content");
	content = content.Replace ("[TabUrl]",  DotNetNuke.Common.Globals.NavigateURL (PortalSettings.ActiveTab.TabID));
	content = content.Replace ("[TabName]", PortalSettings.ActiveTab.TabName);
	content = content.Replace ("[ModuleId]", moduleId.ToString ());
%>
<div class="row">
	<div class="col-md-12">
		<div class="alert alert-info">
			<h4><%= Localizer.GetString ("PartialContentAlert.Title") %></h4>
			<%= content %>
		</div>
	</div>
</div>
<% } %>