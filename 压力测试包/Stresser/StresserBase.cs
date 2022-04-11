using System.Diagnostics;

namespace MyTool
{
    /// <summary>
    /// 一个<see cref="Process"/>的wrapper,方便指定一些属性<br/>
    /// 调用位于<see cref="ExcutablePath"/>处的外部可执行程序进行压力测试<br/>
    /// 调用者可指定测试时间和测试线程数
    /// </summary>
    public abstract class StresserBase:IDisposable
    {
        protected Process Program { get; set; } = new();
        
        /// <summary>
        /// 可执行文件路径
        /// </summary>
        public string ExcutablePath { get; set; }

        /// <summary>
        /// 压力测试时间(秒),默认三小时
        /// </summary>
        public int StressTime { get; set; } = 60 * 60 * 3;

        /// <summary>
        /// 测试线程数量,默认<see cref="System.Environment.ProcessorCount"/>个
        /// </summary>
        public uint ThreadNumber { get; set; } = (uint)System.Environment.ProcessorCount;
        
        public StresserBase(string executablePath)
        {
            ExcutablePath = executablePath;

            Program.StartInfo.CreateNoWindow = true;
            Program.StartInfo.UseShellExecute = false;
        }

        /// <summary>
        /// 实现类将配置属性转换成命令行参数
        /// </summary>
        protected abstract void SetArguments();

        /// <summary>
        /// 更新配置并启动(异步)<br/>
        /// 必须正确设置属性后调用
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if a process resource is started;
        /// <see langword="false"/> if no new process resource is started
        /// </returns>
        public bool Start()
        {
            Program.StartInfo.FileName = ExcutablePath;
            SetArguments();
            return Program.Start();
        }

        /// <summary>
        /// 立即停止相关进程
        /// </summary>
        /// <exception cref="System.ComponentModel.Win32Exception"/>
        /// <exception cref="System.NotSupportedException"/>
        /// <exception cref="System.InvalidOperationException"/>
        public void Kill() => Program.Kill();

        /// <summary>
        /// 指示<see cref="System.Diagnostics.Process"/>组件无期限地等待相关进程退出
        /// </summary>
        public void WaitForExit() => Program.WaitForExit();

        /// <summary>
        /// 指示<see cref="System.Diagnostics.Process"/>组件等待关联进程退出，至多<paramref name="seconds"/>秒
        /// </summary>
        /// <param name="seconds">
        /// 至多等待时长，单位：秒
        /// 0表示立即返回，-1表示无限等待
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the associated process has exited;
        /// otherwise, <see langword="false"/>
        /// </returns>
        public bool WaitForExit(int seconds) => Program.WaitForExit(seconds * 1000);

        /// <summary>
        /// Instructs the process component to wait for the associated process to exit, or for the <paramref name="cancellationToken"/> to be cancelled.
        /// </summary>
        /// <param name="cancellationToken">
        /// An optional token to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// A task that will complete when the process has exited, cancellation has been requested, or an error occurs.
        /// </returns>
        public Task WaitForExitAsync(CancellationToken cancellationToken = default) => Program.WaitForExitAsync(cancellationToken);

        public void Dispose() => ((IDisposable)Program).Dispose();
    }
}
