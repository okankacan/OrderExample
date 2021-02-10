using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace CustomerOrder.Core.Model.ResponseModel
{
    public class BaseResponseModel
    {
        [DataMember]
        public HttpStatusCode HttpStatusCode { get; set; }

        [DataMember]
        public string ExeptionMessage { get; set; }

        [DataMember]
        public object Data { get; set; }
    }
}
