using duel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 CardTest 的测试类，旨在
    ///包含所有 CardTest 单元测试
    ///</summary>
    [TestClass()]
    public class CardTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///makeShowInfo 的测试
        ///</summary>
        [TestMethod()]
        public void makeShowInfoTest()
        {
            string expectedShowInfo = "怪兽名：诅咒之龙\r\n攻击力：500\r\n防守力：500\r\n";

            Card target = new Card(); // TODO: 初始化为适当的值
            target.ChineseName = "诅咒之龙";
            target.attack = "500";
            target.defend = "500";
            target.makeShowInfo();
            string actualShowInfo = target.showInfo;

            Assert.AreEqual(expectedShowInfo, actualShowInfo);
        }
    }
}
