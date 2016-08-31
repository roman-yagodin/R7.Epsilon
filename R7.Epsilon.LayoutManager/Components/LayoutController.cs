﻿//
// LayoutController.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2016 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Data;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Entities.Portals;

namespace R7.Epsilon.LayoutManager.Components
{
    public static class LayoutController
    {
        public static string GetLayoutFileName (string name, int portalId)
        {
            var mapPath = (portalId == -1) 
                ? Globals.HostMapPath 
                : PortalController.Instance.GetPortal (portalId).HomeSystemDirectoryMapPath;

            return Path.Combine (mapPath, "Skins", "R7.Epsilon", "Layouts", name + ".xml");
        }

        public static bool IsLayoutInUse (string layoutName, int portalId)
        {
            using (var db = DataContext.Instance ()) {
                var sqlQuery = @"SELECT COUNT (*) FROM {databaseOwner}[{objectQualifier}TabSettings] AS TS
                    INNER JOIN {databaseOwner}[{objectQualifier}Tabs] AS T ON TS.TabID = T.TabID
                    WHERE T.PortalID = @0 AND TS.SettingName = @1 AND TS.SettingValue = @2";

                return 0 < db.ExecuteScalar<int> (CommandType.Text, sqlQuery, portalId, "r7_Epsilon_Layout", layoutName);
            }
        }
    }
}