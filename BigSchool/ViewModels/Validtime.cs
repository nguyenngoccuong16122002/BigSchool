using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class Validtime:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isVaild = DateTime.TryParseExact(Convert.ToString(value),
                 "dd/M/yyy",
                 CultureInfo.CurrentCulture,
                 DateTimeStyles.None,
                 out dateTime
                );
            return isVaild;
        }
    }
}