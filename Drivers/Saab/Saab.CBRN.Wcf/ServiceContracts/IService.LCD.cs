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
        [WebInvoke(Method = "POST", UriTemplate = "sensors/lcd")]
        void CreateLCD(LCD lcd);

        [OperationContract]
        [WebGet(UriTemplate = "sensors/lcd")]
        IEnumerable<LCD> GetLCD();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "sensors/lcd/{id}")]
        Position GetLCDById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "sensors/lcd")]
        void UpdateLCD(LCD lcd);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "sensors/lcd/{id}")]
        void DeleteLCD(string id);
    }
}
