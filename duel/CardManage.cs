using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardManager
    {
        public int numberOfManager;
        public List<Card> cards { get; private set; }

        public CardManager(int numberOfManager)
        {
            this.numberOfManager = numberOfManager;
            cards = new List<Card>();
        }
        public void PushACard(Card pushedCard)
        {
            cards.Add(pushedCard);
        }
        public void ShowManager()
        {
            int boxesBeginIndex = -1;
            if (numberOfManager == 1)
            {
                boxesBeginIndex = 0;
            }
            else if (numberOfManager == 2)
            {
                boxesBeginIndex = 15;
            }
            DuelTextBoxs.ShowTextBox(cards, boxesBeginIndex);
        }
    }
}
