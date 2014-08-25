using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class CardsDuel : CardsManager
    {
        public CardsDuel(int number) :base(number){}

        override public void Show()
        {
            DuelTextBoxs.ShowDuel(cards, id);
        }

        public void RemoveCard(ref Card removedCard)
        {
            cards.Remove(removedCard);
            removedCard = null;
        }
    }
}
