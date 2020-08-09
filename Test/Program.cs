using Max6675;
using System;
using System.Device.Spi;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from Max6675!");


            GetTemp();
            Console.ReadLine();
        }

        static async void GetTemp()
        {
            var connectionSettings = new SpiConnectionSettings(0, 0)
            {
                ClockFrequency = Max6675.Max6675.SpiClockFrequency,
                Mode = SpiMode.Mode0
            };

            var spi = SpiDevice.Create(connectionSettings);
            using var max = new Max6675.Max6675(spi);

            while (true)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Temperature in celsius is: {max.Celsius()}");
            }
        }
    }
}
