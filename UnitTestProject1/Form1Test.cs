using duel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{


    /// <summary>
    ///这是 Form1Test 的测试类，旨在
    ///包含所有 Form1Test 单元测试
    ///</summary>
    [TestClass()]
    public class Form1Test
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
        ///Form1 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void Form1ConstructorTest()
        {
            Form1 target = new Form1();
            Assert.IsNotNull(target);
        }




        /// <summary>
        ///timer1_Tick 的测试
        ///</summary>
        [TestMethod()]
        public void timer1_TickTest()
        {
            int expected = 20;

            int times = 10;

            Form1 targetForm = new Form1(); // TODO: 初始化为适当的值
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            for (int i = 0; i < times; i++)
            {
                targetForm.timer1_Tick(sender, e);
            }
            int actual = DuelTextBoxs.Boxes.Count;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///showNewTable 的测试
        ///</summary>
        [TestMethod()]
        public void showNewTableTest()
        {
            const string info1 = "怪兽名：诅咒之龙\r\n攻击力：500\r\n防守力：";
            int info2 = 1;
            int cardsManager1Amount = 2;
            int cardsManager2Amount = 3;

            string expectedBoxesShowInfo = "";
            BuiltExpectedBoxesShowInfo(ref expectedBoxesShowInfo, cardsManager1Amount, info1, info2);
            BuiltExpectedBoxesShowInfo(ref expectedBoxesShowInfo, cardsManager2Amount, info1, info2);

            Form1 target = new Form1(); // TODO: 初始化为适当的值
            CardManager cardManager1 = target.duelGame.cardManager1;
            CardManager cardManager2 = target.duelGame.cardManager2;
            BuiltActualCardsInfo(cardManager1, cardsManager1Amount, info1, info2);
            BuiltActualCardsInfo(cardManager2, cardsManager2Amount, info1, info2);

            target.showNewTable();

            string actualBoxesShowInfo = "";
            BuiltActualBoxesShowInfo(ref actualBoxesShowInfo, cardManager1.cards, 0);
            BuiltActualBoxesShowInfo(ref actualBoxesShowInfo, cardManager2.cards, 15);


            Assert.AreEqual(expectedBoxesShowInfo, actualBoxesShowInfo);
        }

        private void BuiltExpectedBoxesShowInfo(ref string expectedBoxesShowInfo, int cardsAmount, string info1, int info2)
        {
            for (int i = 0; i < cardsAmount; i++)
            {
                info2++;
                expectedBoxesShowInfo += info1 + info2 + "\r\n";
            }
        }

        private void BuiltActualCardsInfo(CardManager owner, int cardsAmount, string info1, int info2)
        {
            for (int i = 0; i < cardsAmount; i++)
            {
                info2++;
                Card builtedCard = new Card();
                builtedCard.ChineseName = "诅咒之龙";
                builtedCard.attack = "500";
                builtedCard.defend = Convert.ToString(info2);
                owner.cards.Add(builtedCard);
            }
        }
        private void BuiltActualCardsInfo(CardDuel owner, int cardsAmount, string info1, int info2)
        {
            for (int i = 0; i < cardsAmount; i++)
            {
                info2++;
                Card builtedCard = new Card();
                builtedCard.ChineseName = "诅咒之龙";
                builtedCard.attack = "500";
                builtedCard.defend = Convert.ToString(info2);
                owner.cards.Add(builtedCard);
            }
        }

        private void BuiltActualBoxesShowInfo(ref string actualBoxesShowInfo, List<Card> cards, int boxesBeginIndex)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                actualBoxesShowInfo += DuelTextBoxs.Boxes[i + boxesBeginIndex].Text;
            }
        }


    }
}
