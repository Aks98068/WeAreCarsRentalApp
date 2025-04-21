using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using WeAreCarsRental.Models;

namespace WeAreCarsRental
{
    public class BookingForm : Form
    {
        // Form controls
        private TextBox txtFirstName;
        private TextBox txtSurname;
        private NumericUpDown nudAge;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cboCarType;
        private CheckBox chkInsurance;
        private Button btnBook;
        private Button btnViewCars;
        private Button btnClear;
        private Label lblError;

        // Car options
        private readonly List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2021, PricePerDay = 45.00m, Type = "Economy" },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2022, PricePerDay = 48.00m, Type = "Economy" },
            new Car { Id = 3, Make = "Nissan", Model = "Sentra", Year = 2021, PricePerDay = 47.00m, Type = "Economy" },
            new Car { Id = 4, Make = "Hyundai", Model = "Elantra", Year = 2022, PricePerDay = 49.00m, Type = "Economy" },
            new Car { Id = 5, Make = "Ford", Model = "Focus", Year = 2020, PricePerDay = 43.00m, Type = "Economy" },
            new Car { Id = 6, Make = "Toyota", Model = "Camry", Year = 2022, PricePerDay = 65.00m, Type = "Standard" },
            new Car { Id = 7, Make = "Honda", Model = "Accord", Year = 2021, PricePerDay = 62.00m, Type = "Standard" },
            new Car { Id = 8, Make = "Nissan", Model = "Altima", Year = 2022, PricePerDay = 60.00m, Type = "Standard" },
            new Car { Id = 9, Make = "Hyundai", Model = "Sonata", Year = 2021, PricePerDay = 58.00m, Type = "Standard" },
            new Car { Id = 10, Make = "Ford", Model = "Fusion", Year = 2020, PricePerDay = 55.00m, Type = "Standard" },
            new Car { Id = 11, Make = "BMW", Model = "3 Series", Year = 2022, PricePerDay = 120.00m, Type = "Luxury" },
            new Car { Id = 12, Make = "Mercedes", Model = "C-Class", Year = 2021, PricePerDay = 125.00m, Type = "Luxury" },
            new Car { Id = 13, Make = "Audi", Model = "A4", Year = 2022, PricePerDay = 115.00m, Type = "Luxury" },
            new Car { Id = 14, Make = "Lexus", Model = "IS", Year = 2021, PricePerDay = 110.00m, Type = "Luxury" },
            new Car { Id = 15, Make = "Infiniti", Model = "Q50", Year = 2022, PricePerDay = 105.00m, Type = "Luxury" }
        };

        // Modern UI colors
        private readonly Color primaryColor = Color.FromArgb(0, 122, 204);
        private readonly Color accentColor = Color.FromArgb(28, 28, 28);
        private readonly Color backgroundColor = Color.FromArgb(245, 245, 245);
        private readonly Color textColor = Color.FromArgb(51, 51, 51);

        public BookingForm()
        {
            // Form properties
            this.Text = "WeAreCars Rental - Booking";
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
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
                Text = "Create New Booking",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblTitle);

            // Add a close button in the top right
            Button btnClose = new Button
            {
                Text = "×",
                Location = new Point(960, 5),
                Size = new Size(35, 35),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 16, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Application.Exit();
            headerPanel.Controls.Add(btnClose);

            // Add back button
            Button btnBack = new Button
            {
                Text = "≪",
                Location = new Point(5, 5),
                Size = new Size(35, 35),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) =>
            {
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.FormClosed += (s2, e2) => this.Close();
                loginForm.Show();
            };
            headerPanel.Controls.Add(btnBack);

            // Create booking panel for customer details
            Panel bookingPanel = new Panel
            {
                Location = new Point(30, 100),
                Size = new Size(940, 400),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(bookingPanel);

            // Add shadow effect to panel
            bookingPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, bookingPanel.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            // Add section title
            Label lblCustomerDetails = new Label
            {
                Text = "Customer Details",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 15),
                Size = new Size(200, 30),
                ForeColor = primaryColor
            };
            bookingPanel.Controls.Add(lblCustomerDetails);

            // First Name label and textbox
            Label lblFirstName = new Label
            {
                Text = "First Name*:",
                Location = new Point(50, 60),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblFirstName);

            txtFirstName = new TextBox
            {
                Location = new Point(50, 85),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };
            bookingPanel.Controls.Add(txtFirstName);

            // Surname label and textbox
            Label lblSurname = new Label
            {
                Text = "Surname*:",
                Location = new Point(300, 60),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblSurname);

            txtSurname = new TextBox
            {
                Location = new Point(300, 85),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };
            bookingPanel.Controls.Add(txtSurname);

            // Age label and numeric up/down
            Label lblAge = new Label
            {
                Text = "Age*:",
                Location = new Point(550, 60),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblAge);

            nudAge = new NumericUpDown
            {
                Location = new Point(550, 85),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 12),
                Minimum = 18,
                Maximum = 100,
                Value = 25,
                BorderStyle = BorderStyle.FixedSingle
            };
            bookingPanel.Controls.Add(nudAge);

            // Rental details title
            Label lblRentalDetails = new Label
            {
                Text = "Rental Details",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 140),
                Size = new Size(200, 30),
                ForeColor = primaryColor
            };
            bookingPanel.Controls.Add(lblRentalDetails);

            // Start date
            Label lblStartDate = new Label
            {
                Text = "Start Date*:",
                Location = new Point(50, 185),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblStartDate);

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(50, 210),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today,
                MaxDate = DateTime.Today.AddYears(1)
            };
            bookingPanel.Controls.Add(dtpStartDate);

            // End date
            Label lblEndDate = new Label
            {
                Text = "End Date*:",
                Location = new Point(300, 185),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblEndDate);

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(300, 210),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today.AddDays(1),
                MaxDate = DateTime.Today.AddYears(1).AddDays(1)
            };
            bookingPanel.Controls.Add(dtpEndDate);

            // Car Type
            Label lblCarType = new Label
            {
                Text = "Car Type*:",
                Location = new Point(550, 185),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(lblCarType);

            cboCarType = new ComboBox
            {
                Location = new Point(550, 210),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboCarType.Items.AddRange(new object[] { "Economy", "Standard", "Luxury" });
            cboCarType.SelectedIndex = 0;
            bookingPanel.Controls.Add(cboCarType);

            // Insurance
            chkInsurance = new CheckBox
            {
                Text = "Add Insurance (+15% of total)",
                Location = new Point(50, 270),
                Size = new Size(350, 30),
                Font = new Font("Segoe UI", 12),
                ForeColor = textColor
            };
            bookingPanel.Controls.Add(chkInsurance);

            // Buttons section
            // Book button
            btnBook = new Button
            {
                Text = "Book Now",
                Location = new Point(50, 320),
                Size = new Size(150, 45),
                BackColor = primaryColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += BtnBook_Click;
            bookingPanel.Controls.Add(btnBook);

            // View Cars button
            btnViewCars = new Button
            {
                Text = "View Available Cars",
                Location = new Point(230, 320),
                Size = new Size(180, 45),
                BackColor = accentColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnViewCars.FlatAppearance.BorderSize = 0;
            btnViewCars.Click += BtnViewCars_Click;
            bookingPanel.Controls.Add(btnViewCars);

            // Clear button
            btnClear = new Button
            {
                Text = "Clear Form",
                Location = new Point(440, 320),
                Size = new Size(130, 45),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;
            bookingPanel.Controls.Add(btnClear);

            // Error label
            lblError = new Label
            {
                Text = "",
                Location = new Point(50, 380),
                Size = new Size(850, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft
            };
            bookingPanel.Controls.Add(lblError);

            // Add required fields note
            Label lblRequired = new Label
            {
                Text = "* Required fields",
                Location = new Point(30, 510),
                Size = new Size(150, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblRequired);

            // Set date validation events
            dtpStartDate.ValueChanged += DatePicker_ValueChanged;
            dtpEndDate.ValueChanged += DatePicker_ValueChanged;

            // Setup validation for age
            nudAge.Validating += NudAge_Validating;

            // Enable form dragging
            headerPanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    const int WM_NCLBUTTONDOWN = 0xA1;
                    const int HTCAPTION = 0x2;
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Ensure end date is after start date
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            }
        }

        private void NudAge_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudAge.Value < 25 && cboCarType.SelectedItem.ToString() == "Luxury")
            {
                lblError.Text = "Drivers under 25 cannot rent Luxury cars.";
                e.Cancel = true;
            }
            else
            {
                lblError.Text = "";
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            // Validate form
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                lblError.Text = "Please fill in all required fields.";
                return;
            }

            // Validate age for luxury cars
            if (nudAge.Value < 25 && cboCarType.SelectedItem.ToString() == "Luxury")
            {
                lblError.Text = "Drivers under 25 cannot rent Luxury cars.";
                return;
            }

            // Calculate rental duration
            TimeSpan duration = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
            int days = duration.Days;

            if (days < 1)
            {
                lblError.Text = "Rental period must be at least 1 day.";
                return;
            }

            // Get car details based on selected type
            string carType = cboCarType.SelectedItem.ToString();
            // Find the first car of the selected type
            Car selectedCar = availableCars.Find(c => c.Type == carType);

            if (selectedCar == null)
            {
                lblError.Text = "No cars available of the selected type.";
                return;
            }

            // Calculate total price
            decimal basePrice = selectedCar.PricePerDay * days;
            decimal insurancePrice = chkInsurance.Checked ? basePrice * 0.15m : 0;
            decimal totalPrice = basePrice + insurancePrice;

            // Create a booking
            Booking booking = new Booking
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtSurname.Text.Trim(),
                Age = (int)nudAge.Value,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                Car = selectedCar,
                HasInsurance = chkInsurance.Checked,
                TotalPrice = totalPrice
            };

            // Show booking summary
            BookingSummaryForm summaryForm = new BookingSummaryForm(booking);
            this.Hide();
            summaryForm.FormClosed += (s, args) => this.Show();
            summaryForm.Show();
        }

        private void BtnViewCars_Click(object sender, EventArgs e)
        {
            CarListForm carListForm = new CarListForm(availableCars);
            carListForm.ShowDialog();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            nudAge.Value = 25;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
            cboCarType.SelectedIndex = 0;
            chkInsurance.Checked = false;
            lblError.Text = "";
        }

        // P/Invoke declarations for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}