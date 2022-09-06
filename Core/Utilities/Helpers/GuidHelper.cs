using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
