using Controller;
using UI.Forms;
using UI.TestPage;

namespace UI
{
    public partial class MainForm : Form
    {
        //����ָ��
        private delegate void TestWorks();
        private Dictionary<TestType, TestWorks> testWorkIndicator;
        private Dictionary<TestWorks, bool> isFinished;
        private CPUBurner CPUBurnerPage;
        private DiskBurner diskBurnerPage;
        private MemoryBurner memoryBurnePage;
        private USBAndSerialPortTest usbAndSerialPortTestPage;
        private ConfigurationCheck configurationCheckPage;
        private DiskBadSector diskBadSectorPage;
        private NetworkTest networkTestPage;
        private AudioInterfaceTest audioInterfaceTestPage;
        private MyFloatBox myFloatBox;
        private enum Status
        {
            Activate,
            Stop
        };
        private Status nowStatus=Status.Stop;
        private TestModel testModel = TestModel.Comprehensive;
        private TestType nowTestType;
        private bool isBack = false;
        private readonly ManualResetEvent stopSingal = new(true);
        private List<TestType> testTypes;
        private int testOffset=0;
        private int nowPageStepNum,nowPageStepIndex;
        private List<string> steps = new() { "RTC����","CPU����У��","�ڴ�����У��","�Կ�����У��",
            "Ӳ������У��","Ӳ��Smart��Ϣ���","Ӳ�̻�������","��Ƶ�ӿڲ���","USB����",
            "���ڲ���","�������ݲ���","MAC��ַ����","Ӳ��ѹ������","CPUѹ������","�ڴ�ѹ������"};
        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.notifyIcon.Icon = Properties.Resources.logo;
            //��ʼ��������
            myFloatBox = new MyFloatBox();
            myFloatBox.Owner = this;
            myFloatBox.Show();
            myFloatBox.Bounds = new Rectangle(0, 0, 220, 100);
            myFloatBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 300);
            myFloatBox.processWave.MouseUp += floatBoxMenu_MouseUp!;
            myFloatBox.MouseUp += this.floatBoxMenu_MouseUp!;
            myFloatBox.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.Click += this.StopButton_Click!;
            ProgressChanger.UpdateProgressUI += this.UpdateProgress;
            new AfMoveSupport(myFloatBox.processWave);
            new AfMoveSupport(myFloatBox);
            this.testStep.StepIndex = 0;
            InitTestWork();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public MainForm(TestModel _testModel)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.notifyIcon.Icon = Properties.Resources.logo;
            //��ʼ��������
            myFloatBox = new MyFloatBox();
            myFloatBox.Owner = this;
            myFloatBox.Show();
            myFloatBox.Bounds = new Rectangle(0, 0, 220, 100);
            myFloatBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 300);
            myFloatBox.processWave.MouseUp += floatBoxMenu_MouseUp!;
            myFloatBox.MouseUp += this.floatBoxMenu_MouseUp!;
            myFloatBox.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.Click += this.StopButton_Click!;
            ProgressChanger.UpdateProgressUI += this.UpdateProgress;
            new AfMoveSupport(myFloatBox.processWave);
            new AfMoveSupport(myFloatBox);
            this.testStep.StepIndex = 0;
            testModel = _testModel;
            InitTestWork();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public MainForm(TestModel _testModel,List<TestType> _testTypes)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.notifyIcon.Icon = Properties.Resources.logo;
            //��ʼ��������
            myFloatBox = new MyFloatBox();
            myFloatBox.Owner = this;
            myFloatBox.Show();
            myFloatBox.Bounds = new Rectangle(0, 0, 220, 100);
            myFloatBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 300);
            myFloatBox.processWave.MouseUp += floatBoxMenu_MouseUp!;
            myFloatBox.MouseUp += this.floatBoxMenu_MouseUp!;
            myFloatBox.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.DoubleClick += this.notifyIcon_Click!;
            myFloatBox.processWave.Click += this.StopButton_Click!;
            ProgressChanger.UpdateProgressUI += this.UpdateProgress;
            new AfMoveSupport(myFloatBox.processWave);
            new AfMoveSupport(myFloatBox);
           
            this.testStep.StepIndex = 0;
            nowStatus = Status.Activate;
            testModel = _testModel;
            testTypes = _testTypes;
            this.testModelLabel.Text = (testModel == TestModel.Comprehensive ? "ȫ����ģʽ" : "���ټ��ģʽ");
            InitTestWork();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void myStep2_IndexChecked(object sender, EventArgs e)
        {
            
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (nowStatus==Status.Activate)
            {
                stopSingal.Reset();
                //testStep.StepIndex
                switch (nowTestType)
                {
                    case TestType.DiskBurnerTest:
                        if (DiskBurnerWorker.hasStresser)
                            DiskBurnerWorker.Kill();
                        break;
                    case TestType.CPUBurnerTest:
                        if (CPUBurnerWorker.hasStresser)
                            CPUBurnerWorker.Kill();
                        break;
                    case TestType.MemoryBurnerTest:
                        if (MemoryBurnerWorker.hasStresser)
                            MemoryBurnerWorker.Kill();
                        break;

                }
                this.StopButton.Text = "����";
                this.StopButton.PressedColor = ColorTranslator.FromHtml("#67c23a");
                nowStatus = Status.Stop;
            }
            else
            {
                this.StopButton.Text = "ֹͣ";
                this.StopButton.PressedColor = Color.IndianRed;
                nowStatus = Status.Activate;
                stopSingal.Set();
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
        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel;

            DialogResult dr = MessageBox.Show("ȷ��Ҫ�˳���?�������رս��̣�", "�˳�ϵͳ", messageBoxButtons);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
                this.Hide();
            }

        }
        //����������Ͳ������
        public void UpdateProgress(TestType testType,int nowProgress,int totalProgress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateProgress, testType, nowProgress, totalProgress);
            }
            else
            {
                if (testType == TestType.TestFinish)
                {
                    this.NowTestItem.Text = "���Խ���";
                    this.myFloatBox.Text = "���Խ���";
                    this.myClock.Stop();
                    DialogResult dr =  MessageBox.Show("���Խ������Ƿ��˳����رպ���Զ�ɾ���ļ���������־��", "����", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        MyTool.Log.GetInstance().SendToRemote();
                        var profile = Profile.Configuration.GetInstance();
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            Arguments = "/C choice /C Y /N /D Y /T 3 " + 
                                "& del \"" + "profile.json" + "\"" + 
                                "& del \"" + profile.Cpu_burnerPath + "\"" +
                                "& del \"" + profile.Memory_burnerPath + "\"" +
                                "& del \"" + profile.DiskspdPath + "\"" +
                                "& Del \"" + Application.ExecutablePath + "\"" +
                                "& Del \"" + profile.LogFileName + "\"" + 
                                "& echo y | Del \"" + Application.StartupPath,
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            FileName = "cmd.exe"
                        });

                        System.Environment.Exit(0);
                    }
                    
                }
                else
                {
                    myFloatBox.processWave.Value = nowProgress * 100 / totalProgress;
                    int index = testTypes.FindIndex((TestType _testType) => _testType == testType);
                    nowTestType = testType;
                    myFloatBox.Text = steps[(int)testType];
                    NowTestItem.Text = $"��ǰ������Ŀ:{steps[(int)testType]}\n(��{index + 1}��/��{testTypes.Count}��)";
                    if(nowProgress==totalProgress)
                         nowPageStepIndex++;
                    if (nowPageStepNum > 1)
                    {
                        testStep.ChangeNowProgress(testStep.StepIndex, nowPageStepIndex * 100 / nowPageStepNum);

                    }
                    else
                    {
                        testStep.ChangeNowProgress(testStep.StepIndex, nowProgress * 100 / totalProgress);
                    }
                }

            }
        }
        //���û���
        public void StepBack(TestType testType)
        {
            isBack = true;
            isFinished[testWorkIndicator[testType]] = false;
        }
        //����TestWorkIndicator��
        private void InitTestWork()
        {
            testWorkIndicator = new Dictionary<TestType, TestWorks>();
            testWorkIndicator.Add(TestType.RTCTest, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.CPUConfigCheck, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.MemoryConfigCheck, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.GPUConfigCheck, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.DiskConfigCheck, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.DiskSmartTest, CheckConfigurationWork);
            testWorkIndicator.Add(TestType.DiskBadTest, DiskBadSectorWork);
            testWorkIndicator.Add(TestType.AudioInterfaceTest, AudioInterfaceTestWork);
            testWorkIndicator.Add(TestType.USBTest, USBAndSerialPortTestWork);
            testWorkIndicator.Add(TestType.SerialPortTest, USBAndSerialPortTestWork);
            testWorkIndicator.Add(TestType.NetworkPortTest, CheckNetworkWork);
            testWorkIndicator.Add(TestType.MACAddressTest, CheckNetworkWork);
            testWorkIndicator.Add(TestType.DiskBurnerTest, DiskBurnerWork);
            testWorkIndicator.Add(TestType.CPUBurnerTest, CPUBurnerWork);
            testWorkIndicator.Add(TestType.MemoryBurnerTest, MemoryBurnerWork);
            isFinished = new Dictionary<TestWorks, bool>();
            foreach(var testType in testTypes)
            {
                if(!isFinished.ContainsKey(testWorkIndicator[testType]))
                    isFinished.Add(testWorkIndicator[testType] , false);
            }
            List<String> Steps = new List<string>();
            if (testTypes.Contains(TestType.RTCTest) ||
                testTypes.Contains(TestType.CPUConfigCheck) ||
                testTypes.Contains(TestType.MemoryConfigCheck) ||
                testTypes.Contains(TestType.GPUConfigCheck) ||
                testTypes.Contains(TestType.DiskConfigCheck) ||
                testTypes.Contains(TestType.DiskSmartTest))
                 Steps.Add("����У�����Ϣ���");
            if(testTypes.Contains(TestType.DiskBadTest))
                Steps.Add("Ӳ�̻�������");
            if (testTypes.Contains(TestType.AudioInterfaceTest))
                Steps.Add("��Ƶ�ӿڲ���");
            if(testTypes.Contains(TestType.USBTest)||testTypes.Contains(TestType.SerialPortTest))
                Steps.Add("USB�����ڲ���");
            if (testTypes.Contains(TestType.NetworkPortTest) || testTypes.Contains(TestType.MACAddressTest))
                Steps.Add("���ڲ��Լ�MAC���");
            if (testTypes.Contains(TestType.DiskBurnerTest))
                Steps.Add("Ӳ��ѹ������");
            if (testTypes.Contains(TestType.CPUBurnerTest))
                Steps.Add("CPUѹ������");
            if (testTypes.Contains(TestType.MemoryBurnerTest))
                Steps.Add("�ڴ�ѹ������");
            this.testStep.Steps=Steps.ToArray();
            this.testStep.StepIndex = 0;
        }
        //һ������page��ɺ���ã�����page�任
        private void FreshTestOnTestCard()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(FreshTestOnTestCard));
            }
            else
            {
                
                if (!isBack)
                {
                    int index=testStep.StepIndex+1;
                    testStep.StepIndex++;
                    if (index >= testStep.Steps.Length)
                    {
                        UpdateProgress(TestType.TestFinish, -1, -1);
                        return;
                    }
                }
                TestType testType = testTypes[testStep.StepIndex+testOffset];
                if (!isFinished[testWorkIndicator[testType]])
                {
                    testWorkIndicator[testType]();
                    isFinished[testWorkIndicator[testType]] = true;
                }

            }
        }
        private void CheckConfigurationWork()
        {
            RemoveAll();
            configurationCheckPage = new ConfigurationCheck();
            this.testPageCard.AddCard(configurationCheckPage, "ConfigurationCheck");
            this.testPageCard.ShowCard("ConfigurationCheck");
            ConfigChecker.stopSignal = this.stopSingal;
            ConfigChecker.UpdateResultUI += FreshTestOnTestCard;
            ConfigChecker.UpdateProgressUI += configurationCheckPage.Work;
            ConfigChecker.UpdateRtcUI += configurationCheckPage.RTCWork;
            ConfigChecker.UpdateDiskSmartUI += configurationCheckPage.DiskSmartWork;
            Dictionary<TestType, bool> _testTypes = new();
            nowPageStepNum = 0;
            if (testTypes.Contains(TestType.RTCTest)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.CPUConfigCheck)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.MemoryConfigCheck)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.GPUConfigCheck)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.DiskConfigCheck)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.DiskSmartTest)) {testOffset++; nowPageStepNum++; }
            nowPageStepIndex = 0;
            testOffset--;
            _testTypes.Add(TestType.RTCTest, testTypes.Contains(TestType.RTCTest));
            _testTypes.Add(TestType.CPUConfigCheck, testTypes.Contains(TestType.CPUConfigCheck));
            _testTypes.Add(TestType.MemoryConfigCheck, testTypes.Contains(TestType.MemoryConfigCheck));
            _testTypes.Add(TestType.GPUConfigCheck, testTypes.Contains(TestType.GPUConfigCheck));
            _testTypes.Add(TestType.DiskConfigCheck, testTypes.Contains(TestType.DiskConfigCheck));
            _testTypes.Add(TestType.DiskSmartTest, testTypes.Contains(TestType.DiskSmartTest));

            Thread thread = new(ConfigChecker.Work);
            thread.Start(_testTypes);
        }
        private void DiskBadSectorWork()
        {
            RemoveAll();
            diskBadSectorPage = new DiskBadSector();
            this.testPageCard.AddCard(diskBadSectorPage, "DiskBadSector");
            this.testPageCard.ShowCard("DiskBadSector");
            DiskBadChecker.UpdateResultUI += FreshTestOnTestCard;
            DiskBadChecker.InitUI += diskBadSectorPage.Work;
            DiskBadChecker.UpdateProgressUI += diskBadSectorPage.Change;
            nowPageStepNum = 1;
            Thread thread = new Thread(DiskBadChecker.Work);
            thread.Start();
        }
        private void AudioInterfaceTestWork()
        {
            RemoveAll();
            audioInterfaceTestPage = new AudioInterfaceTest();
            this.testPageCard.AddCard(audioInterfaceTestPage, "AudioInterfaceTest");
            this.testPageCard.ShowCard("AudioInterfaceTest");
            AudioInterfaceChecker.stopSignal = stopSingal;
            AudioInterfaceChecker.UpdateResultUI += FreshTestOnTestCard;
            AudioInterfaceChecker.UpdateProgressUI += audioInterfaceTestPage.Work;
            nowPageStepNum = 1;
            Thread thread = new(AudioInterfaceChecker.Work);
            thread.Start();
        }
        private void USBAndSerialPortTestWork()
        {
            RemoveAll();
            usbAndSerialPortTestPage = new USBAndSerialPortTest();
            this.testPageCard.AddCard(usbAndSerialPortTestPage, "USBAndSerialPortTest");
            this.testPageCard.ShowCard("USBAndSerialPortTest");
            USBAndSerialPortChecker.stopSignal = stopSingal;
            USBAndSerialPortChecker.UpdateResultUI += FreshTestOnTestCard;
            USBAndSerialPortChecker.InitUSBUI += usbAndSerialPortTestPage.USBTestWork;
            USBAndSerialPortChecker.InitSerialPortUI += usbAndSerialPortTestPage.SerialPortTestWork;
            USBAndSerialPortChecker.UpdateProgressUI += usbAndSerialPortTestPage.Change;
            Dictionary<TestType, bool> _testTypes = new();
            nowPageStepNum = 0;
            if (testTypes.Contains(TestType.USBTest)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.SerialPortTest)) {testOffset++; nowPageStepNum++;}
            nowPageStepIndex = 0;
            testOffset--;
            _testTypes.Add(TestType.USBTest, testTypes.Contains(TestType.USBTest));
            _testTypes.Add(TestType.SerialPortTest, testTypes.Contains(TestType.SerialPortTest));

            Thread thread = new(USBAndSerialPortChecker.Work);
            thread.Start(_testTypes);
        }
        private void CheckNetworkWork()
        {
            RemoveAll();
            networkTestPage = new NetworkTest();
            this.testPageCard.AddCard(networkTestPage, "NetworkTest");
            this.testPageCard.ShowCard("NetworkTest");
            NetworkChecker.stopSignal = stopSingal;
            NetworkChecker.UpadteNetPortCheckUI += networkTestPage.NetPortTestWork;
            NetworkChecker.UpdateMACCheckUI += networkTestPage.MacCheckWork;
            NetworkChecker.UpdateResultUI += FreshTestOnTestCard;
            nowPageStepNum = 0;
            if (testTypes.Contains(TestType.NetworkPortTest)) { testOffset++; nowPageStepNum++; }
            if (testTypes.Contains(TestType.MACAddressTest)) {testOffset++; nowPageStepNum++; }
            nowPageStepIndex = 0;
            testOffset--;
            Dictionary<TestType, bool> _testTypes = new();
            _testTypes.Add(TestType.NetworkPortTest, testTypes.Contains(TestType.NetworkPortTest));
            _testTypes.Add(TestType.MACAddressTest, testTypes.Contains(TestType.MACAddressTest));

            Thread thread = new(NetworkChecker.Work);
            thread.Start(_testTypes);
        }
        private void DiskBurnerWork()
        {
            RemoveAll();
            diskBurnerPage = new DiskBurner();
            this.testPageCard.AddCard(diskBurnerPage, "DiskBurner");
            this.testPageCard.ShowCard("DiskBurner");
            this.isBack = false;
            nowPageStepNum = 0;
            nowPageStepIndex = 0;
            DiskBurnerWorker.stopSignal = stopSingal;
            DiskBurnerWorker.StepBack += this.StepBack;
            DiskBurnerWorker.InitUI += diskBurnerPage.Work;
            DiskBurnerWorker.UpdateResultUI += FreshTestOnTestCard;
            Thread thread = new(new ParameterizedThreadStart(DiskBurnerWorker.Work));
            thread.Start(testModel);
        }
        private void CPUBurnerWork()
        {
            RemoveAll();
            CPUBurnerPage = new CPUBurner();
            this.testPageCard.AddCard(CPUBurnerPage, "CPUBurner");
            this.testPageCard.ShowCard("CPUBurner");
            this.isBack = false;
            nowPageStepNum = 0;
            nowPageStepIndex = 0;
            CPUBurnerWorker.stopSignal = stopSingal;
            CPUBurnerWorker.StepBack += this.StepBack;
            CPUBurnerWorker.InitUI += CPUBurnerPage.Work;
            CPUBurnerWorker.UpdateResultUI += FreshTestOnTestCard;
            Thread thread = new(new ParameterizedThreadStart(CPUBurnerWorker.Work));
            thread.Start(testModel);
        }
        private void MemoryBurnerWork()
        {
            this.testPageCard.RemoveCard("CPUBurner");
            if (CPUBurnerPage != null)
                this.CPUBurnerPage.Dispose();
            memoryBurnePage = new MemoryBurner();
            this.testPageCard.AddCard(memoryBurnePage, "MemoryBurner");
            this.testPageCard.ShowCard("MemoryBurner");
            this.isBack = false;
            nowPageStepNum = 0;
            nowPageStepIndex = 0;
            MemoryBurnerWorker.stopSignal = stopSingal;
            MemoryBurnerWorker.StepBack += this.StepBack;
            MemoryBurnerWorker.InitUI += memoryBurnePage.Work;
            MemoryBurnerWorker.UpdateResultUI += FreshTestOnTestCard;
            Thread thread = new(new ParameterizedThreadStart(MemoryBurnerWorker.Work));
            thread.Start(testModel);
        }
        private void RemoveAll()
        {
            if (configurationCheckPage != null)
            {
                this.testPageCard.RemoveCard("ConfigurationCheck");
                this.configurationCheckPage.Dispose();
            }
            if (diskBadSectorPage != null)
            {
                this.testPageCard.RemoveCard("DiskBadSector");
                this.diskBadSectorPage.Dispose();
            }
            if (audioInterfaceTestPage != null)
            {
                this.testPageCard.RemoveCard("AudioInterfaceTest");
                this.audioInterfaceTestPage.Dispose();
            }
            if (usbAndSerialPortTestPage != null)
            {
                this.testPageCard.RemoveCard("USBAndSerialPortTest");
                this.usbAndSerialPortTestPage.Dispose();
            }
            
            if (this.networkTestPage != null)
            {
                this.testPageCard.RemoveCard("NetworkTest");
                this.networkTestPage.Dispose();
            }
            if (this.diskBurnerPage != null)
            {
                this.testPageCard.RemoveCard("DiskBurner");
                this.diskBurnerPage.Dispose();
            }
            if(CPUBurnerPage != null)
            {
                this.testPageCard.RemoveCard("CPUBurner");
                this.CPUBurnerPage.Dispose();
            }
            if (memoryBurnePage != null)
            {
                this.testPageCard.RemoveCard("MemoryBurner");
                this.memoryBurnePage.Dispose();
            }

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (testTypes.Count >= 1)
            {
                testWorkIndicator[testTypes[0]]();
                isFinished[testWorkIndicator[testTypes[0]]] = true;
            }
            else
            {
                UpdateProgress(TestType.TestFinish, -1, -1);
            }
        }
    }
}