# WPF DynamicContentControl
A WPF control that dynamically renders its content from a XAML string.

##Release
NuGet package available [here](https://www.nuget.org/packages/Sturnus.Wpf.DynamicContentControl).

Latest release available [here](https://github.com/Sturnus/DynamicContentControl/releases).

##Features
* Dynamically renders XAML content from a string.
* Provides bindable Dependency Property to set the control's content.
* Rerenders entire control when Dependency Property's context is changed. 
* Supports third party libraries and components.

##Samples
###Getting started
The DynamicContentControl exposes two Dependency Properties; XamlText and XamlNamespaces. Bind your XAML text (dynamic content) to the first and bind a collection of XAML namespaces used in your XAML text to the latter. The XAML namespaces must be defined as the DynamicContentControl renders its content outside the scope of the containing Window. 

The example below binds XamlText to a property in the Window's DataContext and XamlNamespaces to a string array defined in the Window's Resources. You could also create the collection in your DataContext and bind to it.

**XAML**
```xml
<Window x:Class="Sturnus.Wpf.DynamicContentControl.Demo.SampleView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        xmlns:sturnus="http://www.github.com/sturnus/dynamiccontentcontrol"
        Title="Samples" Height="340" Width="260" Background="Black" Foreground="White"
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
When using third party controls you must specify their assembly name in the applicable XAML namespace, using the ;assembly=assemblyName attribute. You must do this even if the control has a defined XML namespace. This allows the DynamicContentControl to load the thirs party library into its context and render elements depending on it. This also applies to CLR namespaces.

The example below uses the WpfAnimatedGif library. For more information please visit [https://github.com/thomaslevesque/WpfAnimatedGif](https://github.com/thomaslevesque/WpfAnimatedGif)

**XAML**
```xml
<Window x:Class="Sturnus.Wpf.DynamicContentControl.Demo.SampleView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        xmlns:sturnus="http://www.github.com/sturnus/dynamiccontentcontrol"
        Title="Samples" Height="340" Width="260" Background="Black" Foreground="White"
        DataContext="{Binding SampleViewModel, Source={StaticResource ViewModelLocator}}">

    <Window.Resources>
        <x:Array x:Key="xamlNamespaces" Type="sys:String">
            <sys:String>xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"</sys:String>
            <sys:String>xmlns:gif="http://wpfanimatedgif.codeplex.com;assembly=WpfAnimatedGif"</sys:String>
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
