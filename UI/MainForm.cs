using Controller;
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

            //初始化悬浮球
            myFloatBox = new MyFloatBox();
            myFloatBox.Owner = this;
            myFloatBox.Show();
            myFloatBox.Bounds = new Rectangle(0, 0, 220, 100);
            myFloatBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 300);
            myFloatBox.processWave.MouseUp += floatBoxMenu_MouseUp;
            myFloatBox.MouseUp += this.floatBoxMenu_MouseUp;
            myFloatBox.DoubleClick += this.notifyIcon_Click;
            myFloatBox.processWave.DoubleClick += this.notifyIcon_Click;
            myFloatBox.processWave.Click += this.StopButton_Click;
            new AfMoveSupport(myFloatBox.processWave);
            new AfMoveSupport(myFloatBox);


            audioInterfaceTestPage.Status = 0;
           

            //this.testPageCard.AddCard(audioInterfaceTestPage, "AudioInterfaceTest");
            //this.testPageCard.AddCard(USBAndSeialTestPage, "USBTest");
            //this.testPageCard.AddCard(memoryBurnePage, "MemoryBurner");
           
            
            this.USBAndSeialTestPage.USBCount = 3;
            this.USBAndSeialTestPage.TestModel = true;
            this.USBAndSeialTestPage.SerialPortCount = 2;

            this.progress = 0;
            this.testProgressBar.Value = 0;
            this.testStep.StepIndex = 0;
            this.configurationCheckPage.TerminalTime = DateTime.Now;
            this.configurationCheckPage.ConfigurationTime = DateTime.Now;
            
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
            if (flag)
            {

                this.StopButton.Text = "开始";
                this.StopButton.PressedColor = ColorTranslator.FromHtml("#67c23a");
            }
            else
            {
                FreshTestOnTestCard();
                this.StopButton.Text = "停止";
                this.StopButton.PressedColor = Color.IndianRed;
            }
            flag = !flag;

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

            //    this.testProgressBar.Value = progress;
            //    this.myFloatBox.processWave.Value = progress;
            //    if (progress % 13 == 0)
            //    {
                    
            //        this.testStep.StepIndex++;
            //        int index = this.testStep.StepIndex;
            //        if (index < testStep.Steps.Length)
            //        {
            //            this.NowTestItem.Text = "当前测试项目:" + this.testStep.Steps[index];
            //            this.myFloatBox.Text = this.testStep.Steps[index];
            //        }
            //        else
            //        {
            //            this.NowTestItem.Text = "测试结束";
            //            this.myFloatBox.Text = "测试结束";
            //        }
            //        //configurationCheckPage.Dispose();
            //        MessageBox.Show(configurationCheckPage.Size.ToString());
            //        testPageCard.CurrentCard();
            //        testPageCard.ShowCard(0);
            //        //MessageBox.Show(index.ToString());
            //        //this.testPageCard.ShowCard(index);
            //    }
                

            //    if (progress==100)
            //        this.Close();
            }
        }

        //一个测试page完成后调用，进行page变换
        private void FreshTestOnTestCard()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(FreshTestOnTestCard));
            }
            else
            {
                if (testStep.StepIndex == 0) 
                {
                    CheckConfigurationWork();
                }
                else if(testStep.StepIndex == 1)
                {
                    DiskBadSectorWork();
                }
                else if (testStep.StepIndex == 2)
                {
                    CheckNetworkWork();
                }
                else if (testStep.StepIndex == 3)
                {
                    DiskBurnerWork();
                }
                else if (testStep.StepIndex == 4)
                {
                    CPUBurnerWork();
                }
                testStep.StepIndex++;
            }
        }

        private void CheckConfigurationWork()
        {
            this.testPageCard.AddCard(configurationCheckPage, "ConfigurationCheck");
            this.testPageCard.ShowCard(0);
            ConfigChecker.UpdateResultUI += FreshTestOnTestCard;
            ConfigChecker.UpdateProgressUI += configurationCheckPage.Work;
            Thread thread = new Thread(ConfigChecker.Work);
            thread.Start();
        }
        private void DiskBadSectorWork()
        {
            this.testPageCard.RemoveCard("ConfigurationCheck");
            this.configurationCheckPage.Dispose();
            this.testPageCard.AddCard(diskBadSectorPage, "DiskBadSector");
            this.testPageCard.ShowCard(0);
            DiskBadChecker.UpdateResultUI += FreshTestOnTestCard;
            DiskBadChecker.InitUI += diskBadSectorPage.Work;
            DiskBadChecker.UpdateProgressUI += diskBadSectorPage.Change;
            Thread thread = new Thread(DiskBadChecker.Work);
            thread.Start();
        }

        private void CheckNetworkWork()
        {
            this.testPageCard.RemoveCard("DiskBadSector");
            this.configurationCheckPage.Dispose();
            this.testPageCard.AddCard(networkTestPage, "NetworkTest");
            this.testPageCard.ShowCard(0);
            NetworkChecker.UpadteNetPortCheckUI += networkTestPage.NetPortTestWork;
            NetworkChecker.UpdateMACCheckUI += networkTestPage.MacCheckWork;
            NetworkChecker.UpdateResultUI += FreshTestOnTestCard;
            Thread thread = new(NetworkChecker.Work);
            thread.Start();
        }
        private void DiskBurnerWork()
        {
            this.testPageCard.RemoveCard("NetworkTest");
            this.networkTestPage.Dispose();
            this.testPageCard.AddCard(diskBurnerPage, "DiskBurner");
            this.testPageCard.ShowCard(0);
            this.diskBurnerPage.DiskCount = 2;
        }
        private void CPUBurnerWork()
        {
            this.testPageCard.RemoveCard("DiskBurner");
            this.networkTestPage.Dispose();
            this.testPageCard.AddCard(CPUBurnerPage, "CPUBurner");
            this.testPageCard.ShowCard(0);
            CPUBurnerWorker.InitUI += CPUBurnerPage.Work;
            CPUBurnerWorker.UpdateResultUI += FreshTestOnTestCard;
            Thread thread = new(CPUBurnerWorker.Work);
            thread.Start();
        }

       
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }
    }
}