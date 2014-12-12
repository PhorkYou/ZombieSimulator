using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Zombie_Sim
{
    class Building
    {
        protected static Color DrawColor = ApplicationContext.Instance.Game.Buildings;
        protected static Color EraseColor = ApplicationContext.Instance.Game.Background;

        protected Rectangle surface; //rectangle used for intersection logic
        protected Bitmap DrawArea;

        
        public Building(int x, int y, int h, int w, Bitmap da)
        {
            surface = new Rectangle(x, y, w, h);
            DrawArea = da;
        }

        public Building(Rectangle r, Bitmap da)
        {
            surface = r;
            DrawArea = da;
        }

        public Rectangle getSurface()
        {
            return surface;
        }

        //draw code
        public void Draw(bool erase)
        {
            Color c = erase?EraseColor:DrawColor;
            SolidBrush Brush = new SolidBrush(c);
            Graphics g = Graphics.FromImage(DrawArea);
            g.FillRectangle(Brush, surface);
            g.Dispose();
        }
        

    }
}
