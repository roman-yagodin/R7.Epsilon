﻿//
//  BannerLoader.ascx.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2017 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Log.EventLog;

namespace R7.Epsilon.Skins.SkinObjects.Banners
{
    public class BannerLoader: EpsilonSkinObjectBase, IBannerControl
    {
        #region Controls

        protected PlaceHolder placeBanner;

        #endregion

        #region IBannerControl implementation

        public string GroupName { get; set; }

        public int BannerTypeId { get; set; }

        public int BannerCount { get; set; }

        public char Orientation { get; set; }

        #endregion

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);

            try {
                var bannerWrapper = (BannerWrapper) LoadControl (PortalSettings.ActiveTab.SkinPath
                                                                 + "/SkinObjects/Banners/BannerWrapper.ascx");
                bannerWrapper.GroupName = GroupName;
                bannerWrapper.BannerTypeId = BannerTypeId;
                bannerWrapper.BannerCount = BannerCount;
                bannerWrapper.Orientation = Orientation;
                bannerWrapper.DataBind ();
                placeBanner.Controls.Add (bannerWrapper);
            }
            catch {
                EventLogController.Instance.AddLog ("Message", GetType ().BaseType.FullName
                                                    + " cannot load '~/admin/Skins/banner.ascx' skinobject, please check project readme for details.",
                                                    EventLogController.EventLogType.HOST_ALERT
                );
            }
        }
    }
}
