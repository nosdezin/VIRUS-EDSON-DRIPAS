using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cleanUnity
{
    public partial class popup : Form
    {
        private Image image = null;
        public popup()
        {
            InitializeComponent();
            image = Image.FromFile(@"C:\CleanUnity\assets\imagem.jpg");

            this.Width = image.Width;
            this.Height = image.Height;

            int x = new Random(Guid.NewGuid().GetHashCode()).Next(0, Screen.PrimaryScreen.Bounds.Width - image.Width);
            int y = new Random(Guid.NewGuid().GetHashCode()).Next(0, Screen.PrimaryScreen.Bounds.Height - image.Height);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
        }

        private void FormShown(object sender, EventArgs e)
        {
            int Limit = 10;
            int count = 0;
            Process[] processes = Process.GetProcesses();
            foreach (Process pr in processes)
            {
                if (pr.ProcessName.Equals("cleanUnity"))
                {
                    count++;
                }
            }
            if (count < Limit)
            {
                Process.Start("cleanUnity.exe");
            }
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(image, 0, 0, image.Width, image.Height);
            gr.Dispose();
        }
    }
}
