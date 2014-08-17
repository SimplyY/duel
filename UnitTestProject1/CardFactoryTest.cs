using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using duel;
using System.Collections;
namespace UnitTestProject1
{
    [TestClass]
    public class CardFactoryTest
    {
        [TestMethod]
        public void CardFactoryConstructorTest()
        {
            const int cardNumber = 10;
            string expectedString = "杀手蜂";

            CardFactory actualCardFactory = new CardFactory("../../../duel/duelInfo.txt", 1);
            string actualString = actualCardFactory.cards[cardNumber - 1].ChineseName;

            Assert.AreEqual(expectedString, actualString);
        }
        /// <summary>
        ///CardFactory 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void CardFactoryConstructorTest1()
        {
            string expectedChineseName = null;

            string cardsInfoFileLocation = "C:\\Users\\yuwei\\Desktop\\duelInf"; //the test of wrong location 
            CardFactory target = new CardFactory(cardsInfoFileLocation, 1);
            Card actualCard = target.PopACard();
            string actualChineseName = actualCard.ChineseName;

            Assert.AreEqual(expectedChineseName, actualChineseName);
        }

        /// <summary>
        ///PopACard 的测试
        ///</summary>
        [TestMethod()]
        public void PopACardTest()
        {
            string expectedChineseName = "杀手蜂";

            int PopedNumber = 10;
            CardFactory target = new CardFactory("../../../duel/duelInfo.txt", 1);

            Card actual = target.PopACard();
            for (int i = 1; i < PopedNumber; i++)
            {
                actual = target.PopACard();
            }

            Assert.AreEqual(expectedChineseName, actual.ChineseName);
        }

        /// <summary>
        ///PopACard 的测试
        ///</summary>
        [TestMethod()]
        public void PopACardTest1()
        {
            string expectedChineseName = "Empty";

            int PopedNumber = 11;
            CardFactory target = new CardFactory("C:\\Users\\yuwei\\Desktop\\duelInfo.txt", 1);

            Card actual = target.PopACard();
            for (int i = 1; i < PopedNumber; i++)
            {
                actual = target.PopACard();
            }

            Assert.AreEqual(expectedChineseName, actual.ChineseName);
        }



        /// <summary>
        ///ShowCardsAmount 的测试
        ///</summary>
        [TestMethod()]
        public void ShowCardsAmountTest()
        {
            string expectedCardsAmount = "剩余卡牌数：9";
            int pickCardTimes = 1;

            Form1 targetForm = new Form1();
            CardFactory target = targetForm.duelGame.cardFactory1;
            if (pickCardTimes == 1)
            {
                targetForm.duelGame.PickACard(1);
            }
            target.ShowCardsAmount();
            string actualCardsAmount = DuelTextBoxs.Boxes[20].Text;

            Assert.AreEqual(expectedCardsAmount, actualCardsAmount);
        }
    }
}
