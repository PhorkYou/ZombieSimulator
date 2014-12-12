using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zombie_Sim
{
    public partial class frmMenu : Form
    {
        //2014/12/12: This is a whole form I created. Before starting the game, you can choose the settings of the game.
        //C'est un form que j'ai créé. Avant de commencer une partie, on peut choisir les paramètres de la partie.
        Color background=Color.Black;
        Color buildings=Color.Gray;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericUpDown2.Value || numericUpDown3.Value > numericUpDown4.Value || numericUpDown6.Value > numericUpDown7.Value || numericUpDown8.Value > numericUpDown9.Value || numericUpDown11.Value > numericUpDown10.Value || numericUpDown14.Value > numericUpDown13.Value)
            {
                MessageBox.Show("Les maximums ne peuvent pas être plus bas que les minimums!");
            }
            else
            {
                ApplicationContext.Instance.startGame((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value, (double)numericUpDown5.Value, (int)numericUpDown6.Value, (int)numericUpDown7.Value, (int)numericUpDown8.Value, (int)numericUpDown9.Value, (int)numericUpDown12.Value, (int)numericUpDown11.Value, (int)numericUpDown10.Value, (int)numericUpDown14.Value, (int)numericUpDown13.Value, (int)numericUpDown17.Value, (int)numericUpDown18.Value, (int)numericUpDown19.Value,background,buildings,(int)numericUpDown15.Value,checkBox1.Checked);
                ApplicationContext.Instance.openSim();
                this.Close();
            }
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!ApplicationContext.Instance.simVisible())
            {
                Application.Exit();
            }

        }

        private void frmMenu_Shown(object sender, EventArgs e)
        {
            numericUpDown1.Value = ApplicationContext.Instance.Game.MinSentients;
            numericUpDown2.Value = ApplicationContext.Instance.Game.MaxSentients;
            numericUpDown3.Value = ApplicationContext.Instance.Game.MinBuildings;
            numericUpDown4.Value = ApplicationContext.Instance.Game.MaxBuildings;
            numericUpDown5.Value = (int)ApplicationContext.Instance.Game.ZombiePercentage;

            numericUpDown6.Value = ApplicationContext.Instance.Game.MinZombieHealth;
            numericUpDown7.Value = ApplicationContext.Instance.Game.MaxZombieHealth;
            numericUpDown8.Value = ApplicationContext.Instance.Game.MinPersonHealth;
            numericUpDown9.Value = ApplicationContext.Instance.Game.MaxPersonHealth;

            numericUpDown12.Value = ApplicationContext.Instance.Game.ZombieStrength;
            numericUpDown11.Value = ApplicationContext.Instance.Game.MinPersonStrength;
            numericUpDown10.Value = ApplicationContext.Instance.Game.MaxPersonStrength;

            numericUpDown14.Value = ApplicationContext.Instance.Game.MinPersonCourage;
            numericUpDown13.Value = ApplicationContext.Instance.Game.MaxPersonCourage;

            numericUpDown17.Value = ApplicationContext.Instance.Game.PlayerHealth;
            numericUpDown18.Value = ApplicationContext.Instance.Game.PlayerStrength;
            numericUpDown19.Value = ApplicationContext.Instance.Game.PlayerCourage;

            numericUpDown17.Enabled = false;
            numericUpDown18.Enabled = false;
            numericUpDown19.Enabled = false;

            colorDialog1.Color = Color.Black;
            colorDialog2.Color = Color.Gray;

            numericUpDown15.Value = ApplicationContext.Instance.Game.SpotDistance;
            checkBox1.Checked = ApplicationContext.Instance.Game.Player;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                background = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                buildings = colorDialog1.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown17.Enabled = !numericUpDown17.Enabled;
            numericUpDown18.Enabled = !numericUpDown18.Enabled;
            numericUpDown19.Enabled = !numericUpDown19.Enabled;
        }
    }
}
