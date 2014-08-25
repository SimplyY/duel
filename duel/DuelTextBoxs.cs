using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class DuelTextBoxs
    {
        public static List<System.Windows.Forms.TextBox> Boxes;

        public static void ShowManagerBox(List<Card> cards, int boxesBeginIndex)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Text = cards[i].makeShowInfo();
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Height = 65;
            }
        }

        public static void ShowDuelBox(List<Card> cards, int boxesBeginIndex)
        {
            for (int i = cards.Count; i < 5; i++)
            {
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Text = "";
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Height = 20;
            }
        }

        public static void ShowPlayersLife(int player1Life, int player2Life)
        {
            DuelTextBoxs.Boxes[22].Text = Convert.ToString(player1Life);
            DuelTextBoxs.Boxes[23].Text = Convert.ToString(player2Life);
        }
    }
}
