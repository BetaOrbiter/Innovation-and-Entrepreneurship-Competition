namespace Controller
{
    public enum TestType
    {
        RTCTest,//RTC测试
        CPUConfigCheck,//CPU配置校验
        MemoryConfigCheck,//内存配置校验
        GPUConfigCheck,//显卡配置校验
        DiskConfigCheck,//硬盘配置校验
        DiskSmartTest,//硬盘Smart信息检查
        DiskBadTest,//硬盘坏道测试
        AudioInterfaceTest,//音频接口测试
        USBTest,//USB接口测试
        SerialPortTest,//串口测试
        NetworkPortTest,//网口数据测试
        MACAddressTest,//MAC地址检查
        DiskBurnerTest,//硬盘压力测试
        CPUBurnerTest,//CPU压力测试
        MemoryBurnerTest,//内存压力测试
        TestFinish//测试完成
    }
}
