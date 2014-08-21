using System;
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
            Game.InitRecentCard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ShowNewTable()
        {
            duelGame.Show();
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

            DuelTextBoxs.Boxes.Add(playerLife1);
            DuelTextBoxs.Boxes.Add(playerLife2);
        }


        public void InitGame()
        {
            timer1.Enabled = true; //设置为truetimer1_Tick实践就会执行，开始计时
            timer1.Interval = 200; //设置timer1的timer1_Tick实践执行周期

            duelGame = new Game();
        }


        private void StartGame(object sender, EventArgs e)
        {
            Button startGameButton = (Button)sender;

            InitGame();
            ShowNewTable();
            startGameButton.Text = "游戏已经开始";
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

        private void SendToDuel1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag = Convert.ToInt32(button.Tag);
            int duelNumber = 1;
            int cardIndex = getIndexFromTag(tag, duelNumber);
            duelGame.SendACardToDuel(cardIndex, duelNumber);

            ShowNewTable();
        }

        private void SendToDuel2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag = Convert.ToInt32(button.Tag);
            int duelNumber = 2;
            int cardIndex = getIndexFromTag(tag, duelNumber);
            duelGame.SendACardToDuel(cardIndex, duelNumber);

            ShowNewTable();
        }

        private int getIndexFromTag(int tag, int duelNumber)
        {
            if (duelNumber == 1 && tag >= 1 && tag <= 5)
            {
                return tag - 1;
            }
            else if (duelNumber == 2 && tag >= 16 && tag <= 20)
            {
                return tag - 16;
            }
            return -1;
        }


        private void endSpeak_Click(object sender, EventArgs e)
        {
            duelGame.TransformSpeakerPlayer();
        }

        private void ChangeStateToDefend_Click(object sender, EventArgs e)
        {
            if (Game.recentDuelCard.status != "空")
            {
                Game.recentDuelCard.status = "防守表示";
                ShowNewTable();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            duelGame.TransformSpeakerPlayer();
        }






    }
}
