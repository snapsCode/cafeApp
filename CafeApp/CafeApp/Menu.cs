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
    public partial class Menu : Form
    {
        public static int totalItems;
        public static double totalPrice;
        public Menu()
        {
            InitializeComponent();
            btnMenu.Enabled = false;

            totalItems = Global.sushi + Global.bento + Global.tempura;
            updateCart();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddSushi_Click(object sender, EventArgs e)
        {
            Global.sushi++;
            updateCart();
        }

        private void btnAddTempura_Click(object sender, EventArgs e)
        {
            Global.tempura++;
            updateCart();
        }

        private void btnBento_Click(object sender, EventArgs e)
        {
            Global.bento++;
            updateCart();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formTransition(this, new Form1());
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

        public void updateCart()
        {
            totalItems = Global.sushi + Global.bento + Global.tempura;
            lblCart.Text = $"Cart({totalItems})";
        }

        private void btnRemoveSushi_Click(object sender, EventArgs e)
        {
            if (totalItems > 0)
            {
                Global.sushi--;
                updateCart();
            }
        }

        private void btnRemoveTempura_Click(object sender, EventArgs e)
        {
            if (totalItems > 0)
            {
                Global.tempura--;
                updateCart();
            }
        }

        private void btnRemoveBento_Click(object sender, EventArgs e)
        {
            if(totalItems > 0)
            {
                Global.bento--;
                updateCart();
            }
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            formTransition(this, new Delivery());
        }
    }
}
