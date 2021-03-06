﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    public class NameSqlFragment : ContainerSqlFragment
    {

        private String _name;

        public NameSqlFragment(String name)
        {
            if (name == null)
            {
                throw new ArgumentException("Name must be specified");
            }
            _name = name;
        }

        //-------------------------------------------------------------------------
        /**
         * Gets the name of the fragment.
         * 
         * @return the name, not null
         */
        public String getName()
        {
            return _name;
        }

        //-------------------------------------------------------------------------
        public override String ToString()
        {
            return GetType().Name + ":" + _name + " " + getFragments();
        }

    }
}
