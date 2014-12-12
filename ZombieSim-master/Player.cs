using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Zombie_Sim
{
    //2014/12/12: This class has been created from the class Person but I changed some things such as the Move function, because the player moves with the input of the user.
    //J'ai créé cette classe à partir de la classe Person, mais j'ai changé quelques trucs comme la fonction Move, puisque les mouvements du joueur sont décidés selon les actions de l'utilisateur.
    class Player:Sentient
    {
        public const int MOVE_DISTANCE_MAX = 10;
        //public const int SPOT_DISTANCE = 25;
        protected enum MentalState { Calm, Panicked, Aggressive, OnFire, Hunter };
        protected static Color[] ModeColors = new Color[]{Color.Cyan, Color.Yellow, Color.Blue, Color.Orange, Color.Violet};        
        protected const int WalkDistance = 5;
        protected const int RunDistance = WalkDistance * 3;
        //2014/12/12: Instead of changing colors with the different modes, I change the images.
        // Au lieu de changer les couleurs selon les modes, je change les images.
        protected static Bitmap[] ModeImages = new Bitmap[] { Properties.Resources.player, Properties.Resources.playerpanicked, Properties.Resources.playerattack, Properties.Resources.person, Properties.Resources.person };
        private MentalState DefaultMode;
        private MentalState Mode;
        private int Strength;
        private int Courage;        

        public Player(int x, int y, int h, int s, int c, Bitmap da)
        {
            image = Properties.Resources.player;
            ID = IDC++;
            attackers = new Queue<Sentient>();
            location = new Rectangle(x, y, DrawWidth, DrawWidth);
            Health = h;
            MaxHealth = Health;
            Strength = s;
            Courage = c;
            Mode = MentalState.Calm;
            DrawColor = ModeColors[(int)Mode];
            image = ModeImages[(int)Mode];
            DrawArea = da;
            Fighting = false;
            MoveDistance = MOVE_DISTANCE_MAX;
            if (rnd == null)
                rnd = new Random();
        }

        public Player(Rectangle r, int h, int s, int c, Bitmap da)
        {
            image = Properties.Resources.player;
            ID = IDC++;
            attackers = new Queue<Sentient>();
            location = r;
            Health = h;
            MaxHealth = Health;
            Strength = s;
            Courage = c;
            DefaultMode = MentalState.Calm;
            Mode = DefaultMode;
            DrawColor = ModeColors[(int)Mode];
            image = ModeImages[(int)Mode];
            DrawArea = da;
            Fighting = false;
            MoveDistance = WalkDistance;
            if (rnd == null)
                rnd = new Random();
        }

        ~Player()
        {
            removeReference(this);
        }
        public override void Move()
        {

            if (!Fighting)
            {
                Heal();

                Rectangle r;
                bool good;
                do
                {
                    good = true /*MoveDistance >= Math.Sqrt(dx * dx + dy * dy)*/;
                    r = new Rectangle(location.Left, location.Top, DrawWidth, DrawWidth);
                    good = (r.Left >= 0) && (r.Right <= DrawArea.Width);
                    good = good & (r.Top >= 0) && (r.Bottom <= DrawArea.Height);
                    LinkedListNode<Building> bn = Buildings.First;
                    /*LinkedListNode<Sentient> sn = Sentients.Find(this).Next;*/
                    while ((bn != null /*|| sn != null*/) && good)
                    {
                        if (bn != null)
                        {
                            good = !(r.IntersectsWith(bn.Value.getSurface()));
                            bn = bn.Next;
                        }
                        /*
                        if(sn != null && good)
                        {
                            good = !(r.IntersectsWith(sn.Value.getLocation()));
                            sn = sn.Next;
                        }
                         */
                    }
                } while (!good);
                location = r;
            }
        }
        public void Move(int dx,int dy)
        {

            if (!Fighting)
            {
                Heal();
           
                Rectangle r;
                bool good;
                good = true /*MoveDistance >= Math.Sqrt(dx * dx + dy * dy)*/;
                r = new Rectangle(location.Left+dx, location.Top + dy, DrawWidth, DrawWidth);
                good = (r.Left >= 0) && (r.Right <= DrawArea.Width);
                good = good & (r.Top >= 0) && (r.Bottom <= DrawArea.Height);
                LinkedListNode<Building> bn = Buildings.First;
                /*LinkedListNode<Sentient> sn = Sentients.Find(this).Next;*/
                while ((bn != null /*|| sn != null*/) && good)
                {
                    if(bn != null)
                    {
                        good = !(r.IntersectsWith(bn.Value.getSurface()));
                        bn = bn.Next;
                    }
                    /*
                    if(sn != null && good)
                    {
                        good = !(r.IntersectsWith(sn.Value.getLocation()));
                        sn = sn.Next;
                    }
                        */
                }
                if (good)
                {
                    location = r;
                }
            }       
        }

        public override void Update()
        {            
            Mode = DefaultMode;
            if (!Fighting)
            {
                int closest = SpotDistance;
                LinkedListNode<Sentient> sn = Sentients.First;
                while (sn != null && attackers.Count == 0)
                {
                    if (sn.Value is Zombie)
                    {
                        if (location.IntersectsWith(sn.Value.getLocation()))
                        {
                            attackers.Enqueue(sn.Value);
                            Mode = MentalState.Aggressive;
                            sn.Value.addToAttackers(this);
                        }
                        else
                        {
                            int dx = location.Left - sn.Value.getLocation().Left;
                            int dy = location.Top - sn.Value.getLocation().Top;
                            int d = (int)Math.Ceiling(Math.Sqrt(dx * dx + dy * dy));
                            if (d < closest)
                            {
                                closest = d;
                                target = sn.Value;
                            }
                        }
                    }
                    sn = sn.Next;
                }
                if (attackers.Count > 0)
                {
                    target = attackers.Dequeue();
                    Fighting = true;
                    Mode = MentalState.Aggressive;
                }
                if (Mode == MentalState.Calm && closest < SpotDistance)
                {
                    if (rnd.Next(1, 10) > Courage)
                        Mode = MentalState.Panicked;
                    else
                        Mode = MentalState.Aggressive;
                }
            }
            else
            {
                if (target == null)
                {
                    Fighting = false;
                    Update();
                    return;
                }
                target.attack((int)Math.Floor(rnd.NextDouble() * Strength));
            }
            image = ModeImages[(int)Mode];
        }

        public override void attack(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                removeReference(this);
                
                LinkedListNode<Sentient> sn = Sentients.Find(this);
                LinkedListNode<Sentient> zn = new LinkedListNode<Sentient>(new Zombie(location, rnd.Next(3, 11), DrawArea));
                if (sn == null)
                {
                    Sentients.AddLast(zn);
                    Sentients.Remove(this);
                }
                else
                {                
                    Sentients.AddAfter(sn, zn);
                    Sentients.Remove(this);
                }

                Draw(true);
            }
        }
        public bool isAlive()
        {
            if (Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
