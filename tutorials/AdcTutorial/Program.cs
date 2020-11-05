
using System;
using System.Device.Spi;
using System.Threading;
using Iot.Device.Adc;

var hardwareSpiSettings = new SpiConnectionSettings(0, 0);

using SpiDevice spi = SpiDevice.Create(hardwareSpiSettings);
using Mcp3008 mcp = new Mcp3008(spi);
while (true)
{
    double value = mcp.Read(0);
    value = value / 10.24;
    value = Math.Round(value);
    Console.WriteLine($"{value}%");
    Thread.Sleep(500);
}