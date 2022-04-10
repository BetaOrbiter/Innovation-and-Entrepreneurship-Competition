namespace MyTool
{
    /// <summary>
    /// 硬盘压力测试类
    /// </summary>
    public sealed class DiskStresser : StresserBase
    {
        /// <summary>
        /// <c>0</c>至<c>100</c>的整数,写操作比例,默认<c>50</c>
        /// </summary>
        /// <value>
        /// <c>0</c> 表示全读 <br/>
        /// <c>100</c> 表示全写 <br/>
        /// </value>
        public int WriteRate { get; set; } = 50;

        /// <summary>
        /// 目标文件大小(单位B),默认1G
        /// </summary>
        public ulong FileSize { get; set; } = 1024 * 1024 * 1024;


        /// <summary>
        /// 块大小(单位B), 默认4M
        /// </summary>
        public ulong BloclSize { get; set; } = 4 * 1024 * 1024;
        /// <summary>
        /// 目标文件路径的集合
        /// </summary>
        public List<string> TestFilePathes { get; set; }


        /// <summary>
        /// 构建一个硬盘压力测试器对象
        /// </summary>
        /// <param name="executablePath">可执行文件路径</param>
        /// <param name="testFilePathes">目标文件路径</param>
        public DiskStresser(string executablePath, List<string> testFilePathes, int stressTime = 60 * 60 * 3)
            :base(executablePath)
        {
            TestFilePathes = testFilePathes;
            StressTime = stressTime;
        }

        protected override void SetArguments()
        {
            string com = $"-D -c{FileSize/1024}K -b{BloclSize/1024}K -t{ThreadNumber} -w{WriteRate} -o32 -d{StressTime} -Su";

            Program.StartInfo.ArgumentList.Add("-D");
            Program.StartInfo.ArgumentList.Add($"-c{FileSize / 1024}K");
            Program.StartInfo.ArgumentList.Add($"-b{BloclSize / 1024}K");
            Program.StartInfo.ArgumentList.Add($"-t{ThreadNumber}");
            Program.StartInfo.ArgumentList.Add($"-w{WriteRate}");
            Program.StartInfo.ArgumentList.Add("-r");
            Program.StartInfo.ArgumentList.Add("-o32");
            Program.StartInfo.ArgumentList.Add($"-d{StressTime}");
            Program.StartInfo.ArgumentList.Add($"-Su");
            Program.StartInfo.ArgumentList.Add($"-D");
            foreach(var target in TestFilePathes)
            {
                Program.StartInfo.ArgumentList.Add(target);
            }
        }
    }
}