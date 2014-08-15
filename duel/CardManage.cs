using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardManager
    {
        public List<Card> cards{ get;private set;}
        public CardManager()
        {
            cards = new List<Card>();
        }
        public void PushACard(Card pushedCard)
        {
            cards.Add(pushedCard);
        }
    }
}
