using System;
using Expression.Service.Common;
using Expression.Service.DBServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expression.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUserInfo()
        {
            Context context = null;
            var userCode = "1010";
            var info=SysDBServer.SysDbServer.GetUserByCode(context,userCode);
        }

        [TestMethod]
        public void ExpreCal()
        {
            ExpressionCal.Service.Context context = new ExpressionCal.Service.Context();
            context.SystemId = null;
            context.ProcInstId = null;
            context.Folio = null;
            var expressionStr = "US.GetUserByCode(\"1010,1011\")";
            var returnVal = "";
            var result = ExpressionCal.Service.ExpressionCal.ExpreCal(context, expressionStr,returnVal);
        }
    }
}
