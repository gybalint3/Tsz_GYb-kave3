using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tsz_GYb_kávé
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Resize += (s, e) => Lekerekit(panel1, 10);
            Lekerekit(panel1, 10);

            panel2.Resize += (s, e) => Lekerekitp2(panel2, 10);
            Lekerekitp2(panel2, 10);


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
            this.ClientRectangle,
            Color.FromArgb(13, 21, 58),  // Felső sötétkék
                Color.FromArgb(29, 40, 119), // Alsó világosabb kék
            LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Lekerekit(Panel panel1, int sarok)
        {
            int r = Math.Min(sarok, Math.Min(panel1.Width, panel1.Height) / 2);
            int d = r * 2;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(panel1.Width - d, 0, d, d, 270, 90);
            path.AddArc(panel1.Width - d, panel1.Height - d, d, d, 0, 90);
            path.AddArc(0, panel1.Height - d, d, d, 90, 90);

            path.CloseFigure();

            Region regi = panel1.Region;
            panel1.Region = new Region(path);

            regi?.Dispose();
            path.Dispose();
        }

        private void Lekerekitp2(Panel panel2, int sarok)
        {
            int r = Math.Min(sarok, Math.Min(panel2.Width, panel2.Height) / 2);
            int d = r * 2;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(panel2.Width - d, 0, d, d, 270, 90);
            path.AddArc(panel2.Width - d, panel2.Height - d, d, d, 0, 90);
            path.AddArc(0, panel2.Height - d, d, d, 90, 90);

            path.CloseFigure();

            Region regi = panel2.Region;
            panel2.Region = new Region(path);

            regi?.Dispose();
            path.Dispose();
        }

    }
}
