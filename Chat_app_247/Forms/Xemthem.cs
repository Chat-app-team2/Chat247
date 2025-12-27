using System;
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
    public partial class Xemthem : Form
    {
        public Xemthem(string urlpic, string name, string email, string date,string gender, string bio)
        {
            InitializeComponent();
            Setdata(urlpic, name, email, date, gender, bio);
            this.Text = $"{name}'s Profile";
        }

        private async void Setdata(string urlpic, string name, string email, string date, string gender, string bio)
        {
            if (avt_pic != null && !string.IsNullOrEmpty(urlpic))
                avt_pic.LoadAsync(urlpic);
            txt_name.Text = name;
            txt_email.Text = email;
            txt_date.Text = date;
            txt_gender.Text = gender;
            txt_bio.Text = bio;
            this.Text = $"{name}'s Profile";
        }
    }
}
