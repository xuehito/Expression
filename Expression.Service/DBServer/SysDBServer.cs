using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Expression.Service.Common;
using Expression.Service.Model;

namespace Expression.Service.DBServer
{
    public class SysDBServer
    {
        public static SysDBServer SysDbServer = new SysDBServer();

        public static string Connection=ConfigurationManager.ConnectionStrings["SysEntities"].ConnectionString;

        /// <summary>
        ///     根据员工编码获取员工信息
        /// </summary>
        /// <returns></returns>
        public T_Sys_Employee GetUserByCode(Context context, string userCode)
        {
            try
            {
                using (var dbContext = new SysContext(Connection))
                {
                    var sql = string.Format(@"select * from T_Sys_Employee where EmployeeCode='{0}'", userCode);
                    return dbContext.Database.SqlQuery<T_Sys_Employee>(sql, "").First();
                }
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }
    }
}