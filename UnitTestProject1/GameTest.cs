using duel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 GameTest 的测试类，旨在
    ///包含所有 GameTest 单元测试
    ///</summary>
    [TestClass()]
    public class GameTest
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
        ///TransformSpeakerPlayer 的测试
        ///</summary>
        [TestMethod()]
        public void TransformSpeakerPlayerTest()
        {
            int expected = 1;

            Game target = new Game();
            target.speakPlayer = 2;
            target.TransformSpeakerPlayer();

            int actual = target.speakPlayer;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///TransformSpeakerPlayer 的测试
        ///</summary>
        [TestMethod()]
        public void TransformSpeakerPlayerTest1()
        {
            int expected = -1;

            Game target = new Game();
            target.speakPlayer = 123;
            target.TransformSpeakerPlayer();

            int actual = target.speakPlayer;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///PickACard 的测试
        ///</summary>
        [TestMethod()]
        public void PickACardTest()
        {
            string expectedChineseName = "幼毛虫";
            int pickTimes = 2;

            Game targetGame = new Game(); 
            int playerButton = 1;
            for (int i = 0; i < pickTimes; i++)
            {
                targetGame.PickACard(playerButton);                
            }
            CardManager theManager = targetGame.cardManager1;
            Card theCard = theManager.cards[pickTimes - 1];
            string actualChineseName = theCard.ChineseName;

            Assert.AreEqual(expectedChineseName, actualChineseName);
        }



        /// <summary>
        ///PickACard 的测试
        ///</summary>
        [TestMethod()]
        public void PickACardTest1()
        {
            string expectedChineseName = "幼毛虫";
            int pickTimes = 2;

            Game targetGame = new Game();
            targetGame.TransformSpeakerPlayer();//SpeakerPlayer's default is 1,this test need 2.
            int playerButton = 2;

            for (int i = 0; i < pickTimes; i++)
            {
                targetGame.PickACard(playerButton);
            }
            CardManager theManager = targetGame.cardManager2;
            Card theCard = theManager.cards[pickTimes - 1];
            string actualChineseName = theCard.ChineseName;
            Assert.AreEqual(expectedChineseName, actualChineseName);
        }
    }
}
