# DynamicContentControl
A WPF control that dynamically renders its content from a XAML string.

Nuget package comming soon.

Latest release comming soon.

##Features

##Samples

###Getting started
**XAML**
```c#
<Window x:Class="Sturnus.Wpf.DynamicContentControl.Demo.SampleView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        xmlns:sturnus="http://www.github.com/sturnus/dynamiccontentcontrol"
        Title="SampleView" Height="300" Width="300" Background="Black" Foreground="White"
        DataContext="{Binding SampleViewModel, Source={StaticResource ViewModelLocator}}">

    <Grid>
        <sturnus:DynamicContentControl XamlText="{Binding HelloWorld}" XamlNamespaces="{StaticResource xamlNamespaces}" Margin="5"/>
    </Grid>
</Window>
```

**DataContext**
```c#
public string HelloWorld
{
    get
    {
        return @"<TextBlock xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" Text=""Hello World!"" />";
    }
}
```

Notice how the HelloWorld XAML string above contains the xmlns XAML namespace. The DynamicContentControl is rendered outside of its containing element (Window). You must therefore specify each XAML namespace used..

Alternatively, you can provide the DynamicContentControl with a string array of XAML namespaces

**XAML**
```c#
<Window x:Class="Sturnus.Wpf.DynamicContentControl.Demo.SampleView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        xmlns:sturnus="http://www.github.com/sturnus/dynamiccontentcontrol"
        Title="SampleView" Height="300" Width="300" Background="Black" Foreground="White"
        DataContext="{Binding SampleViewModel, Source={StaticResource ViewModelLocator}}">

    <Window.Resources>
        <x:Array x:Key="xamlNamespaces" Type="sys:String">
            <sys:String>xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"</sys:String>
        </x:Array>
    </Window.Resources>
    
    <Grid>
        <sturnus:DynamicContentControl XamlText="{Binding HelloWorld}" XamlNamespaces="{StaticResource xamlNamespaces}" Margin="5"/>
    </Grid>
</Window>
```

**DataContext**
```c#
public string HelloWorld
{
    get
    {
        return @"<TextBlock Text=""Hello World!"" />";
    }
}
```

###Third party controls
When using third party controls you must specify their assembly name in the applicable XAML namespace, using the ;assembly=<name> attribute. You must do this even if the control has a defined XML namespace. This allows the DynamicContentControl to load the library into memory. 

The example below uses the WPFAnimatedGIF library. For more information please visit [https://github.com/thomaslevesque/WpfAnimatedGif](https://github.com/thomaslevesque/WpfAnimatedGif)

**XAML**
```c#
<Window x:Class="Sturnus.Wpf.DynamicContentControl.Demo.SampleView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        xmlns:sturnus="http://www.github.com/sturnus/dynamiccontentcontrol"
        Title="Sample" Height="340" Width="260" Background="Black" Foreground="White"
        DataContext="{Binding SampleViewModel, Source={StaticResource ViewModelLocator}}">

    <Window.Resources>
        <x:Array x:Key="xamlNamespaces" Type="sys:String">
            <sys:String>xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"</sys:String>
            <sys:String>xmlns:gif="http://wpfanimatedgif.codeplex.com;assembly=WPFAnimatedGIF"</sys:String>
        </x:Array>
    </Window.Resources>
    
    <Grid>
        <StackPanel>
            <sturnus:DynamicContentControl XamlText="{Binding HelloWorld}" XamlNamespaces="{StaticResource xamlNamespaces}" Margin="5"/>
            <sturnus:DynamicContentControl XamlText="{Binding Homer}" XamlNamespaces="{StaticResource xamlNamespaces}" Margin="5"/>
        </StackPanel>
    </Grid>
</Window>
```

**DataContext**
```c#
public string Homer
{
    get
    {
        return @"<StackPanel HorizontalAlignment=""Left"">
                     <TextBlock Text=""D'oh!!!"" />
                     <Image gif:ImageBehavior.AnimatedSource=""Images/homer.gif"" gif:ImageBehavior.AnimateInDesignMode=""True"" Width=""250"" Height=""250"" />
                 </StackPanel>";
    }
}
```

Copryright (c) 2015 Jeroen Spreeuwenberg