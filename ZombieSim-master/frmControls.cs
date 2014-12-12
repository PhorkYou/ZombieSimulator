using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zombie_Sim
{
    public partial class frmControls : Form
    {
        //2014/12/12: I added  the player controls(arrows) on this form(and the clicks).
        //Changement de la fenêtre des contrôles pour ajouter les flèches(et les clics).
        public frmControls()
        {
            InitializeComponent();
            lblHelp.Text = "Command              Key \n" +
               "------------------------------------ \n" +
               "This Screen           c \n" +
               "Speed Up              +  \n" +
               "Speed Down          -  \n" +
               "Reset                     r  \n" +
               "Start/Pause       Space\n" +
               "Player                Arrows\n"+
               "Left-Click           Spawn zombie\n"+
               "Right-Click         Spawn person\n"+  
               "Quit                     Esc \n\n\n" +
               "Resize the window and Reset the game \n" +
               "to change the play area size\n";
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}