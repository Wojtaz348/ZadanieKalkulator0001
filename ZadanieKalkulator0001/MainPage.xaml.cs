using Microsoft.Maui.Controls;

namespace ZadanieKalkulator0001;

public partial class MainPage : ContentPage
{
    string currentInput = string.Empty;
    string operation = string.Empty;
    double result = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    void OnDigitButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        currentInput += button.Text;
        UpdateDisplay();
    }

    void OnOperatorButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        operation = button.Text;
        double.TryParse(currentInput, out result);
        currentInput = string.Empty;
    }

    void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        double input = 0;
        double.TryParse(currentInput, out input);

        switch (operation)
        {
            case "+":
                result += input;
                break;
            case "-":
                result -= input;
                break;
            case "*":
                result *= input;
                break;
            case "/":
                if (input != 0)
                    result /= input;
                else
                    DisplayAlert("Error", "Cannot divide by zero", "OK");
                break;
        }

        currentInput = result.ToString();
        UpdateDisplay();
    }

    void OnClearButtonClicked(object sender, EventArgs e)
    {
        currentInput = string.Empty;
        operation = string.Empty;
        result = 0;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayLabel.Text = currentInput;
    }
}
