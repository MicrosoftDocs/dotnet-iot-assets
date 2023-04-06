using System;
using System.Device.Spi;
using System.Threading;
using Iot.Device.Adc;

var hardwareSpiSettings = new SpiConnectionSettings(0, 0);

using SpiDevice spi = SpiDevice.Create(hardwareSpiSettings);
using var mcp = new Mcp3008(spi);
while (true)
{
    Console.Clear();
    double value = mcp.Read(0);
    Console.WriteLine($"{value}");
    Console.WriteLine($"{Math.Round(value/10.23, 1)}%");
    Thread.Sleep(500);
}