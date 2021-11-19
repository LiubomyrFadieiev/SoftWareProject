using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WinForm
{
    public static class ConnectionString
    {
        public static readonly string connString = ConfigurationManager.ConnectionStrings["Auction"].ConnectionString;
    }
}
