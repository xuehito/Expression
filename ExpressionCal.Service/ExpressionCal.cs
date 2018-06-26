using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace ExpressionCal.Service
{
    /// <summary>
    ///     表达式计算
    /// </summary>
    public class ExpressionCal
    {
        /// <summary>
        ///     计算表达式
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expressionStr">表达式</param>
        /// <param name="returnVal">返回值</param>
        /// <returns></returns>
        public static MessageResult ExpreCal(Context context, string expressionStr, string returnVal)
        {
            if (string.IsNullOrEmpty(expressionStr))
            {
                var msg = "表达式为空";
                return MessageResult.FailMsg(msg);
            }

            var dllExcutePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            // 编译器 
            var cdp = CodeDomProvider.CreateProvider("C#");
            // 编译器的参数 
            var cp = new CompilerParameters();

            #region dll引用

            cp.ReferencedAssemblies.Add("System.dll"); //引用系统dll
            cp.ReferencedAssemblies.Add("System.Configuration.dll"); //引用系统dll
            cp.ReferencedAssemblies.Add(string.Format("{0}\\{1}.dll", dllExcutePath, "Expression.Service")); //引用自定义dll

            #endregion

            cp.GenerateExecutable = false; //不生成exe文件
            cp.GenerateInMemory = true; //操作内存

            CompilerResults cr = null;
            try
            {
                // 编译C#代码 
                cr = cdp.CompileAssemblyFromSource(cp,
                    ExpressionExtender.ExpreExtender(context, expressionStr, returnVal));
            }
            catch (Exception ex)
            {
                //cp.GenerateExecutable = false; //不生成exe文件
                //cp.GenerateInMemory = true; //生成dll
                //cr = cdp.CompileAssemblyFromSource(cp,
                //    ExpressionExtender.ExpreExtender(context, expressionStr, returnVal));
            }
            if (cr.Errors.HasErrors)
            {
            }
            else
            {
                ExpreExec(cr.CompiledAssembly, context);
            }
            return null;
        }

        /// <summary>
        ///     执行表达式
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="context"></param>
        public static MessageResult ExpreExec(Assembly assembly, Context context)
        {
            MessageResult result;
            try
            {
                var express = assembly.CreateInstance("ExpressionCal.Service.Expression");

                if (express != null)
                {
                    var type = express.GetType();

                    var mi = type.GetMethod("Compute");
                    var array = new object[]
                    {
                        context.SN,
                        context.SystemId == null ? Guid.Empty.ToString() : context.SystemId.ToString(),
                        context.WorkflowCode,
                        context.ActivityCode,
                        context.ProcInstId,
                        context.Folio,
                        context.BizObjectId == null ? Guid.Empty.ToString() : context.BizObjectId.ToString()
                    };

                    var bussData = mi.Invoke(express, array);
                    var msg = "表达式执行成功";
                    result = MessageResult.SuccessMsg(bussData);
                }
                else
                {
                    var msg = "表达式执行失败,express 为空";
                    result = MessageResult.FailMsg(msg);
                }
            }
            catch (Exception ex)
            {
                var msg = "表达式执行异常,异常原因:" + ex.Message;
                result = MessageResult.FailMsg(msg);
            }

            return result;
        }
    }
}