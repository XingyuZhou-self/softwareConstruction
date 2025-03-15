using System;
using System.Threading;

namespace AlarmClockDemo
{
    // 定义闹钟类
    public class AlarmClock
    {
        // 定义嘀嗒事件
        public event EventHandler Tick;
        // 定义响铃事件
        public event EventHandler Alarm;

        private int tickCount = 0;
        private int alarmTickCount; // 到达指定嘀嗒次数后触发响铃

        // 构造函数，传入闹钟响铃前需要嘀嗒的次数
        public AlarmClock(int alarmTickCount)
        {
            this.alarmTickCount = alarmTickCount;
        }

        // 模拟闹钟运行
        public void Start()
        {
            while (tickCount < alarmTickCount)
            {
                Thread.Sleep(1000); // 模拟1秒钟的时间流逝
                tickCount++;
                // 触发嘀嗒事件
                Tick?.Invoke(this, EventArgs.Empty);
            }
            // 达到指定次数后，触发响铃事件
            Alarm?.Invoke(this, EventArgs.Empty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个闹钟实例，设定5次嘀嗒后响铃
            AlarmClock alarmClock = new AlarmClock(5);

            // 订阅嘀嗒事件，输出提示信息
            alarmClock.Tick += (sender, e) =>
            {
                Console.WriteLine("嘀嗒...");
            };

            // 订阅响铃事件，输出提示信息
            alarmClock.Alarm += (sender, e) =>
            {
                Console.WriteLine("响铃：闹钟响了！");
            };

            Console.WriteLine("闹钟启动...");
            alarmClock.Start();
            Console.WriteLine("闹钟停止.");
        }
    }
}
