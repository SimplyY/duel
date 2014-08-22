using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardsDuel : CardsManager
    {
        public CardsDuel(int number, int theBeginIndexOfBoxes) :base(number ,theBeginIndexOfBoxes){}

        public void RemoveCard(ref Card removedCard)
        {
            cards.Remove(removedCard);
            removedCard = null;
        }
    }
}
