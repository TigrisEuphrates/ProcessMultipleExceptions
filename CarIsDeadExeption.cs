using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    [Serializable]
    class CarIsDeadExeption : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        ////private string messageDetails = String.Empty;
        //public DateTime ErrorTimeStamp { get; set; }
        //public string CauseOfError { get; set; }
        //public CarIsDeadExeption() { }
        //public CarIsDeadExeption(string message, string cause, DateTime time):base(message)
        //{
        ////    messageDetails = message;
        //    CauseOfError = cause;
        //    ErrorTimeStamp = time;
        //}
        ////public override string Message => $"Car Error Message: {messageDetails}";
        ////changes to test smth
        public CarIsDeadExeption() { }
        public CarIsDeadExeption(string message) : base(message) { }
        public CarIsDeadExeption(string message, System.Exception inner):base(message, inner) { }
        protected CarIsDeadExeption(System.Runtime.Serialization.SerializationInfo info,
                                    System.Runtime.Serialization.StreamingContext context):base(info, context) { }
        public CarIsDeadExeption(string message, string cause, DateTime time):base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
