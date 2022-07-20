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
    public partial class Delivery : Form
    {
        public double totalPrice = (Global.sushi * Global.sushiPrice) + (Global.tempura * Global.tempuraPrice) + (Global.bento * Global.bentoPrice);
        public int totalItems = Global.sushi + Global.tempura + Global.bento;
        public Delivery()
        {
            InitializeComponent();
            lblCartNum.Text = totalItems.ToString();
            lblPrice.Text = $"${totalPrice.ToString("0.00")}";

            lblSushiCount.Text = $"Doragon Sushi ({Global.sushi.ToString()})";
            lblTempuraCount.Text = $"Tempura Fried Shrimp ({Global.tempura.ToString()})";
            lblBentoCount.Text = $"Bento Box Mix ({Global.bento.ToString()})";

            btnDelivery.Enabled = false;

            if(totalItems < 1)
            {
                btnSubmit.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            formTransition(this, new Confirmation());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formTransition(this, new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formTransition(this, new Menu());
        }
    }
}
