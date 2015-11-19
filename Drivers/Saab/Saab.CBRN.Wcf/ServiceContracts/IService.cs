using Saab.CBRN.Wcf.DataContracts;
using STS.WISE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Saab.CBRN.Wcf.ServiceContracts
{
    [ServiceContract]
    public partial interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "check", ResponseFormat = WebMessageFormat.Json)]
        int MagicNumber();
    }
}
