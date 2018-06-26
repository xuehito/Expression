using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCal.Service
{
    /// <summary>
    /// 表达式计算
    /// </summary>
    public class ExpressionCal
    {
        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expressionStr">表达式</param>
        /// <param name="returnVal">返回值</param>
        /// <returns></returns>
        public static MessageResult CalExpression(Context context, string expressionStr, string returnVal)
        {
            if (string.IsNullOrEmpty(expressionStr))
            {
                var msg = "表达式为空";
                return MessageResult.FailMsg(msg);
            }

            return null;
        }
    }
}
