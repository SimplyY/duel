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
        private double gameTime;

        public void timer1_Tick(object sender, EventArgs e)
        {
            GameStatus.ShowGameStatus(showStatusBox);
            gameTime += 0.2;
        }
        public Form1()
        {
            InitializeComponent();
            InitDuelTextBox();
            InitGame();
        }

        public void showNewTable()
        {
            duelGame.cardManager1.showManager();
            duelGame.cardManager2.showManager();
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
        }

        private void InitGame()
        {
            timer1.Enabled = true; //设置为truetimer1_Tick实践就会执行，开始计时
            timer1.Interval = 200; //设置timer1的timer1_Tick实践执行周期
            gameTime = 0;
            duelGame = new Game();
        }

        private void playerBotton1_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(1);
            showNewTable();
            if (duelGame.speakPlayer == 1)
            {
                duelGame.TransformSpeakerPlayer();
            }
        }

        private void PlayerBotton2_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(2);
            showNewTable();
            if (duelGame.speakPlayer == 2)
            {
                duelGame.TransformSpeakerPlayer();
            }
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





    }
}
