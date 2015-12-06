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
        [WebInvoke(Method = "POST", UriTemplate = "sensors/I28", ResponseFormat = WebMessageFormat.Json)]
        void CreateI28(Position p);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "sensors/I28/{id}", ResponseFormat = WebMessageFormat.Json)]
        I28 GetI28ById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "sensors/I28/{id}", ResponseFormat = WebMessageFormat.Json)]
        void UpdateI28(string id, I28 i28);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "sensors/I28/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteI28(string id);
    }
}
