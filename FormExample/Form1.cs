using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;


namespace FormExample
{
    public partial class Form1 : Form
    {
        public static Form form;
        public static int fps = 60;
        public Thread rendering;
        public Thread updating;
        public static Sprite canvas = new Sprite();


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            rendering = new Thread(new ThreadStart(render));
            updating = new Thread(new ThreadStart(update));
            rendering.Start();
            updating.Start();


        }

        public static void render()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds< frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime-diff).Milliseconds);
                last = DateTime.Now;
                form.Invoke(new MethodInvoker(form.Refresh));

            }
        }

        private void update()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime - diff).Milliseconds);
                last = DateTime.Now;
                canvas.update();

            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            rendering.Abort();
            updating.Abort();
        }

        protected override void OnResize(EventArgs e)
        {

            
            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            base.OnMouseDown(e);
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Refresh();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            canvas.render(e.Graphics);
        }


    }
    
}
