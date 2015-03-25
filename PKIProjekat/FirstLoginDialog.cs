﻿using PKIProjekat.Domain;
using PKIProjekat.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKIProjekat
{
    public partial class FirstLoginDialog : Form
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        private string username;

        public FirstLoginDialog(string username)
        {
            InitializeComponent();

            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo(textBox2.Text) == 0)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    Employee employee = employeeRepository.GetEmployeeByName(username);

                    employee.Password = textBox1.Text;

                    employeeRepository.Update(employee);

                    DialogResult = System.Windows.Forms.DialogResult.OK;

                    Dispose();
                }
                else
                {
                    MessageBox.Show("You must enter a password!");
                }
            }
            else
            {
                MessageBox.Show("Password missmatch!");
            }
        }
    }
}
