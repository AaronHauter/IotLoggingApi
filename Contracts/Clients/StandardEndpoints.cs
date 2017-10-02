using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gentex.MES.IotLoggingApi.Contracts
{
    public class StandardEndpoints
    {
        public const string DevEndpoint = "http://zvm-msgdev2/mes/iotloggingapi/api/";
        public const string QaEndpoint = "http://zvm-msgqa/mes/iotloggingapi/api/";
        public const string ProdEndpoint = "http://zvm-msgprod/mes/iotloggingapi/api/";
    }
}
