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
        private bool gameHasStarted;

        private Button beforeChosenButton1;
        private Button beforeChosenButton2;

        public Form1()
        {
            gameHasStarted = false;
            InitializeComponent();
            InitDuelTextBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ShowNewTable()
        {
            duelGame.ShowPlayersLife();
            duelGame.cardFactory1.ShowCardsAmount();
            duelGame.cardFactory2.ShowCardsAmount();
            duelGame.cardManager1.Show();
            duelGame.cardManager2.Show();
            duelGame.cardDuel1.Show();
            duelGame.cardDuel2.Show();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (duelGame.IsGameOver() || duelGame.hasError)
            {
                GameStatus.ShowGameStatus(showStatusBox);
                gameHasStarted = false;

                startGameButton.Text = "点击重新开始";
            }
            else
            {
                SetStatusBox();
                GameStatus.ShowGameStatus(showStatusBox);
            }
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
            gameHasStarted = true;
        }


        private void StartGame(object sender, EventArgs e)
        {
            if (gameHasStarted == false)
            {
                Button startGameButton = (Button)sender;

                InitGame();
                ShowNewTable();
                startGameButton.Text = "游戏已经开始";
            }
        }

        private void player1PickACard_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                duelGame.PickACard(1);
                ShowNewTable();
            }
        }

        private void Player2PickACard_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                duelGame.PickACard(2);
                ShowNewTable();
            }
        }

        private void SendToDuel1_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                Button button = (Button)sender;
                int tag = Convert.ToInt32(button.Tag);
                int duelNumber = 1;
                int cardIndex = getIndexFromTag(tag, duelNumber);
                duelGame.SendACardToDuel(cardIndex, duelNumber);

                ShowNewTable();
            }
        }

        private void SendToDuel2_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                Button button = (Button)sender;
                int tag = Convert.ToInt32(button.Tag);
                int duelNumber = 2;
                int cardIndex = getIndexFromTag(tag, duelNumber);
                duelGame.SendACardToDuel(cardIndex, duelNumber);

                ShowNewTable();
            }
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

        private void DuelButton1_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                if (duelGame.speakPlayer == 1)
                {
                    Button button = (Button)sender;
                    int cardIndex = Convert.ToInt32(button.Tag);
                    if (cardIndex < duelGame.cardDuel1.cards.Count)
                    {
                        Card beforeChosenCard = Game.recentDuelCardAttack;
                        if (beforeChosenCard != null && beforeChosenCard.hasBeenChosen == true)
                        {
                            InitBeforeButton(beforeChosenButton1);
                        }

                        Game.recentDuelCardAttack = duelGame.cardDuel1.cards[cardIndex];
                        Game.recentDuelCardAttack.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenButton1 = button;
                    }
                }
                else if (duelGame.speakPlayer == 2 && Game.recentDuelCardAttack != null)
                {
                    Button button = (Button)sender;
                    int cardIndex = Convert.ToInt32(button.Tag);
                    if (cardIndex < duelGame.cardDuel1.cards.Count)
                    {
                        Card beforeChosenCard = Game.recentDuelCardAttacked;
                        if (beforeChosenCard != null && beforeChosenCard.hasBeenChosen == true)
                        {
                            InitBeforeButton(beforeChosenButton2);
                        }

                        Game.recentDuelCardAttacked = duelGame.cardDuel1.cards[cardIndex];
                        Game.recentDuelCardAttacked.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenButton2 = button;
                    }
                }
            }
        }

        private void DuelButton2_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                if (duelGame.speakPlayer == 2)
                {
                    Button button = (Button)sender;
                    int cardIndex = Convert.ToInt32(button.Tag);
                    if (cardIndex < duelGame.cardDuel2.cards.Count)
                    {

                        Card beforeChosenCard = Game.recentDuelCardAttack;
                        if (beforeChosenCard != null && beforeChosenCard.hasBeenChosen == true)
                        {
                            InitBeforeButton(beforeChosenButton1);
                        }

                        Game.recentDuelCardAttack = duelGame.cardDuel2.cards[cardIndex];
                        Game.recentDuelCardAttack.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenButton1 = button;
                    }
                }
                else if (duelGame.speakPlayer == 1 && Game.recentDuelCardAttack != null)
                {
                    Button button = (Button)sender;
                    int cardIndex = Convert.ToInt32(button.Tag);
                    if (cardIndex < duelGame.cardDuel2.cards.Count)
                    {
                        Card beforeChosenCard = Game.recentDuelCardAttacked;
                        if (beforeChosenCard != null && beforeChosenCard.hasBeenChosen == true)
                        {
                            InitBeforeButton(beforeChosenButton2);
                        }

                        Game.recentDuelCardAttacked = duelGame.cardDuel2.cards[cardIndex];
                        Game.recentDuelCardAttacked.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenButton2 = button;
                    }
                }
            }
        }

        private void InitBeforeButton(Button beforeButton)
        {
            if (beforeButton != null)
            {
                beforeButton.Text = "点击选中";
            }
        }

        private void InitBeforeCard(ref Card beforeCard)
        {
            if (beforeCard != null)
            {
                beforeCard.hasAttacked = false;
                beforeCard.hasBeenChosen = false;
            }
            beforeCard = null;
        }

        private void ChangeState_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true && Game.recentDuelCardAttack != null)
            {
                if (Game.recentDuelCardAttack.status == "攻击表示")
                {
                    Game.recentDuelCardAttack.status = "防守表示";
                }
                else if (Game.recentDuelCardAttack.status == "防守表示")
                {
                    Game.recentDuelCardAttack.status = "攻击表示";
                }

                InitBeforeButton(beforeChosenButton1);
                InitBeforeCard(ref Game.recentDuelCardAttack);

                ++duelGame.timesAmount;
                ShowNewTable();
            }
        }

        private void TansSpeakerPlayerButton_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                duelGame.TransformSpeakerPlayer();
                InitBeforeCard(ref Game.recentDuelCardAttack);
                InitBeforeCard(ref Game.recentDuelCardAttacked);
                InitDuelCard(duelGame);
                InitBeforeButton(beforeChosenButton1);
                InitBeforeButton(beforeChosenButton2);
            }
        }

        private void InitDuelCard(Game duelGame)
        {
            CardsDuel cardDuel1 = duelGame.cardDuel1;
            CardsDuel cardDuel2 = duelGame.cardDuel2;

            InitCard(cardDuel1);
            InitCard(cardDuel2);
        }

        private void InitCard(CardsDuel cardDuel)
        {
            for (int i = 0; i < cardDuel.cards.Count; i++)
            {
                cardDuel.cards[i].hasAttacked = false;
                cardDuel.cards[i].hasBeenChosen = false;
            }

        }

        private void duelButton_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == true)
            {
                if (Game.recentDuelCardAttack != null && Game.recentDuelCardAttacked != null && Game.recentDuelCardAttack.status == "攻击表示" && Game.recentDuelCardAttack.hasAttacked == false)
                {
                    duelGame.Duel();

                    InitBeforeButton(beforeChosenButton1);
                    InitBeforeButton(beforeChosenButton2);
                    ShowNewTable();
                }
            }
        }

        private void AttackPlayer_Click(object sender, EventArgs e)
        {
            if (Game.recentDuelCardAttack != null && Game.recentDuelCardAttack.hasAttacked == false &&Game.recentDuelCardAttacked == null && duelGame.timesAmount != 1)
            {
                if (duelGame.cardDuel1.cards.Count == 0)
                {
                    duelGame.player1Life -= Convert.ToInt32(Game.recentDuelCardAttack.attack);
                }
                if (duelGame.cardDuel2.cards.Count == 0)
                {
                    duelGame.player2Life -= Convert.ToInt32(Game.recentDuelCardAttack.attack);
                }
                InitBeforeCard(ref Game.recentDuelCardAttack);
                InitBeforeButton(beforeChosenButton1);
                Game.recentDuelCardAttack.hasAttacked = true;

                ShowNewTable();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
