![](https://img.shields.io/badge/Creater-TCT-FFFF00) ![](https://img.shields.io/badge/development-csharp-006400) ![](https://img.shields.io/badge/SDK-DotNet8-blue) ![](https://img.shields.io/badge/Tool-VisualStudio2022-222222) ![](https://img.shields.io/badge/OS-Windows-FF8022) ![](https://img.shields.io/badge/UI-WPF-FF6666)

# TCTUI
TCTUI/UI元件

提供 XAML 專案可使用的精美元件，讓開發者在XAML內不用撰寫太多額外外觀程式碼

------

## 1. Package:TCTUI

1.請新增 TCTUI 套件至專案內

*Please add TCTUI Package in Projets*

![image](https://github.com/user-attachments/assets/6ee778a1-daa3-4cff-8a00-6094fa098817)


2.請新增以下程式碼在XAML內的Window區域內

*Please add codes as below in XAML's Window Range*

```bash
<Window x:Class="TCTWindow.MainWindow"
        ......
        xmlns:tctbutton="clr-namespace:TCTUI.TCTButton;assembly=TCTUI"       
        xmlns:tctcolor="clr-namespace:TCTUI.TCTColor;assembly=TCTUI"        
        >
```

------

### 1-1. Button:TCTCycleButton
圓形按鈕

請參考以下程式碼:

*Please refer the codes as below*

```bash

```

------

### 1-2. Button:TCTRectangleButton
矩形按鈕

請參考以下程式碼:

*Please refer the codes as below*

```bash
<tctbutton:TCTRectangleButton x:Name="TCTRectangleButtonText1" Content="1 Default" MajorColor="Blue" MinorColor ="White" StyleType="Default" Click="DoButtonYes" FontSize="20" Width="200" Height="100"></tctbutton:TCTRectangleButton>
```

```bash
<tctbutton:TCTRectangleButton x:Name="TCTRectangleButtonText3" Content="3 Obvious" MajorColor="{x:Static tctcolor:TCTSolidColorBrush.LightBlue}" MinorColor ="White" StyleType="Obvious" Click="DoButtonYes" FontSize="20" Width="200" Height="100"></tctbutton:TCTRectangleButton>
```

```bash
<tctbutton:TCTRectangleButton x:Name="TCTRectangleButtonText5" Content="5 ObviousDefault" MajorColor="{x:Static tctcolor:TCTSolidColorBrush.LightBlue}" MinorColor ="White" StyleType="ObviousDefault" Click="DoButtonYes" FontSize="20" Width="200" Height="100"></tctbutton:TCTRectangleButton>
```



                    

                    

![20250318-1](https://github.com/user-attachments/assets/564075d9-da93-4912-b375-fa41a0c9e414)

