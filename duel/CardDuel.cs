using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardDuel
    {
        public int numberOfDuel;
        public List<Card> cards { get; private set; }

        public CardDuel(int numberOfDuel)
        {
            this.numberOfDuel = numberOfDuel;
            cards = new List<Card>();
        }
    }
}
