namespace MyTool
{
    /// <summary>
    /// 内存压力测试类
    /// </summary>
    public sealed class MemoryStresser:StresserBase
    {
        
        /// <summary>
        /// 物理内存大小,单位:B
        /// </summary>
        public ulong PhysicalMemorySize { get; set; }
        
        /// <summary>
        /// 构建一个内存压力测试器对象
        /// </summary>
        /// <param name="executablePath">可执行文件路径</param>
        /// <param name="physicalMemorySize">物理内存大小,单位B</param>
        public MemoryStresser(string executablePath, ulong physicalMemorySize, int stressTime = 6 * 60 * 60)
            :base(executablePath)
        {
            PhysicalMemorySize = physicalMemorySize;
            StressTime = stressTime;
        }

        protected override void SetArguments()
        {
            Program.StartInfo.Arguments = $"{PhysicalMemorySize} {StressTime} {ThreadNumber}";
        }
    }
}
