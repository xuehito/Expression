namespace ExpressionCal.Service
{
    public class MessageResult
    {
        public MessageFlag Status { get; set; }

        public string Info { set; get; }

        public object BussData { get; set; }

        public string Msg { get; set; }

        /// <summary>
        ///     返回成功
        /// </summary>
        public static MessageResult Success
        {
            get
            {
                var ret = new MessageResult();
                ret.Status = MessageFlag.Success;
                ret.Info = MessageFlag.Success.ToString();
                return ret;
            }
        }

        /// <summary>
        ///     返回失败
        /// </summary>
        public static MessageResult Fail
        {
            get
            {
                var ret = new MessageResult();
                ret.Status = MessageFlag.Fail;
                ret.Info = MessageFlag.Fail.ToString();
                return ret;
            }
        }

        public static MessageResult SuccessMsg(object data)
        {
            var ret = new MessageResult();
            ret.Status = MessageFlag.Success;
            ret.Info = MessageFlag.Success.ToString();
            ret.BussData = data;
            return ret;
        }

        public static MessageResult FailMsg(string msg)
        {
            var ret = new MessageResult();
            ret.Status = MessageFlag.Fail;
            ret.Info = MessageFlag.Fail.ToString();
            ret.Msg = msg;
            return ret;
        }
    }

    public enum MessageFlag
    {
        Success = 1,
        Fail = 2
    }
}