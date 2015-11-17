using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;
using System.Runtime.InteropServices;
using STS.WISE;
using STS.WISE.Drivers;
using WISE_RESULT = System.UInt32;
using System.ServiceModel;
using Saab.CBRN.Wcf;
using System.ServiceModel.Description;
using Saab.CBRN.Wcf.ServiceContracts;
using System.ServiceModel.Web;

namespace Saab.CBRNSensors
{
    public class CBRNSensorsDriver : WISEDriverBase
    {
        private WebServiceHost _serviceHost;
        private string _baseAddress;
        private int _port;

        #region WISEDriverBase overrides

        protected override WISE_RESULT OnInitialize(DriverSettings settings)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnInitialize(settings);
            WISEError.CheckCallFailedEx(result);
            
            //
            // Process required settings
            //

            #region Process required settings

            _baseAddress = "";
            if (!settings.GetSetting("BaseAddress", ref _baseAddress))
            {
                return WISEError.CreateResultCode(WISEErrorSeverity.Error, WISEError.WISE_FACILITY_COM_ADAPTER, WISEError.WISE_INVALID_ARG);
            }

            _port = 0;
            if (!settings.GetSetting("Port", ref _port))
            {
                return WISEError.CreateResultCode(WISEErrorSeverity.Error, WISEError.WISE_FACILITY_COM_ADAPTER, WISEError.WISE_INVALID_ARG);
            }

            #endregion // Process required settings

            #region Sample code: Read required settings
            //string settingValue = "";
            //if (!settings.GetSetting("MyRequiredSetting", ref settingValue))
            //{
            //    return WISEError.CreateResultCode(WISEErrorSeverity.Error, WISEError.WISE_FACILITY_COM_ADAPTER, WISEError.WISE_INVALID_ARG);
            //}
            #endregion

            //
            // Process optional settings
            //

            #region Sample code: Read optional settings
            //int settingOptional = 0;
            //settings.GetSetting("MyOptionalSetting", ref settingOptional);
            #endregion

            //
            // TODO: Initialize global driver resources.
            //

            return result;
        }

        protected override WISE_RESULT OnUninitialize()
        {
            WISE_RESULT result = WISEError.WISE_OK;

            //
            // TODO: Uninitialize global driver resources.
            //

            _serviceHost = null;

            // Call base class implementation
            result = base.OnUninitialize();
            return result;
        }

        protected override WISE_RESULT OnCreateDatabase(string strDatabaseName, DatabaseHandle hDatabase,
            DatabaseHandle hTemplateDatabase, DatabaseDistType eDatabaseDistType, DatabaseType eDatabaseType,
            OwnershipMode eModeOwnership, AttributeQualityMode eModeAttributeQuality,
            AttributeTimeMode eModeAttributeTime)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnCreateDatabase(strDatabaseName, hDatabase, hTemplateDatabase, eDatabaseDistType,
                                eDatabaseType, eModeOwnership, eModeAttributeQuality, eModeAttributeTime);
            WISEError.CheckCallFailedEx(result);

            if (eDatabaseType == DatabaseType.Application)
            {
                //
                // TODO: Open driver communication for the specified database.
                //

                Uri baseAddress = new Uri(string.Format("{0}:{1}", _baseAddress, _port));

                IService service = new Service(this.WISE, hDatabase);
                _serviceHost = new WebServiceHost(service, baseAddress);

                ServiceEndpoint serviceEndpoint = _serviceHost.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");

                WebHttpBehavior webHttpBehavior = _serviceHost.Description.Behaviors.Find<WebHttpBehavior>();

                if (webHttpBehavior != null)
                {
                    webHttpBehavior.AutomaticFormatSelectionEnabled = true;
                }
                else
                {
                    WebHttpBehavior webBehavior = new WebHttpBehavior();
                    webBehavior.AutomaticFormatSelectionEnabled = true;
                    serviceEndpoint.Behaviors.Add(webBehavior);
                }

                //
                // Enable metadata
                //

                //ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
                //metadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                //metadataBehavior.HttpGetEnabled = true;
                //_serviceHost.Description.Behaviors.Add(metadataBehavior);

                //_serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                //MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                //WebHttpBinding webHttpBinding = new WebHttpBinding();
                //webHttpBinding.


                //_serviceHost.AddServiceEndpoint(typeof(IService), webHttpBinding, "");

                _serviceHost.Open();
            }

