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
        [WebInvoke(Method = "POST", UriTemplate = "sensors/lcd", ResponseFormat = WebMessageFormat.Json)]
        void CreateLCD(Position p);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "sensors/lcd/{id}", ResponseFormat = WebMessageFormat.Json)]
        LCD GetLCDById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "sensors/lcd/{id}", ResponseFormat = WebMessageFormat.Json)]
        void UpdateLCD(string id, LCD lcd);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "sensors/lcd/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteLCD(string id);
    }
}
