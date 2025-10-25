namespace Chat_app_247
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f_Dashboard dashboard = new f_Dashboard();
            dashboard.Show();
        }
    }
}
