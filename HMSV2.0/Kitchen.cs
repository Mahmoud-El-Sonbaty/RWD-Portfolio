using MetroFramework.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ReservationManager.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HMSV2._0
{
    public partial class Kitchen : MetroForm
    {
        string cleaning, towel, surprise, queryString;
        int breakfast, lunch, dinner, foodBill;
        public Int32 primaryID;
        double totalBill;
        bool supply_status = false;
        ReservationContext reservationContext;

        public Kitchen()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => reservationContext?.Dispose();
        }
        private void kitchen_Load(object sender, EventArgs e)
        {
            reservationContext = new ReservationContext();
            reservationContext.Reservations.Load();
            LoadForDataGridView();
            listBoxFromDataBase();
        }
        private void LoadForDataGridView()
        {
            try
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = reservationContext.Reservations.Local?.ToBindingList();
                overviewDataGridView.DataSource = bindingSource;
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error loading data", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.None);
            }
        }
        private void resetEntries(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                if (control.HasChildren)
                {
                    resetEntries(control);
                }
            }
        }
        private void listBoxFromDataBase()
        {
            queueListBox.Items.Clear();
            var query = reservationContext.Reservations.Local.Where(R => R.CheckIn == true && R.SupplyStatus == false);
            try
            {
                foreach (var item in query)
                {
                    string ID = item.Id.ToString();
                    string first_name = item.FirstName.ToString();
                    string last_name = item.LastName.ToString();
                    string phone_number = item.PhoneNumber.ToString();
                    queueListBox.Items.Add(ID + "  | " + first_name + "  " + last_name + " | " + phone_number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void queueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetEntries(this);
            string GetQueryString = queueListBox.Text.Substring(0, 4).Replace(" ", string.Empty);
            try
            {
                int.TryParse(GetQueryString, out int intQS);
                var query = reservationContext.Reservations.Where(R => R.Id == intQS);
                foreach (var item in query)
                {
                    string ID = item.Id.ToString();
                    string first_name = item.FirstName.ToString();
                    string last_name = item.LastName.ToString();
                    string phone_number = item.PhoneNumber.ToString();
                    string foodBillD = item.FoodBill.ToString();
                    string total_bill = item.TotalBill.ToString().Replace(" ", string.Empty);
                    string room_type = item.RoomType.ToString();
                    string room_floor = item.RoomFloor.ToString();
                    string room_number = item.RoomNumber.ToString();
                    string _cleaning = item.Cleaning.ToString();
                    string _towel = item.Towel.ToString();
                    string _surprise = item.Surprise.ToString();
                    if (_cleaning == "True")
                    {
                        cleaning = "1";
                        cleaningCheckBox.Checked = true;
                    }
                    else { cleaning = "0"; }
                    if (_towel == "True")
                    {
                        towel = "1";
                        towelCheckBox.Checked = true;
                    }
                    else { towel = "0"; }
                    if (_surprise == "True")
                    {
                        surprise = "1";
                        surpriseCheckBox.Checked = true;
                    }
                    else
                    {
                        surprise = "0";
                    }
                    string supply_status = item.SupplyStatus.ToString();
                    string food_billD = item.FoodBill.ToString();
                    string _breakfast = item.Breakfast.ToString();
                    string _lunch = item.Lunch.ToString();
                    string _dinner = item.Dinner.ToString();
                    double Num;
                    bool isNum = double.TryParse(_lunch, out Num);
                    if (isNum)
                    {
                        lunch = Int32.Parse(_lunch);
                        lunchTextBox.Text = Convert.ToString(lunch);
                    }
                    else
                    {
                        lunch = 0;
                        lunchTextBox.Text = "NONE";
                    }
                    isNum = double.TryParse(_breakfast, out Num);
                    if (isNum)
                    {
                        breakfast = Int32.Parse(_breakfast);
                        breakfastTextBox.Text = Convert.ToString(breakfast);
                    }
                    else
                    {
                        breakfast = 0;
                        breakfastTextBox.Text = "NONE";
                    }
                    isNum = double.TryParse(_dinner, out Num);
                    if (isNum)
                    {
                        dinner = Int32.Parse(_dinner);
                        dinnerTextBox.Text = Convert.ToString(dinner);
                    }
                    else
                    {
                        dinner = 0;
                        dinnerTextBox.Text = "NONE";
                    }

                    if (supply_status == "True")
                    {
                        supplyCheckBox.Checked = true;
                    }
                    else
                    {
                        supplyCheckBox.Checked = false;
                    }
                    firstNameTextBox.Text = first_name;
                    lastNameTextBox.Text = last_name;
                    phoneNTextBox.Text = phone_number;
                    roomTypeTextBox.Text = room_type;
                    floorNTextBox.Text = room_floor;
                    roomNTextBox.Text = room_number;
                    totalBill = Convert.ToDouble(total_bill);
                    foodBill = Convert.ToInt32(foodBillD);
                    totalBill -= foodBill;
                    primaryID = Convert.ToInt32(ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("COMBOBOX Selection: + " + ex.Message);
            }
        }
        private void foodSelectionButton_Click(object sender, EventArgs e)
        {
            FoodMenu food_menu = new FoodMenu();
            food_menu.needPanel.Visible = false;
            food_menu.ShowDialog();
            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;
            int bfast = 0, Lnch = 0, di_ner = 0;
            if (breakfast > 0)
            {
                bfast = 7 * breakfast;
            }
            if (lunch > 0)
            {
                Lnch = 15 * lunch;
            }
            if (dinner > 0)
            {
                di_ner = 15 * dinner;
            }
            foodBill += (bfast + Lnch + di_ner);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (primaryID > 1000)
            {
                //queryString = "update reservation set total_bill='" + totalBill + foodBill + "', break_fast='" + breakfast + "', lunch= '" + lunch + "', dinner='" + dinner + "', supply_status='" + supply_status + "',cleaning='" + Convert.ToInt32(cleaning) + "',towel='" + Convert.ToInt32(towel) + "',s_surprise='" + Convert.ToInt32(surprise) + "',food_bill='" + foodBill + "' WHERE Id = '" + primaryID + "';";
                try
                {
                    var ResObj = reservationContext.Reservations.Local.Where(R => R.Id == primaryID).FirstOrDefault();
                    if (ResObj != null)
                    {
                        ResObj.TotalBill = (float)(totalBill + foodBill);
                        ResObj.Breakfast = breakfast;
                        ResObj.Lunch = lunch;
                        ResObj.Dinner = dinner;
                        ResObj.Cleaning = cleaning == "1" ? true : false;
                        ResObj.Towel = towel == "1" ? true : false;
                        ResObj.Surprise = surprise == "1" ? true : false;
                        ResObj.FoodBill = foodBill;
                        string userID = Convert.ToString(primaryID);
                        reservationContext.SaveChanges();
                        listBoxFromDataBase();
                        LoadForDataGridView();
                        resetEntries(this);
                        MetroFramework.MetroMessageBox.Show(this, "Entry successfully updated into database. For the UNIQUE USER ID of: " + "\n\n" +
                        " " + userID, "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selected ID doesn't exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
        private void supplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cleaningCheckBox.Checked = false;
            cleaningCheckBox.Text = "Cleaned";
            towelCheckBox.Checked = false;
            towelCheckBox.Text = "Toweled";
            surpriseCheckBox.Checked = false;
            surpriseCheckBox.Text = "Surprised";
            supply_status = true;
        }
        private void kitchen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            reservationContext?.Dispose();
        }
    }
}
