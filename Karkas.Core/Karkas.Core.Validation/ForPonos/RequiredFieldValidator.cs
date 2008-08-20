using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class RequiredFieldValidator : BaseOnaylayici
    {
        public RequiredFieldValidator(object pUzerindeCalisilacakNesne,string pPropertyName) : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
        }
        public RequiredFieldValidator(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
        }


        public override bool IslemYap(object instance, object fieldValue)
        {
            return fieldValue != null && fieldValue.ToString().Length != 0;
        }

        protected override string HataMesajlariniOlustur()
        {
            return String.Format("{0} Gereklidir.", Property.Name);
        }



    }
}
