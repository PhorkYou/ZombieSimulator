using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Zombie_Sim
{
    //2014/12/12: The ApplicationContext is the class runned by the program and it manages all the forms. Thanks to that, we can pass variables easily between different forms. The Game variable in this case.
    // La classe ApplicationContext est la classe qui gère tous les forms. On peut donc facilement l'utiliser pour passer des variables entre les forms. La variable Game dans ce cas-ci.
    public class ApplicationContext : System.Windows.Forms.ApplicationContext
    {
        static ApplicationContext instance;
        frmMenu menu;
        frmSim sim;
        frmControls controls;
        private Game game;

        internal Game Game
        {
            get { return game; }
            set { game = value; }
        }
        public ApplicationContext()
        {
            game = new Game(10,10,5,5,20,10,20,10,20,8,4,10,1,10,20,10,10,Color.Black,Color.Gray,200,false);
            menu = new frmMenu();
            menu.Show();
        }
        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }

            private set
            {

            }



        }
        public void openControls()
        {
            controls = new frmControls();
            controls.Show();
        }
        public void openSim()
        {
            sim = new frmSim();
            sim.Show();
        }
        public void openMenu()
        {
            sim = null;
            menu = new frmMenu();
            menu.Show();
            if (controls!=null)
            {
                controls.Close();
            }
        }
        public bool simVisible()
        {
            if (sim!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void startGame(int minS, int maxS, int minB, int maxB, double zbPer, int minZH, int maxZH, int minPH, int maxPH, int zS, int minPS, int maxPS, int minPC, int maxPC, int plH, int plS, int plC,Color back,Color build,int spot,bool player)
        {
            game = new Game(minS, maxS, minB, maxB, zbPer, minZH, maxZH, minPH, maxPH, zS, minPS, maxPS, minPC, maxPC, plH, plS, plC,back,build,spot,player);
        }
    }
}
