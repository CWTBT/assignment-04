using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
namespace FormExample
{
    public class Sprite
    {
        private Sprite parent = null;

        //instance variable
        private float x = 0;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private float rotation = 0;

        /// <summary>
        /// The rotation in degrees.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public List<Sprite> children = new List<Sprite>();


        public void Kill()
        {
            parent.children.Remove(this);
        }

        //methods
        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.TranslateTransform(x, y);
            g.ScaleTransform(scale, scale);
            g.RotateTransform(rotation);
            paint(g);
            foreach (Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public void update()
        {
            act();
            foreach (Sprite s in children)
            {
                s.update();
            }

        }

        public virtual void paint(Graphics g)
        {

        }

        public virtual void act()
        {
           
        }

        public void add(Sprite s)
        {
            s.parent = this;
            children.Add(s);
        }



    }

    public class SlideSprite : Sprite
    {
        public float TargetX;
        public float TargetY;
        public float Velocity;
        Image img;

        public override void act()
        {
            if (X + Velocity < TargetX) X += Velocity;
            else if (X - Velocity > TargetX) X -= Velocity;
            else X = TargetX;
            if (Y + Velocity < TargetY) Y += Velocity;
            else if (Y - Velocity > TargetY) Y -= Velocity;
            else Y = TargetY;
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(img, X, Y);
            base.paint(g);
        }

        public SlideSprite(Image input)
        {
            X = 0;
            Y = 0;
            img = input;
        }




    }
}
