using System;

namespace Expression.Service.Common
{
    public class Context
    {
        /// <summary>
        ///     任务号
        /// </summary>
        public string SN { get; set; }

        /// <summary>
        ///     系统ID
        /// </summary>
        public Guid? SystemId { get; set; }

        /// <summary>
        ///     流程编码
        /// </summary>
        public string WorkflowCode { get; set; }

        /// <summary>
        ///     节点编码
        /// </summary>
        public string ActivityCode { get; set; }

        /// <summary>
        ///     流程实例
        /// </summary>
        public string ProcInstId { get; set; }

        /// <summary>
        ///     表单号
        /// </summary>
        public string Folio { get; set; }

        /// <summary>
        ///     业务主键ID
        /// </summary>
        public Guid? BizObjectId { get; set; }
    }
}