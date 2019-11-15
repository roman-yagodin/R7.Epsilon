﻿//
//  File: SecondaryMenu.ascx.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
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
using System.Collections.Generic;
using R7.Epsilon.Components;
using DotNetNuke.Web.DDRMenu.TemplateEngine;
using DDRMenu = DotNetNuke.Web.DDRMenu;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class SecondaryMenu: EpsilonMenuBase
    {
        #region Controls

        protected DDRMenu.SkinObject menuSecondary;

        #endregion

        protected override void OnInit (EventArgs e)
        {
            Menu = menuSecondary;
            Menu.NodeSelector = Config.SecondaryMenu.NodeSelector;
            Menu.IncludeNodes = Config.SecondaryMenu.IncludeNodes;
            Menu.ExcludeNodes = Config.SecondaryMenu.ExcludeNodes;

            if (Menu.TemplateArguments == null) {
                Menu.TemplateArguments = new List<TemplateArgument> ();
            }

            Menu.TemplateArguments.Add (new TemplateArgument ("UrlFormat", Config.SecondaryMenu.UrlFormat));

            if (Config.SecondaryMenu.NodeManipulators.Count > 0) {
                Menu.NodeManipulator = typeof (EpsilonSecondaryMenuNodeManipulator).FullName;
            }

            base.OnInit (e);
        }
    }
}
