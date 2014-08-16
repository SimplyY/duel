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
        private Game duelGame { get; set; }
        private double gameTime;

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (gameTime == 0)
            {
                InitDuelTextBox();
            }
            GameStatus.ShowGameStatus(showStatusBox);
            gameTime += 0.2;
        }
        public Form1()
        {
            InitializeComponent();

            InitGame();
        }

        public void showNewTable()
        {
        }

        private void InitDuelTextBox()
        {
            DuelTextBoxs.Boxs = new List<TextBox>();

            DuelTextBoxs.Boxs.Add(textBox1);
            DuelTextBoxs.Boxs.Add(textBox2);
            DuelTextBoxs.Boxs.Add(textBox3);
            DuelTextBoxs.Boxs.Add(textBox4);
            DuelTextBoxs.Boxs.Add(textBox5);
            DuelTextBoxs.Boxs.Add(textBox6);
            DuelTextBoxs.Boxs.Add(textBox7);
            DuelTextBoxs.Boxs.Add(textBox8);
            DuelTextBoxs.Boxs.Add(textBox9);
            DuelTextBoxs.Boxs.Add(textBox10);
            DuelTextBoxs.Boxs.Add(textBox11);
            DuelTextBoxs.Boxs.Add(textBox12);
            DuelTextBoxs.Boxs.Add(textBox13);
            DuelTextBoxs.Boxs.Add(textBox14);
            DuelTextBoxs.Boxs.Add(textBox15);
            DuelTextBoxs.Boxs.Add(textBox16);
            DuelTextBoxs.Boxs.Add(textBox17);
            DuelTextBoxs.Boxs.Add(textBox18);
            DuelTextBoxs.Boxs.Add(textBox19);
            DuelTextBoxs.Boxs.Add(textBox20);
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
        }

        private void PlayerBotton2_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(2);
            showNewTable();
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
