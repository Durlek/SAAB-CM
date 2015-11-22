using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
	public partial interface WISEObject
	{
		WISE_RESULT CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase);
		WISE_RESULT CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, string objectName);
		WISE_RESULT AddToDatabase(DatabaseHandle databaseHandle);
	}
}
