using System.Data.Entity;
using Expression.Service.Model;

namespace Expression.Service.DBServer
{
    internal class SysContext : DbContext
    {
        public SysContext(string conn)
        {
            Database.Connection.ConnectionString = conn;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<T_Sys_Employee> T_Sys_UserInfo { get; set; }
    }
}