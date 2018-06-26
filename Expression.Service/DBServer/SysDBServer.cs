using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Expression.Service.Common;
using Expression.Service.Model;

namespace Expression.Service.DBServer
{
    public class SysDBServer
    {
        public static SysDBServer SysDbServer = new SysDBServer();

        /// <summary>
        ///     根据用户编码获取用户信息
        /// </summary>
        /// <returns></returns>
        public UserModel GetUserInfoByCode(Context context, string userCode)
        {
            try
            {
                var sql = string.Format(@"select * from UserInfo UserInfo where UserInfo.UserCode='{0}'", userCode);
                var ds = SqlHelper.ExecuteDataset(ServerCommon.GetSysServerConstr, CommandType.Text, sql);
                IList<UserModel> dt = ds.Tables[0].ToViwModel<UserModel>();
                return dt.First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}