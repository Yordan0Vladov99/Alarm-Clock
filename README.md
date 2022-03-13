# Alarm-Clock
An alarm clock app written in C#.

The app contains the following projects:
  1) ClockLib - a WPF Class Library that contains the following app components:
      - ClockTickArgs - a C#.NET class that is used for handling events. The class contains a Property ClockTick of type System.ValueTuple, formatted as (int hour, int minute, int second), and a parametrized constructor.
      - DigitalClock - a WPF user control with the following interface:
     
     ![image](https://user-images.githubusercontent.com/43996329/158061032-232351fe-7473-4983-a068-14129fee7854.png)

The class contains the ClockStarted and TimeUpdated event handlers and the timer attribute of type DispatcherTimer.
When the timer is started (by pressing the 'Start' button) the text field of DigitalClock is initialized to the current time (DateTime.Now) and is updated every second. After every second the TimeUpdated event is handled where the event object ClockTickArgs is updated to the current hour, minute and second. By pressing the 'Reset' button the text field is cleared. 
By pressing the 'Stop' button the timer is stopped.

  2) AlarmClockApp - a WPF app that implements the user interface.



![image](https://user-images.githubusercontent.com/43996329/158059123-99d88d73-bb90-4ce9-80a7-f6234a4641f4.png)

The app uses the the DigitalClock user control from the ClockLib project. The project also implements data binding between the Value and Text attributes in Slider (Binding source) and TextBox (Binding target) in the top right corner of the window. The TextBox values are formatted to display 1 digit after the decimal point.

The class contains the following attributes:
  - tuples startTime and currentTime, formatted as (int hour, int minute, int second)
  - rand of type Random
  - rightAfter of type double

The class handles the ClockStared and TimeUpdated events of DigitalClock, where:
  - the ClockStarted event handler initializes the startTime attribute by using the values of ClockTick. The event handler also initializes the ringAfter attribute with the value of the text field located next to the 'Ring After [min]' label. Finally it displays the start time in the text box below the 'Find Distinct Numbers' button.
  - the TimeUpdated event handler initializes the currentTime attribute by using the values of ClockTick. Also after every even second a random integer in the range \[10,50\] is displayed in the text field bellow the 'Beep Indicator' label. The event handler then checks if ringAfter minutes have passed between startTime and currentTime. If they have then SystemSounds.Beep.Play() command is activated. 

When the 'Find distinct numbers' button is pressed:
  - using LINQ all distinct numbers, generated since the clock was started, are displayed.
  - using LINQ the frequency of every number, generated since the clock was started, is displayed
