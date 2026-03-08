using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DietitianFlow.Helpers
{
    public static class SessionHelper
    {
        public static uc_Dietitian GetActiveDietitian(HttpSessionStateBase session)
        {
            if (session==null)
            {
                return null;
            }
            return session["Admin"] as uc_Dietitian
                   ?? session["Dietitian"] as uc_Dietitian;

        }
        public static bool IsAuthenticated(HttpSessionStateBase session)
        {
            return GetActiveDietitian(session) != null;
        }
    }
}