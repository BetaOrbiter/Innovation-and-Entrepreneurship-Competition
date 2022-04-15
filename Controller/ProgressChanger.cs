using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    //改变悬浮球、标题等进度的控制器
    public static class ProgressChanger
    {
        public static Action<TestType,int,int> UpdateProgressUI;
        public static void Update(TestType step, int nowProgress, int totalProgress)
        {
            UpdateProgressUI(step, nowProgress, totalProgress);
        }
    }
}
