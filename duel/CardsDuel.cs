using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardsDuel
    {
        public int numberOfDuel;
        public List<Card> cards { get; private set; }

        public CardsDuel(int numberOfDuel)
        {
            this.numberOfDuel = numberOfDuel;
            cards = new List<Card>();
        }
    }
}
