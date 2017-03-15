using System;
using System.Windows.Forms;

namespace FormExample
{
    public class Program : Form1
    {

        public static SlideSprite elephant;


        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);
            //Console.WriteLine("asdffasdf");
            if (e.KeyCode == Keys.Left) elephant.TargetX -= 30;
            if (e.KeyCode == Keys.Right) elephant.TargetX += 30;
            if (e.KeyCode == Keys.Up) elephant.TargetY -= 30;
            if (e.KeyCode == Keys.Down) elephant.TargetY += 30;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            elephant = new SlideSprite(Properties.Resources.elephant);
            elephant.TargetX = 100;
            elephant.TargetY = 100;
            elephant.Velocity = 5;
            canvas.add(elephant);
            Application.Run(new Program());
        }
    }
}
