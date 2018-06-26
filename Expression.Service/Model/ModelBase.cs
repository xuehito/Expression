using System;

namespace Expression.Service.Model
{
    public class ModelBase
    {
        public ModelBase()
        {
            CreatedOn = DateTime.Now;
            ModifyOn = DateTime.Now;
        }

        // public virtual int ID { get; set; }
        /// <summary>
        ///     创建人
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        ///     修改人
        /// </summary>
        public Guid? ModifyBy { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        public DateTime? ModifyOn { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        ///     记录版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     状态，1有效，0无效
        /// </summary>
        public int? State { get; set; }

        /// <summary>
        ///     系统ID
        /// </summary>
        public Guid? SystemId { get; set; }
    }
}