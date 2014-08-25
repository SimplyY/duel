using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class DuelTextBoxes
    {
        public static List<System.Windows.Forms.TextBox> lifeBoxes;
        public static List<System.Windows.Forms.TextBox> factoryCardsAmountBoxes;
        public static List<System.Windows.Forms.TextBox> managerBoxes;
        public static List<System.Windows.Forms.TextBox> duelBoxes;

        public static void ShowPlayersLife(int player1Life, int player2Life)
        {
            DuelTextBoxes.lifeBoxes[0].Text = Convert.ToString(player1Life);
            DuelTextBoxes.lifeBoxes[1].Text = Convert.ToString(player2Life);
        }

        public static void ShowCardsAmount(List<Card> cards, int id)
        {
            const string info = "剩余卡牌数：";
            int boxesBeginIndex = id - 1;

            DuelTextBoxes.factoryCardsAmountBoxes[boxesBeginIndex].Text = info + Convert.ToString(cards.Count);
            DuelTextBoxes.factoryCardsAmountBoxes[boxesBeginIndex].Text = info + Convert.ToString(cards.Count);
        }

        public static void ShowManager(List<Card> cards, int id)
        {
            ShowCards(DuelTextBoxes.managerBoxes,cards,id);
        }

        public static void ShowDuel(List<Card> cards, int id)
        {
            ShowCards(DuelTextBoxes.duelBoxes, cards, id);
        }

        private static void ShowCards(List<System.Windows.Forms.TextBox> cardsBoxes, List<Card> cards, int id)
        {
            int boxesBeginIndex = (id - 1) * 5;
            for (int i = 0; i < cards.Count; i++)
            {
                cardsBoxes[i + boxesBeginIndex].Text = cards[i].makeShowInfo();
                cardsBoxes[i + boxesBeginIndex].Height = 65;
            }
            for (int i = cards.Count; i < 5; i++)
            {
                cardsBoxes[i + boxesBeginIndex].Text = "";
                cardsBoxes[i + boxesBeginIndex].Height = 20;
            }
        }



    }
}
