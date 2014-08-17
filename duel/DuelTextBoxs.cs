﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    public class DuelTextBoxs
    {
        public static List<System.Windows.Forms.TextBox> Boxes;

        public static void ShowTextBox(List<Card> cards, int boxesBeginIndex)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Text = cards[i].makeShowInfo();
                DuelTextBoxs.Boxes[i + boxesBeginIndex].Height = 50;
            }
        }
    }
}