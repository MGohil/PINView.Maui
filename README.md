# PINView.Maui (.NET Maui UI control)

PINView is .NET Maui cross platform UI control to facilitate UI for mobile PIN (MPIN), OTP or Verification Code entry.
This control can be used for Login using PIN, Creting New PIN, Change PIN, Entering secure OTP screens in your mobile application.

![](https://github.com/MGohil/PINView.Maui/blob/master/arts/showcase.gif)

<kbd>
    <img src="https://github.com/MGohil/PINView.Maui/blob/master/arts/Preview-Graphic.png" width="800">
</kbd>


<br><br>
If you are happy using this control and feeling generous, consider buying me a Coffee. :grinning: 

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/mgohil213)


## Nuget Package
[![NuGet](https://img.shields.io/nuget/v/PINView.Maui.svg)](https://www.nuget.org/packages/PINView.Maui/)

[![NuGet Downloads](https://img.shields.io/nuget/dt/PINView.Maui.svg)](https://www.nuget.org/packages/PINView.Maui/)

### Platforms Supported
- [X] iOS
- [X] MacCatalyst
- [X] Android
- [X] Windows


## Steps
1. Search for PINView.Maui [nuget](https://www.nuget.org/packages/PINView.Maui/) package and install it in your .NET Maui project. 
2. In your Page, add reference to this package:
```xmlns:pinview="clr-namespace:PINView.Maui;assembly=PINView.Maui"```
3. Use the control like below:
```
<pinview:PINView
    BoxBackgroundColor="#FEDBD0"
    BoxShape="Circle"
    PINLength="5"
    PINValue="{Binding PIN}"
    Color="#442C2E" />
```                
## Properties Definitions
| Property | Type | Default | Description |
| ----------| --- | --- | --- |
| AutoDismissKeyboard | Boolean | False | Decides whether to dismiss the keyboard automatically when all characters entered |
| BoxBackgroundColor | Color | Transparent | Defines the BackgroundColor of each PIN Box |
| BoxBorderColor | Color | Color Property Value | Defines the Border Color of each PIN Box |
| BoxCornerRadius | double | 10.0 | Defines the Corner Radius of each PIN box. |
| BoxFocusAnimation | Enum | None | Animates the Box when it receives the Focus. Enum values [ None, ZoomInOut, ScaleUp ]|
| BoxFocusColor | Color | Black | Defines the Focus Indicator Border Color when PIN Box is Focused |
| BoxShape | Enum | Circle | Defines the shape of PIN Box from Enum values [ Square, RoundCorner, Circle ] |
| BoxSize | Double | 50 | Defines the Width and Height of each PIN Box |
| BoxSpacing | Double | 5 | Defines the space among each PIN Box |
| BoxStrokeDashArray | DoubleCollection | null | Sets the Stroke (Border) as Dashed line |
| BoxStrokeDashOffset | double | 1.0 | Defines the distance within the dash pattern where a dash begins |
| BoxStrokeThickness | double | 1.0 | Sets the Thickness of Stroke (Border) of each PinBoxes |
| Color | Color | Accent | Defines the Color of PIN Box (Border and Dot) |
| DotSize | double | 20.0 | Sets the Dot size of each Dots in PINBoxes |
| FontAttributes | FontAttributes | None | Sets the FontAttributes of the Char label in each box. Applicable when IsPassword = False |
| FontFamily | string | System Font | Sets the FontFamily of the Char label in each box. Applicable when IsPassword = False |
| FontSize | double | 20.0 | Sets the Font size of each char Label in PinBoxes |
| FontAutoScalingEnabled | Boolean | True | Allows to disable font accessibility scaling, which is enabled by default in MAUI |
| IsPassword | Boolean | False | Defines whether to show actual input character or hide / secure via Dot |
| PINInputType | Enum | Numeric | Defines the Input Type from Enum [ Numeric, AlphaNumeric, AlphaNumericUppercase ] |
| PINLength | Integer | 4 | Defines the Length (No. of Characters) of the PIN |
| PINValue | String | Empty | Bind this to string Property in your ViewModel, to get value of the Entered PIN |


## Commands / Events Definitions
| Command / Event | Type | Description |
| ----------| --- | --- |
| PINEntryCompletedCommand | Command | A Bindable Command, which gets invoked on completion of the PIN entry (All characters are entered) You can execute your code through this command |
| PINEntryCompleted | Event | Invokes on completion of the PIN entry (when all characters are entered). |

## Accessibility
| Property | Type | Default | Description |
| ----------| --- | --- | --- |
| AutomationId | string | null | This control uses Hidden Entry behind the scene to hold PIN input value. To work with Automation, you have to set AutomationId of this PINView control, and it will internally set the AutomationId of this hidden Entry. If you set AutomationId of PINView control as 'ConfirmPIN' then AutomationId of hidden Entry will be 'ConfirmPIN_PINView_Entry'. You can get the hidden Entry's AutomationId using HiddenEntryAutomationId property.|

