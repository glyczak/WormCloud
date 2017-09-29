using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WormCloud.Models
{
    public static class RoleName
    {
        public const string CanManageStrains = "CanManageStrains";
        public const string CanManageSamples = "CanManageSamples";

        public const string CanManageEverything = CanManageStrains + ", " + CanManageSamples;
    }
}