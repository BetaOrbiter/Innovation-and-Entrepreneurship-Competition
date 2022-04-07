using UI.Forms;
using UI.TestPage;

namespace UI
{
    public partial class MainForm : Form
    {
        private CPUBurner CPUBurnerPage;
        private DiskBurner diskBurnerPage;
        private MemoryBurner memoryBurnePage;
        private USBAndSerialTest USBAndSeialTestPage;
        private ConfigurationCheck configurationCheckPage;
        private DiskBadSector diskBadSectorPage;
        private NetworkTest networkTestPage;
        private AudioInterfaceTest audioInterfaceTestPage;
        private MyFloatBox myFloatBox;
        private bool flag = false;
        private System.Threading.Timer timer;
        private int progress;
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.notifyIcon.Icon = Properties.Resources.logo;
            CPUBurnerPage = new CPUBurner();
            diskBurnerPage = new DiskBurner();
            memoryBurnePage = new MemoryBurner();
            USBAndSeialTestPage = new USBAndSerialTest();
            configurationCheckPage = new ConfigurationCheck();
            diskBadSectorPage = new DiskBadSector();
            networkTestPage = new NetworkTest();
            audioInterfaceTestPage = new AudioInterfaceTest();
            myFloatBox = new MyFloatBox();
            myFloatBox.Owner = this;
            myFloatBox.Show();
            myFloatBox.Bounds = new Rectangle(0, 0, 220, 100);
            myFloatBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 300);

            diskBadSectorPage.DiskCount = 2;
            diskBadSectorPage.NowDiskIndex = 0;
            diskBadSectorPage.Status = 1;
            audioInterfaceTestPage.Status = 0;
            new AfMoveSupport(myFloatBox.processWave);
            new AfMoveSupport(myFloatBox);

            myFloatBox.processWave.MouseUp += this.floatBoxMenu_MouseUp;
            myFloatBox.MouseUp += this.floatBoxMenu_MouseUp;
            myFloatBox.DoubleClick += this.notifyIcon_Click;
            myFloatBox.processWave.DoubleClick += this.notifyIcon_Click;
            myFloatBox.processWave.Click += this.StopButton_Click;

            this.testPageCard.AddCard(CPUBurnerPage, "CPUBurner");
            this.testPageCard.AddCard(configurationCheckPage, "ConfigurationCheck");
            this.testPageCard.AddCard(diskBadSectorPage, "DiskBadSector");
            this.testPageCard.AddCard(audioInterfaceTestPage, "AudioInterfaceTest");
            this.testPageCard.AddCard(USBAndSeialTestPage, "USBTest");
            this.testPageCard.AddCard(networkTestPage, "NetworkTest");
            this.testPageCard.AddCard(diskBurnerPage, "DiskBurner");
            //this.testPageCard.AddCard(CPUBurnerPage, "CPUBurner");
            this.testPageCard.AddCard(memoryBurnePage, "MemoryBurner");
            this.networkTestPage.UploadSpeed = 10;
            this.networkTestPage.DownloadSpeed = 10;
            this.networkTestPage.MACAddress = "90-78-41-C0-D1-E5";
            this.diskBurnerPage.DiskCount = 2;
            this.USBAndSeialTestPage.USBCount = 3;
            this.USBAndSeialTestPage.TestModel = true;
            this.USBAndSeialTestPage.SerialPortCount = 2;

            this.progress = 0;
            this.testProgressBar.Value = 0;
            this.testStep.StepIndex = 0;
            this.configurationCheckPage.TerminalTime = DateTime.Now;
            this.configurationCheckPage.ConfigurationTime = DateTime.Now;
            this.configurationCheckPage.TerminalCPUModel = "Intel(R) Core(TM) i7 - 9750H CPU @ 2.60GHz";
            this.configurationCheckPage.ConfigurationCPUModel = "Intel(R) Core(TM) i7 - 9750H CPU @ 2.60GHz";
            this.configurationCheckPage.TerminalMemoryModels = new List<string>()
            {
                "Kingston HyperX KHX2666C15S4/8G",
                "Kingston HyperX KHX2666C15S4/8G",
            };
            this.configurationCheckPage.ConfigurationMemoryModels = new List<string>()
            {
                "Kingston HyperX KHX2666C15S4/8G",
                "Kingston HyperX KHX2666C15S4/8G",
            };

            this.configurationCheckPage.TerminalGPUModel = "NVIDIA GeForce RTX 2060";
            this.configurationCheckPage.ConfigurationGPUModel = "NVIDIA GeForce RTX 2060";
            this.configurationCheckPage.TerminalDiskModels = new List<string>()
            {
                "Samsung SSD 870 EVO 500GB",
                "Samsung SSD 870 EVO 500GB",
            };
            this.configurationCheckPage.ConfigurationDiskModels = new List<string>()
            {
                "Samsung SSD 870 EVO 500GB",
                "Samsung SSD 870 EVO 500GB",
            };
            this.progressLabel.Text = "总测试进度:";
            //创建定时器
            timer = new System.Threading.Timer(
                new TimerCallback(this.OnTimer)
                ,null
                ,1000
                ,1000
                );
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void OnTimer(object state)
        {
            progress++;
            ChangeProgress();
            if (progress >= 100)
            {
                return;
            }

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        private void myStep2_IndexChecked(object sender, EventArgs e)
        {
            //MessageBox.Show(testStep.ToString());
            //if(testStep!=null)
            //MessageBox.Show(testStep.Size.ToString());
            int index = this.testStep.StepIndex;
            if (index != testStep.Steps.Length)
            {
                this.NowTestItem.Text = "当前测试项目:" + this.testStep.Steps[index];
                this.myFloatBox.Text = this.testStep.Steps[index];
            }
            else
            {
                this.NowTestItem.Text = "测试结束";
                this.myFloatBox.Text = "测试结束";
            }

            //MessageBox.Show(index.ToString());
            this.testPageCard.ShowCard(index);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            flag = !flag;
            if (flag)
            {
                this.StopButton.Text = "继续";
                this.StopButton.PressedColor = ColorTranslator.FromHtml("#67c23a");
            }
            else
            {
                this.StopButton.Text = "停止";
                this.StopButton.PressedColor = Color.IndianRed;
            }

        }
        private void floatBoxMenu_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel;

            DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", messageBoxButtons);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                timer.Dispose();
            }
        }
        bool clicked = false;
        private void airButton1_Click(object sender, EventArgs e)
        {
            if (!clicked)
                timer.Change(1000, 1000);
            else timer.Change(-1, -1);
            //Thread th = new Thread(new ThreadStart(this.Execute));
            //th.Start();
            clicked = !clicked;
        }
        private void ChangeProgress()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ChangeProgress));
            }
            else
            {
                this.testProgressBar.Value = progress;
                this.myFloatBox.processWave.Value = progress;
                if (progress % 13 == 0)
                {
                    this.testStep.StepIndex++;
                    int index = this.testStep.StepIndex;
                    if (index < testStep.Steps.Length)
                    {
                        this.NowTestItem.Text = "当前测试项目:" + this.testStep.Steps[index];
                        this.myFloatBox.Text = this.testStep.Steps[index];
                    }
                    else
                    {
                        this.NowTestItem.Text = "测试结束";
                        this.myFloatBox.Text = "测试结束";
                    }

                    //MessageBox.Show(index.ToString());
                    this.testPageCard.ShowCard(index);
                }
                

                if (progress==100)
                    this.Close();
            }
        }
        
    }
}