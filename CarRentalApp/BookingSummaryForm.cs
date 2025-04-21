using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WeAreCarsRental.Models;

namespace WeAreCarsRental
{
    public class BookingSummaryForm : Form
    {
        private readonly Booking _booking;
        private Button btnConfirm;
        private Button btnCancel;
        private RichTextBox rtbSummary;

        // Modern UI colors
        private readonly Color primaryColor = Color.FromArgb(0, 122, 204);
        private readonly Color accentColor = Color.FromArgb(28, 28, 28);
        private readonly Color backgroundColor = Color.FromArgb(245, 245, 245);
        private readonly Color textColor = Color.FromArgb(51, 51, 51);
        private readonly Color successColor = Color.FromArgb(46, 175, 80);
        private readonly Color cancelColor = Color.FromArgb(209, 72, 65);

        public BookingSummaryForm(Booking booking)
        {
            _booking = booking;
            SetupSummaryForm();
            DisplaySummary();
        }

        private void SetupSummaryForm()
        {
            // Form properties
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Text = "Booking Summary";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = backgroundColor;

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
                Text = "Booking Summary",
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
                Location = new Point(755, 5),
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
                Location = new Point(50, 100),
                Size = new Size(700, 580),
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

            // Add icons for sections
            Label lblBookingIcon = new Label
            {
                Text = "📋",
                Font = new Font("Segoe UI", 24, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 15),
                Size = new Size(50, 50),
                ForeColor = primaryColor
            };
            mainPanel.Controls.Add(lblBookingIcon);

            // Add subtitle
            Label lblSubtitle = new Label
            {
                Text = "Please review your booking details",
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                Location = new Point(80, 25),
                Size = new Size(350, 30),
                ForeColor = textColor
            };
            mainPanel.Controls.Add(lblSubtitle);

            // Summary RichTextBox with improved styling
            rtbSummary = new RichTextBox
            {
                Location = new Point(30, 70),
                Size = new Size(640, 420),
                ReadOnly = true,
                Font = new Font("Segoe UI", 12),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ForeColor = textColor
            };
            rtbSummary.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, rtbSummary.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };
            mainPanel.Controls.Add(rtbSummary);

            // Button panel
            Panel buttonPanel = new Panel
            {
                Location = new Point(30, 510),
                Size = new Size(640, 60),
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(buttonPanel);

            // Confirm button with modern styling
            btnConfirm = new Button
            {
                Text = "Confirm Booking",
                Location = new Point(230, 0),
                Size = new Size(200, 50),
                BackColor = successColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += BtnConfirm_Click;
            buttonPanel.Controls.Add(btnConfirm);

            // Cancel button with modern styling
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(450, 0),
                Size = new Size(120, 50),
                BackColor = cancelColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;
            buttonPanel.Controls.Add(btnCancel);

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

        private void DisplaySummary()
        {
            if (_booking == null) return;

            rtbSummary.Clear();

            // Header
            rtbSummary.SelectionFont = new Font("Segoe UI", 16, FontStyle.Bold);
            rtbSummary.SelectionColor = primaryColor;
            rtbSummary.AppendText("BOOKING DETAILS\n\n");

            // Customer Information
            rtbSummary.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            rtbSummary.SelectionColor = primaryColor;
            rtbSummary.AppendText("Customer Information:\n");
            rtbSummary.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbSummary.SelectionColor = textColor;
            rtbSummary.AppendText($"Name: {_booking.FirstName} {_booking.LastName}\n");
            rtbSummary.AppendText($"Age: {_booking.Age}\n\n");

            // Rental Information
            rtbSummary.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            rtbSummary.SelectionColor = primaryColor;
            rtbSummary.AppendText("Rental Information:\n");
            rtbSummary.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbSummary.SelectionColor = textColor;

            // Calculate rental duration
            TimeSpan duration = _booking.EndDate - _booking.StartDate;
            int days = duration.Days;
            if (days < 1) days = 1;

            rtbSummary.AppendText($"Rental Period: {days} day(s)\n");
            rtbSummary.AppendText($"Start Date: {_booking.StartDate.ToShortDateString()}\n");
            rtbSummary.AppendText($"End Date: {_booking.EndDate.ToShortDateString()}\n\n");

            // Car Information
            rtbSummary.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            rtbSummary.SelectionColor = primaryColor;
            rtbSummary.AppendText("Car Information:\n");
            rtbSummary.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbSummary.SelectionColor = textColor;
            rtbSummary.AppendText($"Make/Model: {_booking.Car.Make} {_booking.Car.Model}\n");
            rtbSummary.AppendText($"Year: {_booking.Car.Year}\n");
            rtbSummary.AppendText($"Type: {_booking.Car.Type}\n");
            rtbSummary.AppendText($"Daily Rate: £{_booking.Car.PricePerDay:0.00}\n\n");

            // Optional extras
            rtbSummary.SelectionFont = new Font("Segoe UI", 14, FontStyle.Bold);
            rtbSummary.SelectionColor = primaryColor;
            rtbSummary.AppendText("Optional Extras:\n");
            rtbSummary.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbSummary.SelectionColor = textColor;

            decimal basePrice = _booking.Car.PricePerDay * days;
            decimal insurancePrice = _booking.HasInsurance ? basePrice * 0.15m : 0;

            if (_booking.HasInsurance)
                rtbSummary.AppendText($"Insurance: Yes (+15% = £{insurancePrice:0.00})\n");
            else
                rtbSummary.AppendText("Insurance: No\n");

            // Total price with highlight
            rtbSummary.AppendText("\n");
            rtbSummary.SelectionFont = new Font("Segoe UI", 16, FontStyle.Bold);
            rtbSummary.SelectionColor = Color.FromArgb(228, 61, 48);
            rtbSummary.AppendText($"TOTAL PRICE: £{_booking.TotalPrice:0.00}\n");

            // Booking date
            rtbSummary.SelectionFont = new Font("Segoe UI", 12, FontStyle.Regular);
            rtbSummary.SelectionColor = textColor;
            rtbSummary.AppendText($"\nBooking Date: {DateTime.Now.ToString("dd MMMM yyyy")}\n");
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking has been confirmed!\nThank you for choosing WeAreCars.",
                "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // P/Invoke declarations for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}