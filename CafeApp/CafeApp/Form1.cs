using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class Form1 : Form
    {
        public static int totalItems;
        public static double totalPrice;

        public Form1()
        {
            InitializeComponent();
            btnHome.Enabled = false;

            totalItems = Global.sushi + Global.bento + Global.tempura;
            lblCart.Text = $"Cart({totalItems})";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            formTransition(this, new Menu());
        }

        public static void formTransition(Form currentForm, Form nextForm)
        {
            // Retain current position
            nextForm.Tag = currentForm;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Location = currentForm.Location;

            // Hide currentform then show next form
            currentForm.Hide();
            nextForm.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            formTransition(this, new Menu());
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            formTransition(this, new Delivery());
        }
    }
}
