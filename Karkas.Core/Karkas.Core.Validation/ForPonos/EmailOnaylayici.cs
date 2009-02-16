﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Onaylama.ForPonos
{
    public class EmailOnaylayici : RegExOnaylayici
    {
        // Fields
        protected const string REGEX_ONLY_CHARACTER = @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$";

        // Methods
        public EmailOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName, @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$", RegexOptions.None)
        {
        }

        public EmailOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$", RegexOptions.None, pErrorMessage)
        {
        }

        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} düzgün bir email değildir.", base.Property.Name);
        }
    }

 

}

