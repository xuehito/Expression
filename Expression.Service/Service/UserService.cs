using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expression.Service.Common;
using Expression.Service.DBServer;
using Expression.Service.Model;
using Newtonsoft.Json;

namespace Expression.Service.Service
{
    public class UserService
    {
        private Context _context;
        public UserService(string sn, string systemId, string workflowCode, string activityCode, string procInstId, string folio, string bizObjectId)
        {
            _context = new Context()
            {
                SN = sn,
                SystemId = string.IsNullOrEmpty(systemId) ? Guid.Empty : new Guid(systemId),
                WorkflowCode = workflowCode,
                ActivityCode = activityCode,
                ProcInstId = procInstId,
                Folio = folio,
                BizObjectId = string.IsNullOrEmpty(bizObjectId) ? Guid.Empty : new Guid(bizObjectId)
            };
        }

        ///根据员工编号获取用户，多用户编号
        public List<UserModel> GetUserByCode(string codeStr)
        {
            List<UserModel> list = new List<UserModel>();
            string[] codes = codeStr.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            foreach (string code in codes)
            {
                try
                {
                    UserModel model = SysDBServer.SysDbServer.GetUserInfoByCode(_context, code);
                    if (model != null)
                    {
                        list.Add(model);
                    }
                        
                }
                catch (Exception ex)
                {
                    //log
                }
            }
            //var result = JsonConvert.SerializeObject(list);
            //log 计算结果

            return list;
        }
    }
}
