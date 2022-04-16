namespace UI
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void NewFormTask()
        {
            Application.Run(new SettingsForm());
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread thread = new(NewFormTask);
            thread.Start();
            this.Close();
        }

        private void bigLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
