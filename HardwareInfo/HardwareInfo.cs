using Krugertech.IO.Smart;
namespace Hardware.Info
{
    /// <summary>
    /// 查询硬件配置信息类,继承自Hardware.Info.HardwareInfo
    /// 不可查询即时信息如负载温度等(其实可以,bushi)
    /// </summary>
    public class HardwareInformation : HardwareInfo
    {
        /// <summary>
        /// 硬盘smart信息,与其他信息来自不同包故用法不同
        /// </summary>
        public DriveCollection? DrivesSMARTs { get; init; }

        /// <summary>
        /// <see cref="HardwareInfo.DriveList"/>的非USB硬盘子集(浅拷贝)<br/>
        /// 每次访问该属性均会浅拷贝并过滤<see cref="HardwareInfo.DriveList"/>
        /// </summary>
        public List<Drive> DiskList
        {
            get
            {
                var shadowList = DriveList.GetRange(0, DriveList.Count);
                shadowList.RemoveAll(drive => !drive.Name.ToLower().Contains("usb"));
                return shadowList;
            }
        }
        
        /// <summary>
        /// <see cref="HardwareInfo.DriveList"/>的USB硬盘子集(浅拷贝)<br/>
        /// 每次访问该属性均会浅拷贝并过滤<see cref="HardwareInfo.DriveList"/>
        /// </summary>
        public List<Drive> UsbDsikList
        {
            get
            {
                var shadowList = DriveList.GetRange(0, DriveList.Count);
                shadowList.RemoveAll(drive => drive.Name.ToLower().Contains("usb"));
                return shadowList;
            }
        }

        public HardwareInformation() : base()
        {
            DrivesSMARTs = SmartDrive.GetDrives();
            DrivesSMARTs.RemoveAll(drive => drive.IsSupported == false);
            foreach (var drive in DrivesSMARTs)
                drive.SmartAttributes.RemoveAll(s => s.HasData == false);
        }
    }
}