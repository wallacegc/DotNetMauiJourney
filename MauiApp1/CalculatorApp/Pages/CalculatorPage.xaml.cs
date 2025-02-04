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

    // M�todo para adicionar n�meros ao display
    private void OnNumberButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var buttonText = button.Text;

        if (DisplayLabel.Text == "0")
        {
            DisplayLabel.Text = buttonText; // Se o display for zero, substitu�mos o n�mero
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
            DisplayLabel.Text += buttonText; // Caso contr�rio, apenas concatenamos o n�mero
        }
    }

    // M�todo para limpar o display
    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        DisplayLabel.Text = "0";
        _currentValue = 0;
        _currentOperation = string.Empty;
        _currentDot = false;
    }

    // M�todo para adicionar a opera��o de soma
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var buttonText = button.Text;

        _currentValue = Convert.ToDouble(DisplayLabel.Text); // Guardar o valor atual
        _currentOperation = buttonText; // Definir a opera��o como soma
        DisplayLabel.Text = "0"; // Limpar o display para o pr�ximo n�mero
    }

    // M�todo para realizar o c�lculo
    private void OnEqualButtonClicked(object sender, EventArgs e)
    {
        double secondValue = Convert.ToDouble(DisplayLabel.Text); // Obter o segundo valor da opera��o

        switch (_currentOperation)
        {
            case "+":
                _currentValue += secondValue; // Realizar a soma
                break;
            case "-":
                _currentValue -= secondValue; // Realizar a subtra��o
                break;
            case "*":
                _currentValue *= secondValue; // Realizar a multiplica��o
                break;
            case "/":
                if (secondValue != 0)  // Prevenir divis�o por zero
                {
                    _currentValue /= secondValue; // Realizar a divis�o
                }
                else
                {
                    DisplayLabel.Text = "Erro: Divis�o por zero"; // Exibir erro
                    return; // Para a execu��o do m�todo, j� que ocorreu um erro
                }
                break;
            default:
                DisplayLabel.Text = "Erro: Opera��o desconhecida"; // Caso a opera��o seja desconhecida
                return; // Para a execu��o do m�todo, j� que ocorreu um erro
        }

        // Limita o n�mero de caracteres a 12 e converte o valor para string
        string result = _currentValue.ToString();

        // Verifica se o n�mero tem mais de 12 caracteres
        if (result.Length > 12)
        {
            result = result.Substring(0, 12); // Limita o valor a 12 caracteres
        }

        DisplayLabel.Text = result; // Exibe o valor final no display
    }
}
