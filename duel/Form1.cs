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

        private Button beforeChosenToAttackButton;
        private Button beforeChosenToAttackedButton;

        public Form1()
        {
            gameHasStarted = false;
            InitializeComponent();
            InitTextBoxes();
        }

        //InitTextBoxes
        private void InitTextBoxes()
        {
            InitManagerBoxes();
            InitDuelBoxes();
            InitfactoryCardsAmountBoxes();
            InitLifeBoxes();
        }

        private void InitManagerBoxes()
        {
            DuelTextBoxes.managerBoxes = new List<TextBox>();

            DuelTextBoxes.managerBoxes.Add(textBox1);
            DuelTextBoxes.managerBoxes.Add(textBox2);
            DuelTextBoxes.managerBoxes.Add(textBox3);
            DuelTextBoxes.managerBoxes.Add(textBox4);
            DuelTextBoxes.managerBoxes.Add(textBox5);

            DuelTextBoxes.managerBoxes.Add(textBox16);
            DuelTextBoxes.managerBoxes.Add(textBox17);
            DuelTextBoxes.managerBoxes.Add(textBox18);
            DuelTextBoxes.managerBoxes.Add(textBox19);
            DuelTextBoxes.managerBoxes.Add(textBox20);
        }

        private void InitDuelBoxes()
        {
            DuelTextBoxes.duelBoxes = new List<TextBox>();

            DuelTextBoxes.duelBoxes.Add(textBox6);
            DuelTextBoxes.duelBoxes.Add(textBox7);
            DuelTextBoxes.duelBoxes.Add(textBox8);
            DuelTextBoxes.duelBoxes.Add(textBox9);
            DuelTextBoxes.duelBoxes.Add(textBox10);

            DuelTextBoxes.duelBoxes.Add(textBox11);
            DuelTextBoxes.duelBoxes.Add(textBox12);
            DuelTextBoxes.duelBoxes.Add(textBox13);
            DuelTextBoxes.duelBoxes.Add(textBox14);
            DuelTextBoxes.duelBoxes.Add(textBox15);
        }

        private void InitfactoryCardsAmountBoxes()
        {
            DuelTextBoxes.factoryCardsAmountBoxes = new List<TextBox>();

            DuelTextBoxes.factoryCardsAmountBoxes.Add(Favtory1CardsAmountTextBox);
            DuelTextBoxes.factoryCardsAmountBoxes.Add(Favtory2CardsAmountTextBox);
        }

        private void InitLifeBoxes()
        {
            DuelTextBoxes.lifeBoxes = new List<TextBox>();

            DuelTextBoxes.lifeBoxes.Add(playerLife1);
            DuelTextBoxes.lifeBoxes.Add(playerLife2);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //show textBoxes
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

        //click the button to start Game
        private void StartGame_Click(object sender, EventArgs e)
        {
            if (gameHasStarted == false)
            {
                Button startGameButton = (Button)sender;

                InitGame();
                ShowNewTable();
                startGameButton.Text = "游戏已经开始";
            }
        }

        public void InitGame()
        {
            timer1.Enabled = true; //设置为truetimer1_Tick实践就会执行，开始计时
            timer1.Interval = 200; //设置timer1的timer1_Tick实践执行周期

            duelGame = new Game();
            gameHasStarted = true;
        }

        //pick card
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

        //send card
        private void SendToDuel1_Click(object sender, EventArgs e)
        {
            SentACardToDuel(sender, 1);
        }

        private void SendToDuel2_Click(object sender, EventArgs e)
        {
            SentACardToDuel(sender, 2);
        }

        private void SentACardToDuel(object sender, int duelNumber)
        {
            if (gameHasStarted == true)
            {
                Button button = (Button)sender;
                int tag = Convert.ToInt32(button.Tag);
                int cardIndex = getIndexFromTag(tag, duelNumber);
                duelGame.SendACardToDuel(cardIndex, duelNumber);

                ShowNewTable();
            }
        }

        //tag is inited by a special way that has connection with index
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

        //chooseDuelButton
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
                            InitBeforeButton(beforeChosenToAttackButton);
                        }

                        Game.recentDuelCardAttack = duelGame.cardDuel1.cards[cardIndex];
                        Game.recentDuelCardAttack.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenToAttackButton = button;
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
                            InitBeforeButton(beforeChosenToAttackedButton);
                        }

                        Game.recentDuelCardAttacked = duelGame.cardDuel1.cards[cardIndex];
                        Game.recentDuelCardAttacked.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenToAttackedButton = button;
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
                            InitBeforeButton(beforeChosenToAttackButton);
                        }

                        Game.recentDuelCardAttack = duelGame.cardDuel2.cards[cardIndex];
                        Game.recentDuelCardAttack.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenToAttackButton = button;
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
                            InitBeforeButton(beforeChosenToAttackedButton);
                        }

                        Game.recentDuelCardAttacked = duelGame.cardDuel2.cards[cardIndex];
                        Game.recentDuelCardAttacked.hasBeenChosen = true;

                        button.Text = "已被选中";
                        beforeChosenToAttackedButton = button;
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

                InitBeforeButton(beforeChosenToAttackButton);

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
                InitBeforeButton(beforeChosenToAttackButton);
                InitBeforeButton(beforeChosenToAttackedButton);
                ++duelGame.timesAmount;

                ShowNewTable();
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

                    InitBeforeButton(beforeChosenToAttackButton);
                    InitBeforeButton(beforeChosenToAttackedButton);
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

                Game.recentDuelCardAttack.hasAttacked = true;
                InitBeforeButton(beforeChosenToAttackButton);

                ShowNewTable();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showStatusBox_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
