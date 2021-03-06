﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Karkas.Core.DataUtil.Exceptions
{
    [Serializable]
    public class YanlisSqlCumlesiHatasi : KarkasVeriHatasi
    {
        public YanlisSqlCumlesiHatasi()
            : base()
        {

        }
        public YanlisSqlCumlesiHatasi(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }
        public YanlisSqlCumlesiHatasi(string pMessage)
            : base(pMessage)
        {

        }
        public YanlisSqlCumlesiHatasi(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }

    }
}

