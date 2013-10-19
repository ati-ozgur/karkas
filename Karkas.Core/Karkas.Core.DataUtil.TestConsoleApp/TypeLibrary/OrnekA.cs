﻿using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;

namespace Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary
{
    public partial class OrnekA : BaseTypeLibrary
    {
        private short shortDegisken;

        public short ShortDegisken
        {
            get { return shortDegisken; }
            set { shortDegisken = value; }
        }


        private string emailDegisken;

        public string EmailDegisken
        {
            get { return emailDegisken; }
            set { emailDegisken = value; }
        }
	

    }
}

