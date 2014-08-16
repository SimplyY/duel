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
        public void showManager()
        {
            if (numberOfManager == 1)
            {
                
            }
        }
    }
}
