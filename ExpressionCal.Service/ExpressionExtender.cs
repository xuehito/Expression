using System.Text;

namespace ExpressionCal.Service
{
    public class ExpressionExtender
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expressionStr"></param>
        /// <param name="returnVal"></param>
        /// <returns></returns>
        public static string ExpreExtender(Context context, string expressionStr, string returnVal)
        {
            var sbCode = new StringBuilder();
            sbCode.AppendLine("using System;"); //namespace 使用声明
            sbCode.AppendLine("using System.Collections.Generic;");
            sbCode.AppendLine("using Expression.Service.Model;"); //引用实体对象
            sbCode.AppendLine("using Expression.Service;"); //引入表达式计算类库
            sbCode.AppendLine("namespace ExpressionCal.Service"); //默认名称空间

            sbCode.AppendLine("{");
            sbCode.AppendLine(" public class Expression");
            sbCode.AppendLine(" {");
            sbCode.Append(
                " public object Compute(string sn,string systemId,string workflowCode,string activityCode,string procInstId,string folio,string bizObjectId)");
            sbCode.AppendLine(" {");

            if (expressionStr.Contains("US."))
                sbCode.Append(
                    " UserService US=new UserService(sn,systemId,workflowCode,activityCode,procInstId,folio,bizObjectId);");

            //其他可自行扩展

            sbCode.AppendLine(expressionStr);
            sbCode.AppendLine(" return " + returnVal + ";");
            sbCode.AppendLine(" }");
            sbCode.AppendLine(" }");
            sbCode.AppendLine("}");
            return sbCode.ToString();
        }
    }
}