using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace MauiApp1.Pages;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnGoToCalculatorClicked(object sender, EventArgs e)
    {
        // Navega para a página de calculadora
        Debug.WriteLine($"Entrou");
        await Shell.Current.GoToAsync("//calculator");
    }
}
