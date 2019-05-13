﻿<%@ Control Language="C#" AutoEventWireup="false" EnableViewState="false" Inherits="R7.Epsilon.Skins.SkinObjects.EpsilonSkinObjectBase" %>
<%@ Register TagPrefix="dnn" TagName="TAGS" Src="~/Admin/Skins/Tags.ascx" %>
<%@ Register TagPrefix="skin" TagName="PAGEINFO" Src="../SkinObjects/PageInfo.ascx" %>

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="skin-tags">
                <dnn:TAGS runat="server" AllowTagging="false" Separator=" " />
            </div>
        </div>
        <div class="col-md-12">
            <skin:PAGEINFO runat="server" />
        </div>
    </div>
</div>    