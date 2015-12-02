using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
	public abstract class WISEObject
	{
		public abstract WISE_RESULT CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase);
		public abstract WISE_RESULT CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, string objectName);
		public abstract WISE_RESULT AddToDatabase(DatabaseHandle databaseHandle);


        public INETWISEDriverSink2 WISE { get; protected set; }

        public INETWISEStringCache StringCache
        {
            get { return (this.WISE as INETWISEStringCache); }
        }

        public DatabaseHandle Database { get; protected set; }

        public ObjectHandle Object { get; protected set; }

        public TransactionHandle Transaction { get; protected set; }

        #region Constructors

        public WISEObject()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Object = WISEConstants.WISE_INVALID_HANDLE;
            this.Transaction = TransactionHandle.None;            
        }

        public WISEObject(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = TransactionHandle.None;
        }

        public WISEObject(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle, TransactionHandle transactionHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = transactionHandle;
        }

        #endregion
	}
}
