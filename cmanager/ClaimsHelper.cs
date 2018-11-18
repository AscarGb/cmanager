using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace cmanager
{
    public static class ClaimsHelper
    {
        public static void Check(IEnumerable<string> claims)
        {
            foreach (var a in claims)
            {
                var arr = a.Split(':');
                if (arr.Length != 2)
                {
                    throw new Exception("Claims format error. Example Name:Tom Address:Ufa Phone:1234123 ");
                }
            }
        }

        public static IEnumerable<Claim> Parse(IEnumerable<string> claims)
        {
            foreach (var a in claims)
            {
                var arr = a.Split(':');
                if (arr.Length == 2)
                    yield return new Claim(arr[0], arr[1]);
            }
        }
    }
}
