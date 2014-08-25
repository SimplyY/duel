using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardsManager
    {
        public int id;
        public int theBeginIndexOfBoxes { get; set; }
        public List<Card> cards { get; private set; }

        public CardsManager(){}
        public CardsManager(int number)
        {
            this.id = number;
            cards = new List<Card>();
        }

        virtual public void Show()
        {
            DuelTextBoxes.ShowManager(cards, id);
        }

        public void PushACard(Card pushedCard)
        {
            cards.Add(pushedCard);
        }

        public Card PopACard()
        {
            Card PopedCard = new Card();
            if (cards.Count > 0)
            {
                PopedCard = cards[0];
                cards.RemoveAt(0);
                return PopedCard;
            }
            else
            {
                PopedCard.ChineseName = "Empty";
                GameStatus.SetErrorInfo("cards is empty");
                return PopedCard;
            }
        }

        public Card SendACard(int cardIndex)
        {
            Card SendCard = new Card();
            if (cards.Count > 0)
            {
                SendCard = cards[cardIndex];
                cards.RemoveAt(cardIndex);
                return SendCard;
            }
            else
            {
                SendCard.ChineseName = "Empty";
                GameStatus.SetErrorInfo("cards is empty");
                return SendCard;
            }
        }

    }
}
