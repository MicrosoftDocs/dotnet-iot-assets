using System.Device.Gpio;
using System.Threading;

int pin = 21;
string alert = "ALERT! 🚨";
string ready = "Ready ✅";

using var controller = new GpioController();
controller.OpenPin(pin, PinMode.InputPullUp);
Console.WriteLine($"Initial status ({DateTime.Now}): {(controller.Read(pin) == PinValue.High ? alert : ready)}");
controller.RegisterCallbackForPinValueChangedEvent(pin, 
    PinEventTypes.Falling | PinEventTypes.Rising, 
    (sender, args) => onButtonChange(sender, args));

Thread.Sleep(Timeout.Infinite);

void onButtonChange(object sender, PinValueChangedEventArgs pinValueChangedEventArgs)
{     
    Console.WriteLine($"({DateTime.Now}) {(pinValueChangedEventArgs.ChangeType == PinEventTypes.Rising ? alert : ready)}");
}