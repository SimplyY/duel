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

        public void timer1_Tick(object sender, EventArgs e)
        {
            GameStatus.ShowGameStatus(showStatusBox);
        }
        public Form1()
        {
            InitializeComponent();
            InitGame();
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
            showNewTable();
        }

        private void PlayerBotton2_Click(object sender, EventArgs e)
        {
            duelGame.PickACard(2);
            showNewTable();
        }

        public void showNewTable()
        {
            duelGame.cardManager1.;
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





    }
}
