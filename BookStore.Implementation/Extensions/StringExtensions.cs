﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Extensions
{
    public static class StringExtensions
    {
        public static string GetFileExtension(this string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                default:
                    return string.Empty;
            }
        }
    }
}
