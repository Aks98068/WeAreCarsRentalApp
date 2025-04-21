using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using WeAreCarsRental.Models;

namespace WeAreCarsRental
{
    public partial class CarListForm : Form
    {
        private ListView listViewCars;
        private List<Car> cars;

        // Modern UI colors
        private readonly Color primaryColor = Color.FromArgb(0, 122, 204);
        private readonly Color accentColor = Color.FromArgb(28, 28, 28);
        private readonly Color backgroundColor = Color.FromArgb(245, 245, 245);
        private readonly Color textColor = Color.FromArgb(51, 51, 51);

        public CarListForm()
        {
            InitializeComponent();
            SetupCarListForm();
        }

        public CarListForm(List<Car> carList)
        {
            this.cars = carList;
            InitializeComponent();
            SetupCarListForm();
            LoadCarData();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "CarListForm";
            this.Text = "Available Cars";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = backgroundColor;

            this.ResumeLayout(false);
        }

        private void SetupCarListForm()
        {
            // Add header panel
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = primaryColor
            };
            this.Controls.Add(headerPanel);

            // Add title to header
            Label lblTitle = new Label
            {  
                Text = "Available Cars",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(20, 0),
                Size = new Size(400, 80),
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblTitle);

            // Add a close button in the top right
            Button btnClose = new Button
            {
                Text = "×",
                Location = new Point(955, 5),
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 18, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            headerPanel.Controls.Add(btnClose);

            // Create main panel
            Panel mainPanel = new Panel
            {
                Location = new Point(20, 100),
                Size = new Size(960, 480),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            mainPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, mainPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            this.Controls.Add(mainPanel);

            // Information label
            Label lblInfo = new Label
            {
                Text = "Cars available for rent",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(20, 15),
                Size = new Size(300, 30),
                ForeColor = textColor
            };
            mainPanel.Controls.Add(lblInfo);

            // Listview for displaying cars with modern styling
            listViewCars = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(20, 50),
                Size = new Size(920, 370),
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Add columns with better sizing
            listViewCars.Columns.Add("ID", 50);
            listViewCars.Columns.Add("Make", 120);
            listViewCars.Columns.Add("Model", 120);
            listViewCars.Columns.Add("Year", 70);
            listViewCars.Columns.Add("Type", 100);
            listViewCars.Columns.Add("Price/Day", 100);

            // Set alternating row colors for better readability
            listViewCars.OwnerDraw = true;
            listViewCars.DrawItem += (s, e) => {
                e.DrawDefault = true;
                if (e.ItemIndex >= 0)
                {
                    if (e.ItemIndex % 2 == 0)
                    {
                        e.Item.BackColor = Color.White;
                    }
                    else
                    {
                        e.Item.BackColor = Color.FromArgb(240, 240, 240);
                    }
                }
            };

            mainPanel.Controls.Add(listViewCars);

            // Button panel
            Panel buttonPanel = new Panel
            {
                Location = new Point(20, 430),
                Size = new Size(920, 40),
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(buttonPanel);

            // Close button with modern styling
            Button btnReturn = new Button
            {
                Text = "Return to Booking",
                Location = new Point(720, 0),
                Size = new Size(200, 40),
                BackColor = primaryColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.Click += BtnClose_Click;
            buttonPanel.Controls.Add(btnReturn);

            // Enable form dragging
            headerPanel.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    const int WM_NCLBUTTONDOWN = 0xA1;
                    const int HTCAPTION = 0x2;
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        private void LoadCarData()
        {
            listViewCars.Items.Clear();

            if (cars != null && cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    ListViewItem item = new ListViewItem(car.Id.ToString());
                    item.SubItems.Add(car.Make);
                    item.SubItems.Add(car.Model);
                    item.SubItems.Add(car.Year.ToString());
                    item.SubItems.Add(car.Type);
                    item.SubItems.Add($"£{car.PricePerDay:0.00}");

                    listViewCars.Items.Add(item);
                }
            }
            else
            {
                // If no cars, display a message
                ListViewItem item = new ListViewItem("No cars available");
                item.ForeColor = Color.Gray;
                item.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                listViewCars.Items.Add(item);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // P/Invoke declarations for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}