using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk_Prototype.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// 숫자를 통화 형식의 문자열로 변환합니다.
        /// </summary>
        /// <typeparam name="T">숫자 타입 (int, decimal, double, float, long 등)</typeparam>
        /// <param name="value">변환할 숫자 값</param>
        /// <returns>통화 형식의 문자열</returns>
        public static string ToCurrency<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
        {
            // 숫자 타입인지 확인
            if (!typeof(T).IsPrimitive && typeof(T) != typeof(decimal))
            {
                throw new ArgumentException("This method is only supported for numeric types.");
            }

            // 숫자를 decimal로 변환하여 통화 형식으로 포맷팅
            decimal decimalValue = Convert.ToDecimal(value);
            return $"{decimalValue:#,##0}";
        }
    }
}
