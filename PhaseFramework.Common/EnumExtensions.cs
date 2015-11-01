using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace PhaseFramework.Common
{
    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { Id = e, Name = e.ToString(CultureInfo.InvariantCulture) };

            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}
