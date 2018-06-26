using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCal.Service
{
    public class MessageResult
    {
        public MessageFlag Status { get; set; }

        public string Info { set; get; }

        public Object BussData { get; set; }

        public string Msg { get; set; }

        public static MessageResult SuccessMsg(string data)
        {
            MessageResult ret = new MessageResult();
            ret.Status = MessageFlag.Success;
            ret.Info = MessageFlag.Success.ToString();
            ret.BussData = data;
            return ret;
        }
        /// <summary>
        /// 返回成功
        /// </summary>
        public static MessageResult Success
        {
            get
            {
                MessageResult ret = new MessageResult();
                ret.Status = MessageFlag.Success;
                ret.Info = MessageFlag.Success.ToString();
                return ret;
            }
        }

        public static MessageResult FailMsg(string msg)
        {
            MessageResult ret = new MessageResult();
            ret.Status = MessageFlag.Fail;
            ret.Info = MessageFlag.Fail.ToString();
            ret.Msg = msg;
            return ret;
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        public static MessageResult Fail
        {
            get
            {
                MessageResult ret = new MessageResult();
                ret.Status = MessageFlag.Fail;
                ret.Info = MessageFlag.Fail.ToString();
                return ret;
            }
        }
    }
    public enum MessageFlag
    {
        Success = 1,
        Fail = 2
    }
}
