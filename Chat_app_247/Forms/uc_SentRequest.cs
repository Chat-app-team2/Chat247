﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_app_247.Forms
{
    public partial class uc_SentRequest : UserControl
    {
        public uc_SentRequest()
        {
            InitializeComponent();
        }
        public void SetName(string name)
        {
            Name_Label.Text = name;
        }
    }
}
