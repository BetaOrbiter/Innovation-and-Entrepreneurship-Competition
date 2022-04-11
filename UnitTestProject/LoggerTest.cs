using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTool;

namespace UnitTestProject
{
    [TestClass]
    public class LoggerTest
    {
        private readonly Log log = Log.GetInstance();

        [TestMethod]
        public void TestLog()
        {
            log.Record(LogType.Success, "successTest");
            log.Record(LogType.Error, "ErrorTest");

            log.SendToRemote();
        }
    }
}
