using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace duel
{
    public class CardFactory
    {

        public List<Card> cards;

        private string cardsInfoFileLocation ;

        public void setCardsInfoFileLocation(string cardsInfoFileLocation)
        {
            this.cardsInfoFileLocation = cardsInfoFileLocation;
        }

        public CardFactory(string cardsInfoFileLocation)
        {
            cards = new List<Card>();
            setCardsInfoFileLocation(cardsInfoFileLocation);
            readFile();
        }

        public Card PopACard()
        {
            Card PopedCard = new Card();
            if(cards.Count>0)
            {
                PopedCard = cards[0];
                cards.RemoveAt(0);
                return PopedCard;
            }
            else
            {
                PopedCard.ChineseName = "Empty";
                GameStatus.SetStatusInfo("cards is empty");
                return PopedCard;
            }
        }

        private void readFile()
        {
            try
            {
                StreamReader infoFile = new StreamReader(@cardsInfoFileLocation, Encoding.UTF8);
                readInfo(infoFile);
            }
            catch (IOException)
            {
                this.cards.Add(new Card());
                GameStatus.SetStatusInfo("读取卡牌信息发生错误");
                //TODO
            }
        }
        private void readInfo(StreamReader infoFile)
        {
            string lineInfo = infoFile.ReadLine();
            while (lineInfo != null)
            {
                Card newCard = new Card();

                newCard.cardPackage = lineInfo;
                newCard.japanName = getLineInfo(infoFile);
                newCard.ChineseName = getLineInfo(infoFile);
                newCard.StarNumber = getLineInfo(infoFile);
                newCard.cardGrade = getLineInfo(infoFile);
                newCard.cardSpecies = getLineInfo(infoFile);
                newCard.attribute = getLineInfo(infoFile);
                newCard.stirpt = getLineInfo(infoFile);
                newCard.attack = getLineInfo(infoFile);
                newCard.defend = getLineInfo(infoFile);

                cards.Add(newCard);

                lineInfo = infoFile.ReadLine();
            }
        }

        private string getLineInfo(StreamReader infoFile)
        {
            string lineInfo = "";
            lineInfo = infoFile.ReadLine();
            int theCharIndex = lineInfo.IndexOf(':');

            if (theCharIndex == -1)
            {
                GameStatus.SetStatusInfo("卡牌信息有误");
            }
            else
            {
                lineInfo = lineInfo.Substring(theCharIndex+1);
            }
            
            return lineInfo;
        }
            
        
    }
}
