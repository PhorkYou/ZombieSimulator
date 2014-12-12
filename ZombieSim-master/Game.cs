using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Zombie_Sim
{
    class Game
    {
        //2014/12/12: The Game class is a way to stock some of the data of the game itself. I use this class between all the forms.
        // La classe Game est une façon de stocker les données du jeu lui-même. Je partage mon instance de cette classe dans tous les forms.
        private int minSentients;
        private int maxSentients;
        private int minBuildings;
        private int maxBuildings;
        private double zombiePercentage;

        private int minZombieHealth;
        private int maxZombieHealth;
        private int minPersonHealth;
        private int maxPersonHealth;

        private int zombieStrength;
        private int minPersonStrength;
        private int maxPersonStrength;

        private int minPersonCourage;
        private int maxPersonCourage;

        private int playerHealth;
        private int playerStrength;
        private int playerCourage;

        private Color background;
        private Color buildings;

        private int spotDistance;
        private bool player;

        public bool Player
        {
            get { return player; }
            set { player = value; }
        }

        public int SpotDistance
        {
            get { return spotDistance; }
            set { spotDistance = value; }
        }

        public Color Background
                {
                    get { return background; }
                    set { background = value; }
                }
        public Color Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        public int MinZombieHealth
        {
            get { return minZombieHealth; }
            set { minZombieHealth = value; }
        }
        public int MaxZombieHealth
        {
            get { return maxZombieHealth; }
            set { maxZombieHealth = value; }
        }
        public int MinPersonHealth
        {
            get { return minPersonHealth; }
            set { minPersonHealth = value; }
        }
        public int MaxPersonHealth
        {
            get { return maxPersonHealth; }
            set { maxPersonHealth = value; }
        }
        public int ZombieStrength
        {
            get { return zombieStrength; }
            set { zombieStrength = value; }
        }
        public int MinPersonStrength
        {
            get { return minPersonStrength; }
            set { minPersonStrength = value; }
        }
        public int MaxPersonStrength
        {
            get { return maxPersonStrength; }
            set { maxPersonStrength = value; }
        }
        public int MinPersonCourage
        {
            get { return minPersonCourage; }
            set { minPersonCourage = value; }
        }
        public int MaxPersonCourage
                {
                    get { return maxPersonCourage; }
                    set { maxPersonCourage = value; }
                }
        public int PlayerHealth
        {
            get { return playerHealth; }
            set { playerHealth = value; }
        }
        public int PlayerStrength
                {
                    get { return playerStrength; }
                    set { playerStrength = value; }
                }
        public int PlayerCourage
        {
            get { return playerCourage; }
            set { playerCourage = value; }
        }

        public int MinSentients
        {
            get { return minSentients; }
            set { minSentients = value; }
        }
        

        public int MaxSentients
        {
            get { return maxSentients; }
            set { maxSentients = value; }
        }
        

        public int MinBuildings
        {
            get { return minBuildings; }
            set { minBuildings = value; }
        }
        

        public int MaxBuildings
        {
            get { return maxBuildings; }
            set { maxBuildings = value; }
        }
        

        public double ZombiePercentage
        {
            get { return zombiePercentage; }
            set { zombiePercentage = value; }
        }
        public Game(int minS,int maxS,int minB,int maxB,double zbPer,int minZH,int maxZH,int minPH,int maxPH,int zS, int minPS,int maxPS,int minPC,int maxPC,int plH,int plS,int plC,Color back,Color build,int spot,bool player)
        {
            minSentients = minS;
            maxSentients = maxS;
            minBuildings = minB;
            maxBuildings = maxB;
            zombiePercentage = zbPer;
            
            minZombieHealth=minZH;
            maxZombieHealth=maxZH;
            minPersonHealth=minPH;
            maxPersonHealth=maxPH;

            zombieStrength=zS;
            minPersonStrength=minPS;
            maxPersonStrength=maxPS;

            minPersonCourage=minPC;
            maxPersonCourage=maxPC;

            playerHealth=plH;
            playerStrength=plS;
            playerCourage=plC;

            background = back;
            buildings = build;

            spotDistance = spot;
            this.player = player;
        }

    }
}
