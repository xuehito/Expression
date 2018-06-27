using System;

namespace Expression.Service.Common
{
    public class Context
    {
        /// <summary>
        ///     系统ID
        /// </summary>
        public Guid? SystemId { get; set; }

        /// <summary>
        ///     流程实例
        /// </summary>
        public string ProcInstId { get; set; }

        /// <summary>
        ///     表单号
        /// </summary>
        public string Folio { get; set; }
    }
}