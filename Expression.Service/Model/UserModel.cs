using System;

namespace Expression.Service.Model
{
    public class UserModel
    {
        /// <summary>
        ///     员工唯一Id
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        ///     员工编码
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     员工姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        ///     邮箱
        /// </summary>
        public string Email { get; set; }
    }
}