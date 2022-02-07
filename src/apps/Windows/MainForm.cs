using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using SharedUI;

namespace Windows;

public partial class MainForm : Form
{
    public MainForm()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddBlazorWebView();
        //serviceCollection.AddSingleton<AppState>(_appState);
        
        InitializeComponent();

        blazorWebView.HostPage = @"wwwroot\index.html";
        blazorWebView.Services = serviceCollection.BuildServiceProvider();
        blazorWebView.RootComponents.Add<App>("#app");
    }
}