# PINView.Maui (.NET Maui UI control)

PINView is .NET Maui cross platform UI control to facilitate UI for mobile PIN (MPIN), OTP or Verification Code entry.
This control can be used for Login using PIN, Creting New PIN, Change PIN, Entering secure OTP screens in your mobile application.

![](https://github.com/MGohil/PINView.Maui/blob/master/arts/showcase.gif)

<kbd>
    <img src="https://github.com/MGohil/PINView.Maui/blob/master/arts/Preview-Graphic.png" width="800">
</kbd>


<br><br>
Liking the control?

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/mgohil213)


## Nuget Package
https://www.nuget.org/packages/PINView.Maui/

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
| AutoDismissKeyboard | Boolean | False | Decides whether to dismiss the keyboard automatically when all charecters entered |
| BoxBackgroundColor | Color | Transparent | Defines the BackgroundColor of each PIN Box |
| BoxBorderColor | Color | Color Property Value | Defines the Border Color of each PIN Box |
| BoxBorderThickness | double | 1.0 | Sets the Thickness of Border of each PinBoxes |
| BoxFocusColor | Color | Black | Defines the Focus Indicator Border Color when PIN Box is Focused |
| BoxFocusAnimation | Enum | None | Animates the Box when it receives the Focus. Enum values [ None, ZoomInOut, ScaleUp ]|
| BoxShape | Enum | Circle | Defines the shape of PIN Box from Enum values [ Squere, RoundCorner, Circle ] |
| BoxSize | Double | 50 | Defines the Width and Height of each PIN Box |
| BoxSpacing | Double | 5 | Defines the space among each PIN Box |
| Color | Color | Accent | Defines the Color of PIN Box (Border and Dot) |
| DotSize | double | 20.0 | Sets the Dot size of each Dots in PinBoxes |
| FontAttributes | FontAttributes | None | Sets the FontAttributes of the Char label in each box. Applicable when IsPassword = False |
| FontFamily | string | System Font | Sets the FontFamily of the Char label in each box. Applicable when IsPassword = False |
| IsPassword | Boolean | False | Defines whether to show actual input character or hide / secure via Dot |
| PINInputType | Enum | Numeric | Defines the Input Type from Enum [ Numeric, AlphaNumeric ] |
| PINLength | Integer | 4 | Defines the Length (No. of Characters) of the PIN |
| PINValue | String | Empty | Bind this to string Property in your ViewModel, to get value of the Entered PIN |


## Commands / Events Definitions
| Command / Event | Type | Description |
| ----------| --- | --- |
| PINEntryCompletedCommand | Command | A Bindable Command, which gets invoked on completion of the PIN entry (All charecters are entered) You can execute your code through this command |
| PINEntryCompleted | Event | Invokes on completion of the PIN entry (when all charecters are entered). |
