using System;
using System.Device.Gpio;
using System.Device.I2c;
using System.Threading;
using Iot.Device.CharacterLcd;
using Iot.Device.Pcx857x;

Console.WriteLine("Displaying current time. Press Ctrl+C to end.");

using I2cDevice i2c = I2cDevice.Create(new I2cConnectionSettings(1, 0x27));
using var driver = new Pcf8574(i2c);
using var lcd = new Lcd2004(registerSelectPin: 0, 
                        enablePin: 2, 
                        dataPins: new int[] { 4, 5, 6, 7 }, 
                        backlightPin: 3, 
                        backlightBrightness: 0.1f, 
                        readWritePin: 1, 
                        controller: new GpioController(PinNumberingScheme.Logical, driver));
int currentLine = 0;

while (true)
{
    lcd.Clear();
    lcd.SetCursorPosition(0,currentLine);
    lcd.Write(DateTime.Now.ToShortTimeString());
    currentLine = (currentLine == 3) ? 0 : currentLine + 1; 
    Thread.Sleep(1000);
}