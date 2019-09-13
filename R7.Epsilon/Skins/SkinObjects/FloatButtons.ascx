﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="skin" TagName="FEEDBACKBUTTON" Src="~/Portals/_default/Skins/R7.Epsilon/SkinObjects/FeedbackButton.ascx" %>
<div class="skin-float-box-vertical">
	<a href="#" class="skin-float-btn skin-float-btn-up" style="display:none" title='<%: Localizer.GetString ("ButtonUp_Title.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<i class="fas fa-chevron-up"></i>
	</a>
	<a href='<%: Localizer.GetString ("AgeRating_Link.Text") %>' target="_blank" class="skin-float-btn skin-float-btn-age-rating"
			title='<%: Localizer.GetString ("AgeRating_Title.Text") %>' data-toggle="tooltip" data-placement="left" data-container="body">
		<%: Localizer.GetString ("AgeRating.Text") %>
	</a>
    <skin:FEEDBACKBUTTON runat="server" CssClass="skin-float-btn skin-float-btn-feedback" />
</div>
