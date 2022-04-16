namespace UI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.myForm1 = new UI.MyForm();
            this.MACAddressCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.DiskBadCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.LeaveTimeLabel = new ReaLTaiizor.Controls.BigLabel();
            this.settingPicture = new System.Windows.Forms.PictureBox();
            this.QuickSwitch = new HZH_Controls.Controls.UCSwitch();
            this.ReminderLabel = new ReaLTaiizor.Controls.BigLabel();
            this.MemoryBurnerCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.CPUBurnerCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.DiskBurnerCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.NetworkPortCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.SerialPortCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.USBCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.AudioInterfaceCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.DiskSmartCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.ConfigCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.PrePicture = new System.Windows.Forms.PictureBox();
            this.TestItemChooseLabel = new ReaLTaiizor.Controls.BigLabel();
            this.RTCCheck = new ReaLTaiizor.Controls.ParrotCheckBox();
            this.BackLabel = new ReaLTaiizor.Controls.BigLabel();
            this.StartLabel = new ReaLTaiizor.Controls.BigLabel();
            this.TimerBar = new ReaLTaiizor.Controls.ParrotFlatProgressBar();
            this.TitleLabel = new ReaLTaiizor.Controls.BigLabel();
            this.myForm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // myForm1
            // 
            this.myForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.myForm1.Controls.Add(this.MACAddressCheck);
            this.myForm1.Controls.Add(this.DiskBadCheck);
            this.myForm1.Controls.Add(this.bigLabel3);
            this.myForm1.Controls.Add(this.nightControlBox1);
            this.myForm1.Controls.Add(this.LeaveTimeLabel);
            this.myForm1.Controls.Add(this.settingPicture);
            this.myForm1.Controls.Add(this.QuickSwitch);
            this.myForm1.Controls.Add(this.ReminderLabel);
            this.myForm1.Controls.Add(this.MemoryBurnerCheck);
            this.myForm1.Controls.Add(this.CPUBurnerCheck);
            this.myForm1.Controls.Add(this.DiskBurnerCheck);
            this.myForm1.Controls.Add(this.NetworkPortCheck);
            this.myForm1.Controls.Add(this.SerialPortCheck);
            this.myForm1.Controls.Add(this.USBCheck);
            this.myForm1.Controls.Add(this.AudioInterfaceCheck);
            this.myForm1.Controls.Add(this.DiskSmartCheck);
            this.myForm1.Controls.Add(this.ConfigCheck);
            this.myForm1.Controls.Add(this.PrePicture);
            this.myForm1.Controls.Add(this.TestItemChooseLabel);
            this.myForm1.Controls.Add(this.RTCCheck);
            this.myForm1.Controls.Add(this.BackLabel);
            this.myForm1.Controls.Add(this.StartLabel);
            this.myForm1.Controls.Add(this.TimerBar);
            this.myForm1.Controls.Add(this.TitleLabel);
            this.myForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myForm1.DrawIcon = true;
            this.myForm1.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.myForm1.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(110)))), ((int)(((byte)(147)))));
            this.myForm1.Location = new System.Drawing.Point(0, 0);
            this.myForm1.MinimumSize = new System.Drawing.Size(100, 42);
            this.myForm1.Name = "myForm1";
            this.myForm1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.myForm1.Size = new System.Drawing.Size(1050, 900);
            this.myForm1.TabIndex = 0;
            this.myForm1.Text = "AutoMaticX86";
            this.myForm1.TextAlignment = UI.MyForm.Alignment.Left;
            this.myForm1.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            // 
            // MACAddressCheck
            // 
            this.MACAddressCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.MACAddressCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.MACAddressCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.MACAddressCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.MACAddressCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.MACAddressCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.MACAddressCheck.Checked = true;
            this.MACAddressCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MACAddressCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MACAddressCheck.ForeColor = System.Drawing.Color.Black;
            this.MACAddressCheck.Location = new System.Drawing.Point(592, 435);
            this.MACAddressCheck.Name = "MACAddressCheck";
            this.MACAddressCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.MACAddressCheck.Size = new System.Drawing.Size(301, 35);
            this.MACAddressCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.MACAddressCheck.TabIndex = 27;
            this.MACAddressCheck.Text = "MAC地址测试";
            this.MACAddressCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.MACAddressCheck.TickThickness = 2;
            // 
            // DiskBadCheck
            // 
            this.DiskBadCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskBadCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskBadCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.DiskBadCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.DiskBadCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.DiskBadCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.DiskBadCheck.Checked = true;
            this.DiskBadCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiskBadCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiskBadCheck.ForeColor = System.Drawing.Color.Black;
            this.DiskBadCheck.Location = new System.Drawing.Point(64, 595);
            this.DiskBadCheck.Name = "DiskBadCheck";
            this.DiskBadCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.DiskBadCheck.Size = new System.Drawing.Size(301, 35);
            this.DiskBadCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.DiskBadCheck.TabIndex = 26;
            this.DiskBadCheck.Text = "硬盘坏道检测";
            this.DiskBadCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.DiskBadCheck.TickThickness = 2;
            // 
            // bigLabel3
            // 
            this.bigLabel3.AutoSize = true;
            this.bigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel3.Location = new System.Drawing.Point(702, 756);
            this.bigLabel3.Name = "bigLabel3";
            this.bigLabel3.Size = new System.Drawing.Size(182, 32);
            this.bigLabel3.TabIndex = 25;
            this.bigLabel3.Text = "快速检测模式";
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.DefaultLocation = false;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = false;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(911, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 24;
            // 
            // LeaveTimeLabel
            // 
            this.LeaveTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeaveTimeLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LeaveTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LeaveTimeLabel.Location = new System.Drawing.Point(628, 182);
            this.LeaveTimeLabel.Name = "LeaveTimeLabel";
            this.LeaveTimeLabel.Size = new System.Drawing.Size(152, 26);
            this.LeaveTimeLabel.TabIndex = 23;
            this.LeaveTimeLabel.Text = "剩余时间30s";
            // 
            // settingPicture
            // 
            this.settingPicture.BackColor = System.Drawing.Color.Transparent;
            this.settingPicture.Image = global::UI.Properties.Resources.setting;
            this.settingPicture.Location = new System.Drawing.Point(783, 58);
            this.settingPicture.Margin = new System.Windows.Forms.Padding(0);
            this.settingPicture.Name = "settingPicture";
            this.settingPicture.Size = new System.Drawing.Size(152, 135);
            this.settingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingPicture.TabIndex = 22;
            this.settingPicture.TabStop = false;
            // 
            // QuickSwitch
            // 
            this.QuickSwitch.BackColor = System.Drawing.Color.Transparent;
            this.QuickSwitch.Checked = false;
            this.QuickSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuickSwitch.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.QuickSwitch.FalseTextColr = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.QuickSwitch.Location = new System.Drawing.Point(580, 751);
            this.QuickSwitch.Name = "QuickSwitch";
            this.QuickSwitch.Size = new System.Drawing.Size(104, 39);
            this.QuickSwitch.SwitchType = HZH_Controls.Controls.SwitchType.Line;
            this.QuickSwitch.TabIndex = 21;
            this.QuickSwitch.Texts = new string[] {
        "快速模式"};
            this.QuickSwitch.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(10)))), ((int)(((byte)(100)))));
            this.QuickSwitch.TrueTextColr = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // ReminderLabel
            // 
            this.ReminderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.ReminderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReminderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ReminderLabel.Location = new System.Drawing.Point(592, 797);
            this.ReminderLabel.Name = "ReminderLabel";
            this.ReminderLabel.Size = new System.Drawing.Size(446, 73);
            this.ReminderLabel.TabIndex = 20;
            this.ReminderLabel.Text = "压力测试时间默认为6h\r\n快速检测模式下为1h\r\n\r\n";
            this.ReminderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemoryBurnerCheck
            // 
            this.MemoryBurnerCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.MemoryBurnerCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.MemoryBurnerCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.MemoryBurnerCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.MemoryBurnerCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.MemoryBurnerCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.MemoryBurnerCheck.Checked = true;
            this.MemoryBurnerCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MemoryBurnerCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MemoryBurnerCheck.ForeColor = System.Drawing.Color.Black;
            this.MemoryBurnerCheck.Location = new System.Drawing.Point(592, 675);
            this.MemoryBurnerCheck.Name = "MemoryBurnerCheck";
            this.MemoryBurnerCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.MemoryBurnerCheck.Size = new System.Drawing.Size(301, 35);
            this.MemoryBurnerCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.MemoryBurnerCheck.TabIndex = 19;
            this.MemoryBurnerCheck.Text = "内存压力测试";
            this.MemoryBurnerCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.MemoryBurnerCheck.TickThickness = 2;
            // 
            // CPUBurnerCheck
            // 
            this.CPUBurnerCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.CPUBurnerCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.CPUBurnerCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.CPUBurnerCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.CPUBurnerCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.CPUBurnerCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.CPUBurnerCheck.Checked = true;
            this.CPUBurnerCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPUBurnerCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CPUBurnerCheck.ForeColor = System.Drawing.Color.Black;
            this.CPUBurnerCheck.Location = new System.Drawing.Point(592, 595);
            this.CPUBurnerCheck.Name = "CPUBurnerCheck";
            this.CPUBurnerCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.CPUBurnerCheck.Size = new System.Drawing.Size(301, 35);
            this.CPUBurnerCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.CPUBurnerCheck.TabIndex = 18;
            this.CPUBurnerCheck.Text = "CPU压力测试";
            this.CPUBurnerCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.CPUBurnerCheck.TickThickness = 2;
            // 
            // DiskBurnerCheck
            // 
            this.DiskBurnerCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskBurnerCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskBurnerCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.DiskBurnerCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.DiskBurnerCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.DiskBurnerCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.DiskBurnerCheck.Checked = true;
            this.DiskBurnerCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiskBurnerCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiskBurnerCheck.ForeColor = System.Drawing.Color.Black;
            this.DiskBurnerCheck.Location = new System.Drawing.Point(592, 515);
            this.DiskBurnerCheck.Name = "DiskBurnerCheck";
            this.DiskBurnerCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.DiskBurnerCheck.Size = new System.Drawing.Size(301, 35);
            this.DiskBurnerCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.DiskBurnerCheck.TabIndex = 17;
            this.DiskBurnerCheck.Text = "硬盘压力测试";
            this.DiskBurnerCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.DiskBurnerCheck.TickThickness = 2;
            // 
            // NetworkPortCheck
            // 
            this.NetworkPortCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.NetworkPortCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.NetworkPortCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.NetworkPortCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.NetworkPortCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.NetworkPortCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.NetworkPortCheck.Checked = true;
            this.NetworkPortCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NetworkPortCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NetworkPortCheck.ForeColor = System.Drawing.Color.Black;
            this.NetworkPortCheck.Location = new System.Drawing.Point(592, 355);
            this.NetworkPortCheck.Name = "NetworkPortCheck";
            this.NetworkPortCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.NetworkPortCheck.Size = new System.Drawing.Size(301, 35);
            this.NetworkPortCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.NetworkPortCheck.TabIndex = 16;
            this.NetworkPortCheck.Text = "网口数据测试";
            this.NetworkPortCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.NetworkPortCheck.TickThickness = 2;
            // 
            // SerialPortCheck
            // 
            this.SerialPortCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.SerialPortCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.SerialPortCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.SerialPortCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.SerialPortCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.SerialPortCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.SerialPortCheck.Checked = true;
            this.SerialPortCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SerialPortCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SerialPortCheck.ForeColor = System.Drawing.Color.Black;
            this.SerialPortCheck.Location = new System.Drawing.Point(64, 835);
            this.SerialPortCheck.Name = "SerialPortCheck";
            this.SerialPortCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.SerialPortCheck.Size = new System.Drawing.Size(301, 35);
            this.SerialPortCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.SerialPortCheck.TabIndex = 15;
            this.SerialPortCheck.Text = "串口测试";
            this.SerialPortCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.SerialPortCheck.TickThickness = 2;
            // 
            // USBCheck
            // 
            this.USBCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.USBCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.USBCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.USBCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.USBCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.USBCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.USBCheck.Checked = true;
            this.USBCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.USBCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.USBCheck.ForeColor = System.Drawing.Color.Black;
            this.USBCheck.Location = new System.Drawing.Point(64, 755);
            this.USBCheck.Name = "USBCheck";
            this.USBCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.USBCheck.Size = new System.Drawing.Size(301, 35);
            this.USBCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.USBCheck.TabIndex = 14;
            this.USBCheck.Text = "USB测试";
            this.USBCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.USBCheck.TickThickness = 2;
            // 
            // AudioInterfaceCheck
            // 
            this.AudioInterfaceCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.AudioInterfaceCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.AudioInterfaceCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.AudioInterfaceCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.AudioInterfaceCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.AudioInterfaceCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.AudioInterfaceCheck.Checked = true;
            this.AudioInterfaceCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AudioInterfaceCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AudioInterfaceCheck.ForeColor = System.Drawing.Color.Black;
            this.AudioInterfaceCheck.Location = new System.Drawing.Point(64, 675);
            this.AudioInterfaceCheck.Name = "AudioInterfaceCheck";
            this.AudioInterfaceCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.AudioInterfaceCheck.Size = new System.Drawing.Size(301, 35);
            this.AudioInterfaceCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.AudioInterfaceCheck.TabIndex = 13;
            this.AudioInterfaceCheck.Text = "音频接口测试";
            this.AudioInterfaceCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.AudioInterfaceCheck.TickThickness = 2;
            // 
            // DiskSmartCheck
            // 
            this.DiskSmartCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskSmartCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.DiskSmartCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.DiskSmartCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.DiskSmartCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.DiskSmartCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.DiskSmartCheck.Checked = true;
            this.DiskSmartCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiskSmartCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiskSmartCheck.ForeColor = System.Drawing.Color.Black;
            this.DiskSmartCheck.Location = new System.Drawing.Point(64, 515);
            this.DiskSmartCheck.Name = "DiskSmartCheck";
            this.DiskSmartCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.DiskSmartCheck.Size = new System.Drawing.Size(301, 35);
            this.DiskSmartCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.DiskSmartCheck.TabIndex = 12;
            this.DiskSmartCheck.Text = "硬盘Smart信息检查";
            this.DiskSmartCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.DiskSmartCheck.TickThickness = 2;
            // 
            // ConfigCheck
            // 
            this.ConfigCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.ConfigCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.ConfigCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.ConfigCheck.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.ConfigCheck.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.ConfigCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.ConfigCheck.Checked = true;
            this.ConfigCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfigCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConfigCheck.ForeColor = System.Drawing.Color.Black;
            this.ConfigCheck.Location = new System.Drawing.Point(64, 435);
            this.ConfigCheck.Name = "ConfigCheck";
            this.ConfigCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.ConfigCheck.Size = new System.Drawing.Size(205, 35);
            this.ConfigCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.ConfigCheck.TabIndex = 11;
            this.ConfigCheck.Text = "配置校验";
            this.ConfigCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ConfigCheck.TickThickness = 2;
            // 
            // PrePicture
            // 
            this.PrePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.PrePicture.Image = global::UI.Properties.Resources.pre;
            this.PrePicture.Location = new System.Drawing.Point(12, 105);
            this.PrePicture.Margin = new System.Windows.Forms.Padding(0);
            this.PrePicture.Name = "PrePicture";
            this.PrePicture.Size = new System.Drawing.Size(55, 45);
            this.PrePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PrePicture.TabIndex = 10;
            this.PrePicture.TabStop = false;
            this.PrePicture.Click += new System.EventHandler(this.BackLabel_Click);
            // 
            // TestItemChooseLabel
            // 
            this.TestItemChooseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(247)))), ((int)(((byte)(171)))));
            this.TestItemChooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TestItemChooseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.TestItemChooseLabel.Location = new System.Drawing.Point(64, 277);
            this.TestItemChooseLabel.Name = "TestItemChooseLabel";
            this.TestItemChooseLabel.Size = new System.Drawing.Size(205, 45);
            this.TestItemChooseLabel.TabIndex = 7;
            this.TestItemChooseLabel.Text = "测试项选择";
            // 
            // RTCCheck
            // 
            this.RTCCheck.BadgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.RTCCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.RTCCheck.CheckboxCheckColor = System.Drawing.Color.Black;
            this.RTCCheck.CheckboxColor = System.Drawing.SystemColors.ActiveCaption;
            this.RTCCheck.CheckboxHoverColor = System.Drawing.Color.SeaGreen;
            this.RTCCheck.CheckboxStyle = ReaLTaiizor.Controls.ParrotCheckBox.Style.iOS;
            this.RTCCheck.Checked = true;
            this.RTCCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RTCCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RTCCheck.ForeColor = System.Drawing.Color.Black;
            this.RTCCheck.Location = new System.Drawing.Point(64, 355);
            this.RTCCheck.Name = "RTCCheck";
            this.RTCCheck.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.RTCCheck.Size = new System.Drawing.Size(205, 35);
            this.RTCCheck.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.RTCCheck.TabIndex = 6;
            this.RTCCheck.Text = "RTC测试";
            this.RTCCheck.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.RTCCheck.TickThickness = 2;
            // 
            // BackLabel
            // 
            this.BackLabel.AutoSize = true;
            this.BackLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(227)))), ((int)(((byte)(171)))));
            this.BackLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BackLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.BackLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BackLabel.Location = new System.Drawing.Point(62, 105);
            this.BackLabel.Margin = new System.Windows.Forms.Padding(0);
            this.BackLabel.Name = "BackLabel";
            this.BackLabel.Size = new System.Drawing.Size(203, 42);
            this.BackLabel.TabIndex = 4;
            this.BackLabel.Text = "返回主页面\r\n";
            this.BackLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BackLabel.Click += new System.EventHandler(this.BackLabel_Click);
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.BackColor = System.Drawing.Color.Transparent;
            this.StartLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.StartLabel.Location = new System.Drawing.Point(887, 203);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(92, 42);
            this.StartLabel.TabIndex = 3;
            this.StartLabel.Text = "开始";
            this.StartLabel.Click += new System.EventHandler(this.StartLabel_Click);
            // 
            // TimerBar
            // 
            this.TimerBar.BarStyle = ReaLTaiizor.Controls.ParrotFlatProgressBar.Style.Material;
            this.TimerBar.BorderColor = System.Drawing.Color.Black;
            this.TimerBar.Colors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("TimerBar.Colors")));
            this.TimerBar.CompleteBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(250)))));
            this.TimerBar.CompleteColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.TimerBar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.TimerBar.IncompletedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TimerBar.InocmpletedColor = System.Drawing.Color.White;
            this.TimerBar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.TimerBar.Location = new System.Drawing.Point(30, 211);
            this.TimerBar.MaxValue = 30;
            this.TimerBar.Name = "TimerBar";
            this.TimerBar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.TimerBar.Positions = ((System.Collections.Generic.List<float>)(resources.GetObject("TimerBar.Positions")));
            this.TimerBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TimerBar.ShowBorder = true;
            this.TimerBar.Size = new System.Drawing.Size(768, 37);
            this.TimerBar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.TimerBar.TabIndex = 2;
            this.TimerBar.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.TimerBar.Value = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.TitleLabel.Location = new System.Drawing.Point(270, 41);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(510, 152);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "测试设置";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 900);
            this.Controls.Add(this.myForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1030);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.myForm1.ResumeLayout(false);
            this.myForm1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyForm myForm1;
        private ReaLTaiizor.Controls.ParrotFlatProgressBar TimerBar;
        private ReaLTaiizor.Controls.BigLabel TitleLabel;
        private ReaLTaiizor.Controls.BigLabel StartLabel;
        private ReaLTaiizor.Controls.BigLabel BackLabel;
        private ReaLTaiizor.Controls.ParrotCheckBox RTCCheck;
        private ReaLTaiizor.Controls.BigLabel TestItemChooseLabel;
        private PictureBox PrePicture;
        private ReaLTaiizor.Controls.BigLabel ReminderLabel;
        private ReaLTaiizor.Controls.ParrotCheckBox MemoryBurnerCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox CPUBurnerCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox DiskBurnerCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox NetworkPortCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox SerialPortCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox USBCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox AudioInterfaceCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox DiskSmartCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox ConfigCheck;
        private HZH_Controls.Controls.UCSwitch QuickSwitch;
        private PictureBox settingPicture;
        private ReaLTaiizor.Controls.BigLabel LeaveTimeLabel;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private ReaLTaiizor.Controls.ParrotCheckBox DiskBadCheck;
        private ReaLTaiizor.Controls.ParrotCheckBox MACAddressCheck;
    }
}