using BankaIslemleri.Data.Entities;
using BankaIslemleri.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaIslemleri
{
    public partial class Form1 : Form
    {
        public int amount { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            amount = 500;
            lblAmount.Text = amount + " TL";
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (int.TryParse(txtDebit.Text, out result))
            {
                BaseEntity notifications = new BaseEntity();
                int totalAmount = BankAccountService.Debit(result, amount, notifications);
                if (notifications.IsSuccess)
                {
                    amount = totalAmount;
                    lblAmount.Text = amount + " TL";
                }
                else
                {
                    lblError.Text = notifications.Errors[0];
                }
            }
            else
            {
                lblError.Text = "Rakamsall bir değer girin!";
            }
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (int.TryParse(txtwithDraw.Text, out result))
            {
                BaseEntity notifications = new BaseEntity();
                int totalAmount = BankAccountService.WithDraw(result, amount, notifications);
                if (notifications.IsSuccess)
                {
                    amount = totalAmount;
                    lblAmount.Text = amount + " TL";
                }
                else
                {
                    lblError.Text = notifications.Errors[0];
                }
            }
            else
            {
                lblError.Text = "Rakamsall bir değer girin!";
            }
        }
    }
}
