using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WeAreCarsRental
{
    public partial class SplashScreen : Form
    {
        private Timer timer;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.timer = new System.Windows.Forms.Timer();
            this.SuspendLayout();

            // ===== Timer =====
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            // ===== SplashScreen (Modern, Fullscreen) =====
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.SteelBlue;
            this.Size = new Size(1200, 700); // 💡 Custom size here
            this.DoubleBuffered = true;
            this.Name = "SplashScreen";
            this.Text = "Car Rental System";
            this.Load += new EventHandler(this.SplashScreen_Load);
            this.Paint += new PaintEventHandler(this.SplashScreen_Paint);

            this.ResumeLayout(false);
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void SplashScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Fonts
            Font titleFont = new Font("Segoe UI", 48, FontStyle.Bold);
            Font subtitleFont = new Font("Segoe UI", 20, FontStyle.Regular);
            Font noteFont = new Font("Segoe UI", 14, FontStyle.Italic);

            // Format
            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Draw text elements
            g.DrawString("🚗 WeAreCars", titleFont, new SolidBrush(Color.FromArgb(0, 255, 220)),
                new RectangleF(0, this.Height / 2 - 120, this.Width, 70), centerFormat);

            g.DrawString("Smart Car Rentals at Your Fingertips", subtitleFont, Brushes.WhiteSmoke,
                new RectangleF(0, this.Height / 2 - 40, this.Width, 60), centerFormat);

            g.DrawString("Please wait while the system loads...", noteFont, Brushes.Wheat,
                new RectangleF(0, this.Height / 2 + 30, this.Width, 40), centerFormat);

            // Draw car icon
            int carWidth = 180;
            int carHeight = 60;
            int carX = (this.Width - carWidth) / 2;
            int carY = this.Height / 2 + 100;

            // Car body
            g.FillRectangle(new SolidBrush(Color.Black), carX, carY, carWidth, carHeight / 2);

            // Wheels
            g.FillEllipse(new SolidBrush(Color.Blue), carX + 25, carY + 25, 30, 30); // black tire
            g.FillEllipse(Brushes.Silver, carX + 30, carY + 30, 20, 20); // rim

            g.FillEllipse(new SolidBrush(Color.Blue), carX + 125, carY + 25, 30, 30); // black tire
            g.FillEllipse(Brushes.Silver, carX + 130, carY + 30, 20, 20); // rim
        }

    }
}
