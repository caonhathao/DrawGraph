﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form2 : Form
    {
        public string AddressPath = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            AddressPath = InputField.Text;
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
