namespace MyTool
{
    /// <summary>
    /// cpu压力测试类
    /// </summary>
    public sealed class CpuStresser:StresserBase
    {
        /// <summary>
        /// 构建一个cpu压力测试器对象
        /// </summary>
        /// <param name="executablePath">可执行文件路径</param>
        /// <param name="stressTime">烤cpu时间,默认3小时</param>
        public CpuStresser(string executablePath, int stressTime = 60 * 60 * 3)
            :base(executablePath)
        {
            StressTime = stressTime;
        }

        protected override void SetArguments()
        {
            Program.StartInfo.Arguments = $"{StressTime} {ThreadNumber}";
        }
    }
}
