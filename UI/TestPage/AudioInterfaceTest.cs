
namespace UI.TestPage
{
    public partial class AudioInterfaceTest : UserControl
    {
        
       
        public AudioInterfaceTest()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void Work(int model, Image image)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Work, model, image);
            }
            else
            {
                if (model == 1)
                {
                    this.audioPictureBox.Image = image;
                }
                else
                {
                    this.microphonePictureBox.Image = image;
                }
            }
        }
      
        private void audioPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
