using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WeAreCarsRental
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblTitle;
        private PictureBox picLogo;
        private Panel pnlSide;
        private Label lblAppName;
        private Label lblTagline;
        private const string VALID_USERNAME = "sta001";
        private const string VALID_PASSWORD = "givemethekeys123";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(67)))));
            this.pnlSide.Controls.Add(this.lblTagline);
            this.pnlSide.Controls.Add(this.lblAppName);
            this.pnlSide.Controls.Add(this.picLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(400, 700);
            this.pnlSide.TabIndex = 6;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(100, 120);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(28, 350);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(345, 51);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Car Rental System";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(177)))), ((int)(((byte)(214)))));
            this.lblTagline.Location = new System.Drawing.Point(68, 415);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(264, 25);
            this.lblTagline.TabIndex = 2;
            this.lblTagline.Text = "The smart way to rent a car";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(67)))));
            this.lblTitle.Location = new System.Drawing.Point(510, 120);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Staff Login";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(515, 250);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(97, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(515, 340);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(91, 25);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtUsername.Location = new System.Drawing.Point(515, 280);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(550, 39);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtPassword.Location = new System.Drawing.Point(515, 370);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(550, 39);
            this.txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(80)))), ((int)(((byte)(141)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(515, 460);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(550, 60);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental System - Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == VALID_USERNAME && txtPassword.Text == VALID_PASSWORD)
            {
                // Create a new instance of the BookingForm
                BookingForm bookingForm = new BookingForm();

                // Show the form
                bookingForm.Show();

                // Hide the current form
                this.Hide();

                // Add this to close the login form when booking form is closed
                bookingForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                // Display error message for invalid credentials
                MessageBox.Show("Invalid username or password", "Login Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           
       

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Create a car icon for the logo
            Bitmap logoBitmap = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(logoBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(36, 41, 67));

                // Draw a circle background
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(67, 80, 141)))
                {
                    g.FillEllipse(brush, 15, 15, 170, 170);
                }

                // Draw a simplified car
                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    // Car body
                    using (GraphicsPath bodyPath = CreateRoundedRectangle(new Rectangle(40, 75, 120, 45), 10))
                    {
                        g.FillPath(whiteBrush, bodyPath);
                    }

                    // Car top
                    Point[] roofPoints = {
                        new Point(60, 75),
                        new Point(80, 40),
                        new Point(120, 40),
                        new Point(140, 75)
                    };
                    g.FillPolygon(whiteBrush, roofPoints);

                    // Wheels
                    using (SolidBrush darkBrush = new SolidBrush(Color.FromArgb(36, 41, 67)))
                    {
                        g.FillEllipse(darkBrush, 55, 115, 25, 25);
                        g.FillEllipse(darkBrush, 120, 115, 25, 25);
                    }
                }
            }

            picLogo.Image = logoBitmap;

            // Round the login button corners
            SetButtonRoundedCorners(btnLogin);
        }

        // Helper method to create rounded rectangles
        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;

            // Top left corner
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);

            // Top right corner
            path.AddArc(rect.Width - diameter + rect.X, rect.Y, diameter, diameter, 270, 90);

            // Bottom right corner
            path.AddArc(rect.Width - diameter + rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 0, 90);

            // Bottom left corner
            path.AddArc(rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Helper method to set rounded corners on a button
        private void SetButtonRoundedCorners(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 30, 30, 180, 90);
            path.AddArc(button.Width - 30, 0, 30, 30, 270, 90);
            path.AddArc(button.Width - 30, button.Height - 30, 30, 30, 0, 90);
            path.AddArc(0, button.Height - 30, 30, 30, 90, 90);
            path.CloseAllFigures();

            button.Region = new Region(path);
        }
    }
}