            return WISEError.WISE_OK;
        }

        protected override WISE_RESULT OnConnectDatabase(string strDatabaseName, DatabaseHandle hDatabase,
            DatabaseDistType eDatabaseDistType, DatabaseType eDatabaseType, OwnershipMode eModeOwnership,
            AttributeQualityMode eModeAttributeQuality, AttributeTimeMode eModeAttributeTime)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Implementation of this method is optional.

            // Call base class implementation
            result = base.OnConnectDatabase(strDatabaseName, hDatabase, eDatabaseDistType, eDatabaseType,
                                eModeOwnership, eModeAttributeQuality, eModeAttributeTime);
            WISEError.CheckCallFailedEx(result);

            if (eDatabaseType == DatabaseType.Application)
            {
                //
                // TODO: Open driver communication for the specified database.
                //
            }

            return WISEError.WISE_OK;
        }

        protected override WISE_RESULT OnCloseDatabase(DatabaseHandle hDatabase)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnCloseDatabase(hDatabase);
            WISEError.CheckCallFailedEx(result);

            //
            // TODO: Close driver communication for the specified database.
            //

            _serviceHost.Close();

            return WISEError.WISE_OK;
        }

        protected override WISE_RESULT OnAddObject(DateTime timeStamp, DatabaseHandle hDatabase, ObjectHandle hObject,
                ClassHandle hClass, string strObjectName, TransactionHandle hTransaction)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnAddObject(timeStamp, hDatabase, hObject, hClass, strObjectName, hTransaction);
            WISEError.CheckCallFailedEx(result);

            try
            {
                DatabaseType dbtype = DatabaseType.Unknown;
                result = this.Sink.GetDatabaseType(hDatabase, ref dbtype);
                WISEError.CheckCallFailedEx(result);

                if (dbtype == DatabaseType.Application)
                {
                    // Only process application database objects by default

                    //if (global::CBRNSensors.EntityEquipment.IsTypeOf(this.WISE, hDatabase, hObject))
                    //{
                    //    global::CBRNSensors.EntityEquipment myObject = new global::CBRNSensors.EntityEquipment();
                    //}

                    //
                    // TODO: Add object on driver communication interface.
                    //
                    // This method typically works in either of two ways.
                    // If the underlying protocol requires us to send all object attributes  
                    // as a part of the object creation message;
                    //   1. Identify the type of object.
                    //   2. Based on the object type, extract its attributes.
                    //   3. Fill object attribute values into the protocol container associated with object creation.
                    //   4. the creation message on the underlying protocol.
                    //
                    // If the underlying protocol separates the create message from the initial attribute 
                    // update message;
                    //   1. Fill object information into the protocol container associated with object creation.
                    //   2. Send the creation message on the underlying protocol.
                    //

                    #region Sample code: Check object type
                    //ClassHandle hTestObjectClass = ClassHandle.Invalid;

                    //// Get handle corresponding to class "TEST_OBJECT" (this can be done once and then cached)
                    //result = this.WISETypeInfo.GetWISEClassHandle(hDatabase, "TEST_OBJECT", ref hTestObjectClass);
                    //WISEError.CheckCallFailedEx(result);

                    //if (hClass == hTestObjectClass)
                    //{
                    //    #region Sample code: Access TEST_OBJECT attributes
                    //    string stringAttributeValue = "";
                    //    AttributeHandle hAttr = AttributeHandle.Invalid;

                    //    result = this.Sink.GetAttributeHandle(hDatabase, hObject, "TEST_STRING", ref hAttr);
                    //    WISEError.CheckCallFailedEx(result);

                    //    result = this.Sink.GetAttributeValue(hDatabase, hObject, hAttr, ref stringAttributeValue);
                    //    WISEError.CheckCallFailedEx(result);
                    //    #endregion
                    //}
                    #endregion
                }
            }
            catch (WISEException ex)
            {
                result = ex.Error.ErrorCode;
            }
            return result;
        }

        protected override WISE_RESULT OnRemoveObject(DateTime timeStamp, DatabaseHandle hDatabase, ObjectHandle hObject,
            ClassHandle hClass, TransactionHandle hTransaction)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnRemoveObject(timeStamp, hDatabase, hObject, hClass, hTransaction);
            WISEError.CheckCallFailedEx(result);

            try
            {
                DatabaseType dbtype = DatabaseType.Unknown;
                result = this.Sink.GetDatabaseType(hDatabase, ref dbtype);

                if (dbtype == DatabaseType.Application)
                {
                    //
                    // TODO: Remove object on driver communication interface.
                    //
                }
            }
            catch (WISEException ex)
            {
                result = ex.Error.ErrorCode;
            }
            return result;
        }

        protected override WISE_RESULT OnSendEvent(DateTime timeStamp, DatabaseHandle hDatabase, EventHandle hEvent,
            ClassHandle hClass, TransactionHandle hTransaction)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnSendEvent(timeStamp, hDatabase, hEvent, hClass, hTransaction);
            WISEError.CheckCallFailedEx(result);

            try
            {
                //
                // TODO: Send event on driver communication interface.
                //
                // This method typically needs to perform the following steps;
                //   1. Identify the type of event.
                //   2. Based on the event type, extract event attributes.
                //   3. Fill event attribute values into the protocol container associated with the event.
                //   4. Send the event on the underlying protocol.
                //

                #region Sample code: Check event type
                //ClassHandle hTestEventClass = ClassHandle.Invalid;

                //// Get handle corresponding to class "TEST_EVENT" (this can be done once and then cached)
                //result = this.WISETypeInfo.GetWISEClassHandle(hDatabase, "TEST_EVENT", ref hTestEventClass);
                //WISEError.CheckCallFailedEx(result);

                //if (hClass == hTestEventClass)
                //{
                //    #region Sample code: Access TEST_EVENT attributes
                //    string stringAttributeValue = "";
                //    AttributeHandle hAttr = AttributeHandle.Invalid;

                //    result = this.Sink.GetEventAttributeHandle(hDatabase, hEvent, "TEST_STRING", ref hAttr);
                //    WISEError.CheckCallFailedEx(result);

                //    result = this.Sink.GetEventAttributeValue(hDatabase, hEvent, hAttr, ref stringAttributeValue);
                //    WISEError.CheckCallFailedEx(result);
                //    #endregion
                //}
                #endregion
            }
            catch (WISEException ex)
            {
                result = ex.Error.ErrorCode;
            }
            return result;
        }

        protected override WISE_RESULT OnUpdateAttribute(DateTime timeStamp, DatabaseHandle hDatabase, ObjectHandle hObject,
            ClassHandle hClass, AttributeHandle hAttribute, object value, AttributeQualityCode quality,
            TransactionHandle hTransaction)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            // Call base class implementation
            result = base.OnUpdateAttribute(timeStamp, hDatabase, hObject, hClass, hAttribute, value, quality, hTransaction);
            WISEError.CheckCallFailedEx(result);

            //string myValue = string.Empty;
            //AttributeHandle myAttributeHandle = AttributeHandle.Invalid;
            //this.WISE.GetAttributeHandle(hDatabase, hObject, "SomeAttribute", ref myAttributeHandle);
            //this.WISE.GetAttributeValue(hDatabase, hObject, myAttributeHandle, ref myValue);

            //global::CBRNSensors.EntityEquipmentSensorCBRNLCD stateObject = new global::CBRNSensors.EntityEquipmentSensorCBRNLCD();
            //stateObject.CreateInstance(this.WISE, hDatabase);
            //stateObject.SensorState = 
            //stateObject.AddToDatabase(hDatabase);

            return result;
        }

        protected override WISE_RESULT OnCommitTransaction(System.DateTime timeStamp, DatabaseHandle hDatabase, TransactionHandle hTransaction,
                ObjectHandleList newObjects, ObjectHandleList removedObjects, Dictionary<ObjectHandle, List<AttributeHandle>> dictNewAttributes,
                Dictionary<ObjectHandle, List<AttributeHandle>> dictRemovedAttributes,
                Dictionary<ObjectHandle, List<AttributeHandle>> dictUpdatedAttributes, List<EventHandle> newEvents)
        {

            //
            // TODO:
            //      If your protocol handles transactions, process the transaction data here.
            //      Returning WISE_E_NOT_IMPL from this method will trigger the driver base class to use the 
            //      fallback behaviour where each change in the transaction is processed individually 
            //      through calls to OnAddObject, OnRemoveObject, OnNewAttribute, OnRemoveAttribute, 
            //      OnUpdateAttribute and OnSendEvent respectively.
            //

            return WISEError.WISE_E_NOT_IMPL;
        }

        #endregion
    }
}
