using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger
{
    internal static class Extensions
    {
        //Strip accents from unicode characters and convert them to their ascii equivalents (so romanian <sh> <tz> become s and t)
        public static string NormalizeStripAccents(this string str)
        {
            return string.Concat(str.ToLower().Normalize(NormalizationForm.FormD).Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
        }
    }
}
