﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace duel
{
    public partial class Form1 : Form
    {
        public Game duelGame { get; set; }


        public Form1()
        {
            InitializeComponent();
            InitDuelTextBox();
            InitBootons();
            InitGame();
        }

        public void ShowNewTable()
        {
            duelGame.cardFactory1.ShowCardsAmount();
            duelGame.cardFactory2.ShowCardsAmount();
            duelGame.cardManager1.Show();
            duelGame.cardManager2.Show();
            duelGame.cardDuel1.Show();
            duelGame.cardDuel2.Show();

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (!duelGame.hasError)
            {
                SetStatusBox();
            }
            GameStatus.ShowGameStatus(showStatusBox);

        }

        private void SetStatusBox()
        {
            string status = "玩家" + Convert.ToString(duelGame.speakPlayer) + "的回合";
            GameStatus.SetStatusInfo(status);
        }

        private void InitGame()
        {
            timer1.Enabled = true; //设置为truetimer1_Tick实践就会执行，开始计时
            timer1.Interval = 200; //设置timer1的timer1_Tick实践执行周期

            duelGame = new Game();
        }

        private void playerBotton1_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(1);
            ShowNewTable();
        }

        private void PlayerBotton2_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(2);
            ShowNewTable();
        }



        private void InitDuelTextBox()
        {
            DuelTextBoxs.Boxes = new List<TextBox>();

            DuelTextBoxs.Boxes.Add(textBox1);
            DuelTextBoxs.Boxes.Add(textBox2);
            DuelTextBoxs.Boxes.Add(textBox3);
            DuelTextBoxs.Boxes.Add(textBox4);
            DuelTextBoxs.Boxes.Add(textBox5);
            DuelTextBoxs.Boxes.Add(textBox6);
            DuelTextBoxs.Boxes.Add(textBox7);
            DuelTextBoxs.Boxes.Add(textBox8);
            DuelTextBoxs.Boxes.Add(textBox9);
            DuelTextBoxs.Boxes.Add(textBox10);
            DuelTextBoxs.Boxes.Add(textBox11);
            DuelTextBoxs.Boxes.Add(textBox12);
            DuelTextBoxs.Boxes.Add(textBox13);
            DuelTextBoxs.Boxes.Add(textBox14);
            DuelTextBoxs.Boxes.Add(textBox15);
            DuelTextBoxs.Boxes.Add(textBox16);
            DuelTextBoxs.Boxes.Add(textBox17);
            DuelTextBoxs.Boxes.Add(textBox18);
            DuelTextBoxs.Boxes.Add(textBox19);
            DuelTextBoxs.Boxes.Add(textBox20);


            DuelTextBoxs.Boxes.Add(Favtory1CardsAmountTextBox);
            DuelTextBoxs.Boxes.Add(Favtory2CardsAmountTextBox);
        }

        private void InitBootons()
        {
            Buttons.Buttons = new List<Button>();

            Buttons.Buttons.Add(button1);
            Buttons.Buttons.Add(button2);
            Buttons.Buttons.Add(button3);
            Buttons.Buttons.Add(button4);
            Buttons.Buttons.Add(button5);
            Buttons.Buttons.Add(button6);
            Buttons.Buttons.Add(button7);
            Buttons.Buttons.Add(button8);
            Buttons.Buttons.Add(button9);
            Buttons.Buttons.Add(button10);
            Buttons.Buttons.Add(button11);
            Buttons.Buttons.Add(button12);
            Buttons.Buttons.Add(button13);
            Buttons.Buttons.Add(button14);
            Buttons.Buttons.Add(button15);
            Buttons.Buttons.Add(button16);
            Buttons.Buttons.Add(button17);
            Buttons.Buttons.Add(button18);
            Buttons.Buttons.Add(button19);
            Buttons.Buttons.Add(button20);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerLife1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showStatusBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
