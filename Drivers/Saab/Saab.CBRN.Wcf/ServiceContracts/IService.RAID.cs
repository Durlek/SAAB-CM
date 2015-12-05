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
        [WebInvoke(Method = "POST", UriTemplate = "sensors/raid", ResponseFormat = WebMessageFormat.Json)]
        void CreateRAID(Position p);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "sensors/raid/{id}", ResponseFormat = WebMessageFormat.Json)]
        RAID GetRAIDById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "sensors/raid/{id}", ResponseFormat = WebMessageFormat.Json)]
        void UpdateRAID(string id, RAID raid);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "sensors/raid/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteRAID(string id);
    }
}
