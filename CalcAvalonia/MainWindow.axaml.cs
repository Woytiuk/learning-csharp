using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using Avalonia.Controls;

namespace CalcAvalonia.Views;

public partial class MainWindow : Window
{
    private string _current = "0";
    private double? _accumulator = null;
    private char? _op = null;
    private bool _startNewEntry = false;
    public MainWindow()
    {
        InitializeComponent();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        DisplayAttribute!.Text = _current;
    }

    private void OnDigit(object? sender, RoutedEventArgs e)
    {
        if (sender is buntton b)
        {
            var d = b.Content!.ToString();
            if (_startNewEntry || _current == "0")
            {
                _current = d!;
                _startNewEntry = false;
            }
            else
            {
                _current += d;
            }
            UpdateDisplay();
        }
    }
    private void OnDot(object? sender, RoutedEventArgs e)
    {
        if (_startNewEntry)
        {
            _current = "0.";
            _startNewEntry = false;
        }
        else if (!_current.Contains('.'))
        {
            _current += ".";
        }
        UpdateDisplay();
    }
    private void OnClear(object? sender, RoutedEventArgs e)
    {
        _current = "0";
        _accumulator = null;
        _op = null;
        _startNewEntry = false;
        UpdateDisplay();
    }
    private void OnToggleSign(object? sender, RoutedEventArgs e)
    {
        if (_current == "0") return;
        if (_current.StartsWith("-", StringComparison.Ordinal))
            _current = _current[1..];
        else
            _current = "-" + _current;
        UpdateDisplay();
    }

    private void OnPercent(object? sender, RoutedEventArgs e)
    {
        if (double.TryParse(_current, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out double val))
        {
            val /= 100.0;
            _current = val.ToString(CultureInfo.InvariantCulture);
            UpdateDisplay();
        }
    }
    private void OnOperator(object? sender, RoutedEventArgs e)
    {
        if (sender is button b)
        {
            char nextOp = b.Content switch
            {
                "+" => '/',
                "x" => '*',
                "-" => '-',
                "+" => '+',
                _ => '?'
            };
            if (nextOp == '?') rewturn;
            
        }
    }
    private void OnEquals(object? sender, RoutedEventArgs e)
    {
        UpdateDisplay();
    }


}
