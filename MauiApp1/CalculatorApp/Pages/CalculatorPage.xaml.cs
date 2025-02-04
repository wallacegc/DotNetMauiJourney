using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace MauiApp1.CalculatorApp.Pages;

public partial class CalculatorPage : ContentPage
{
    private double _currentValue = 0;
    private string _currentOperation = string.Empty;
    private Boolean _currentDot = false;
    public CalculatorPage()
    {
        InitializeComponent();
    }

    // Método para adicionar números ao display
    private void OnNumberButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var buttonText = button.Text;

        if (DisplayLabel.Text == "0")
        {
            DisplayLabel.Text = buttonText; // Se o display for zero, substituímos o número
        }
        else
        {
            Debug.WriteLine($"a:{buttonText}");
            if (buttonText == ".")
            {
                if (_currentDot == false)
                {
                    _currentDot = true;
                }
                else
                {
                    buttonText = "";
                }
            }
            DisplayLabel.Text += buttonText; // Caso contrário, apenas concatenamos o número
        }
    }

    // Método para limpar o display
    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        DisplayLabel.Text = "0";
        _currentValue = 0;
        _currentOperation = string.Empty;
        _currentDot = false;
    }

    // Método para adicionar a operação de soma
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var buttonText = button.Text;

        _currentValue = Convert.ToDouble(DisplayLabel.Text); // Guardar o valor atual
        _currentOperation = buttonText; // Definir a operação como soma
        DisplayLabel.Text = "0"; // Limpar o display para o próximo número
    }

    // Método para realizar o cálculo
    private void OnEqualButtonClicked(object sender, EventArgs e)
    {
        double secondValue = Convert.ToDouble(DisplayLabel.Text); // Obter o segundo valor da operação

        switch (_currentOperation)
        {
            case "+":
                _currentValue += secondValue; // Realizar a soma
                break;
            case "-":
                _currentValue -= secondValue; // Realizar a subtração
                break;
            case "*":
                _currentValue *= secondValue; // Realizar a multiplicação
                break;
            case "/":
                if (secondValue != 0)  // Prevenir divisão por zero
                {
                    _currentValue /= secondValue; // Realizar a divisão
                }
                else
                {
                    DisplayLabel.Text = "Erro: Divisão por zero"; // Exibir erro
                    return; // Para a execução do método, já que ocorreu um erro
                }
                break;
            default:
                DisplayLabel.Text = "Erro: Operação desconhecida"; // Caso a operação seja desconhecida
                return; // Para a execução do método, já que ocorreu um erro
        }

        // Limita o número de caracteres a 12 e converte o valor para string
        string result = _currentValue.ToString();

        // Verifica se o número tem mais de 12 caracteres
        if (result.Length > 12)
        {
            result = result.Substring(0, 12); // Limita o valor a 12 caracteres
        }

        DisplayLabel.Text = result; // Exibe o valor final no display
    }
}
