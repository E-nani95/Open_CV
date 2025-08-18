using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk_Prototype.Extensions
{
    /// <summary>
    /// 문자열 확장 메서드를 제공하는 클래스입니다.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 문자열을 오른쪽으로 지정된 바이트 수만큼 패딩합니다.
        /// </summary>
        /// <param name="input">패딩할 문자열입니다.</param>
        /// <param name="maxBytes">최대 바이트 수입니다.</param>
        /// <returns>패딩된 문자열을 반환합니다.</returns>
        public static string PadByteRight(this string input, int maxBytes)
        {
            return PadByByteLength(input, maxBytes, padLeft: false);
        }

        /// <summary>
        /// 문자열을 왼쪽으로 지정된 바이트 수만큼 패딩합니다.
        /// </summary>
        /// <param name="input">패딩할 문자열입니다.</param>
        /// <param name="maxBytes">최대 바이트 수입니다.</param>
        /// <returns>패딩된 문자열을 반환합니다.</returns>
        public static string PadByteLeft(this string input, int maxBytes)
        {
            return PadByByteLength(input, maxBytes, padLeft: true);
        }

        /// <summary>
        /// 문자열을 지정된 바이트 수만큼 패딩합니다.
        /// </summary>
        /// <param name="input">패딩할 문자열입니다.</param>
        /// <param name="maxBytes">최대 바이트 수입니다.</param>
        /// <param name="padLeft">왼쪽으로 패딩할지 여부를 나타냅니다.</param>
        /// <returns>패딩된 문자열을 반환합니다.</returns>
        static string PadByByteLength(string input, int maxBytes, bool padLeft)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(949);
            int byteCount = 0;
            StringBuilder result = new StringBuilder();

            // 문자열 잘라내기
            foreach (char c in input)
            {
                int charBytes = encoding.GetByteCount(new char[] { c });
                if (byteCount + charBytes > maxBytes)
                {
                    break;
                }

                byteCount += charBytes;
                result.Append(c);
            }

            // 남은 바이트 계산 및 패딩 추가
            int paddingBytes = maxBytes - byteCount;
            string padding = new string(' ', paddingBytes / encoding.GetByteCount(" "));

            return padLeft ? padding + result.ToString() : result.ToString() + padding;
        }
    }
}
