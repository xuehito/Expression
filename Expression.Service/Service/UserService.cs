using System;
using System.Collections.Generic;
using Expression.Service.Common;
using Expression.Service.DBServer;
using Expression.Service.Model;

namespace Expression.Service.Service
{
    public class UserService
    {
        private readonly Context _context;

        public UserService(string systemId, string procInstId)
        {
            _context = new Context
            {
                SystemId = string.IsNullOrEmpty(systemId) ? Guid.Empty : new Guid(systemId),
                ProcInstId = procInstId
            };
        }

        ///根据员工编号获取用户，多用户编号
        public List<T_Sys_Employee> GetUserByCode(string codeStr)
        {
            var list = new List<T_Sys_Employee>();
            var codes = codeStr.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var code in codes)
            {
                try
                {
                    var model = SysDBServer.SysDbServer.GetUserByCode(_context, code);
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