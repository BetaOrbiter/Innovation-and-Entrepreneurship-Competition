using Hardware.Info;
using System.Media;
System.Media.SystemSounds.Beep.Play();


//System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\李洲诚\Music\08 前前前世 (movie ver.).flac");
//player.Play();

//测试不同类的临时项目
//using System.IO.Ports;
//using Hardware.Info;

//string[] names = SerialPort.GetPortNames();
//SerialPort[] serialPorts = new SerialPort[names.Length];

//for (int i = 0; i < serialPorts.Length; i++)
//{
//    serialPorts[i] = new SerialPort(names[i])
//    {
//        BaudRate = 2400,
//        DataBits = 8,
//        StopBits = StopBits.One,
//        Handshake = Handshake.None
//    };
//}
//serialPorts[0].Open();
//serialPorts[1].Open();

//serialPorts[0].WriteLine("sdkfhskldfjsa;lkjfsklfjsadlkfjsdlkfjsdfkldsjfsdlkfj");
//Console.WriteLine(serialPorts[1].ReadLine());
//serialPorts[1].WriteLine("19273918742985729873469873498673496873698376983476983467");
//Console.WriteLine(serialPorts[0].ReadLine());


HardwareInformation Hardware = new();
Hardware.RefreshDriveList();
foreach (var drive in Hardware.DriveList)
{
    Console.WriteLine(drive.Caption);
    Console.WriteLine(drive.Description);
    Console.WriteLine(drive.FirmwareRevision);
    Console.WriteLine(drive.Index);
    Console.WriteLine(drive.Manufacturer);
    Console.WriteLine(drive.Model);
    Console.WriteLine(drive.Name);
    Console.WriteLine(drive.SerialNumber);
    Console.WriteLine(drive.Size);
    Console.WriteLine(drive.Partitions);
    foreach (var partion in drive.PartitionList)
    {
        Console.WriteLine(partion.Index);
        Console.WriteLine(partion.Name);
        Console.WriteLine(partion.Description);
        foreach (var v in partion.VolumeList)
        {
            Console.WriteLine(v.VolumeName);
            Console.WriteLine(v.Description);
            Console.WriteLine(v.Name);
            Console.WriteLine(v.Caption);
        }
    }
    Console.Write(Environment.NewLine);
}