using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SettingsForm : Form
    {
        private List<TestType> testTypes;
        private TestModel testModel;
        System.Windows.Forms.Timer timer;
       

        public SettingsForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            testTypes = new List<TestType>();
            timer = new System.Windows.Forms.Timer();//创建定时器
            timer.Tick += new EventHandler(OnTimer);//事件处理
            timer.Enabled = true;//设置启用定时器
            timer.Interval = 1000;//执行时间
            timer.Start();//开启定时器
        }
        private void NewFormTask()
        {
            GetTestOptions();
            Application.Run(new MainForm(testModel, testTypes));
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.TimerBar.Value += 1;
            this.LeaveTimeLabel.Text = $"剩余时间{60 - this.TimerBar.Value}s";
            if (this.TimerBar.Value == 60)
            {
                timer.Stop();
                timer.Tick -= new EventHandler(OnTimer);//取消事件
                timer.Enabled = false;//设置禁用定时器
                timer.Dispose();
                this.Hide();
                Thread thread = new(NewFormTask);
                thread.Start();
                this.Close();
            }
        }

        private void StartLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread thread = new(NewFormTask);
            thread.Start();
            this.Close();
        }
        private void GetTestOptions()
        {
            //获取测试模式
            if (QuickSwitch.Checked)
            {
                testModel = TestModel.Quickly;
            }
            else 
            {
                testModel = TestModel.Comprehensive;
            } 
            //查看RTC是否选中
            if (RTCCheck.Checked)
                testTypes.Add(TestType.RTCTest);
            //查看配置校验是否选中
            if (ConfigCheck.Checked)
            {
                testTypes.Add(TestType.CPUConfigCheck);
                testTypes.Add(TestType.MemoryConfigCheck);
                testTypes.Add(TestType.GPUConfigCheck);
                testTypes.Add(TestType.DiskConfigCheck);
            }
            //查看硬盘Smart信息检查是否选中
            if (DiskSmartCheck.Checked)
            {
                testTypes.Add(TestType.DiskSmartTest);
            }
            //查看硬盘坏道检测是否选中
            if (DiskBadCheck.Checked)
            {
                testTypes.Add(TestType.DiskBadTest);
            }
            //查看音频接口测试是否选中
            if (AudioInterfaceCheck.Checked)
            {
                testTypes.Add(TestType.AudioInterfaceTest);
            }
            //查看USB测试是否选中
            if (USBCheck.Checked)
            {
                testTypes.Add(TestType.USBTest);
            }
            //查看串口测试是否选中
            if (SerialPortCheck.Checked)
            {
                testTypes.Add(TestType.SerialPortTest);
            }
            //查看网口数据测试是否选中
            if (NetworkPortCheck.Checked)
            {
                testTypes.Add(TestType.NetworkPortTest);
            }
            //查看MAC地址测试是否选中
            if (MACAddressCheck.Checked)
            {
                testTypes.Add(TestType.MACAddressTest);
            }
            //查看硬盘压力测试是否选中
            if (DiskBurnerCheck.Checked)
            {
                testTypes.Add(TestType.DiskBurnerTest);
            }
            //查看CPU压力测试是否选中
            if (CPUBurnerCheck.Checked)
            {
                testTypes.Add(TestType.CPUBurnerTest);
            }
            //查看内存压力测试是否选中
            if (MemoryBurnerCheck.Checked)
            {
                testTypes.Add(TestType.MemoryBurnerTest);
            }

        }
        private void BackLabel_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= new EventHandler(OnTimer);//取消事件
            timer.Enabled = false;//设置禁用定时器
            timer.Dispose();
            this.Hide();
            Thread thread = new Thread(BackForm);
            thread.Start();
            this.Close();
        }
        private void BackForm()
        {
            Application.Run(new StartForm());
        }
    }
}
