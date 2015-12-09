using Saab.CBRN.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Saab.CBRN.Wcf.ServiceContracts
{
    public partial interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "sensors/I27", ResponseFormat = WebMessageFormat.Json)]
        void CreateI27(Position p);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "sensors/I27/{id}", ResponseFormat = WebMessageFormat.Json)]
        I27 GetI27ById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "sensors/I27/{id}", ResponseFormat = WebMessageFormat.Json)]
        void UpdateI27(string id, I27 i27);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "sensors/I27/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteI27(string id);
    }
}
