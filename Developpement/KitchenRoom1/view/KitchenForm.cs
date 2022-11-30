﻿using KitchenRoom1.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenRoom1
{
    internal partial class KitchenForm : Form
    {
        public KitchenModel model { get; set; }

        public KitchenForm(KitchenModel model)
        {
            this.model = model;
            InitializeComponent();
        }

        private void KitchenForm_Load(object sender, EventArgs e)
        {
        }


        private void KitchenForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.chef.sprite, model.chef.x, model.chef.y);
        }

    }
}
