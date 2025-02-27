using UnityEngine;

public enum StringFormatType { BASIC, MULTIPLIER, DISTANCE, PERCENT, TIME };

public class StringFormating : MonoBehaviour
{
    private static string[] _thousandSymbols = { "", "K", "M", "B", "T", "q", "Q", "s", "S", "o", "n", "d", "u", "D" };

    public static string Format(float value, StringFormatType formatType, int decimalPlaces, bool noSymbols = false)
    {
        switch (formatType)
        {
            case StringFormatType.MULTIPLIER:
                return FormatMultiplier(value, decimalPlaces);
            case StringFormatType.DISTANCE:
                return FormatDistance(value, decimalPlaces);
            case StringFormatType.PERCENT:
                return FormatPercent(value, decimalPlaces);
            case StringFormatType.TIME:
                return FormatTime(value, decimalPlaces);
            default:
                if (noSymbols) return FormatBasicNoSymbols(value, decimalPlaces);
                return FormatBasic(value, decimalPlaces);
        }
    }

    private static string FormatTime(float value, int decimalPlaces)
    {
        switch (decimalPlaces)
        {
            case 0:
                return value.ToString("N0") + "s";
            case 1:
                return value.ToString("N1") + "s";
            case 2:
                return value.ToString("N2") + "s";
            case 3:
                return value.ToString("N3") + "s";
            case 4:
                return value.ToString("N4") + "s";
            case 5:
                return value.ToString("N5") + "s";
            default:
                return value.ToString("N0") + "s";
        }
    }

    private static string FormatMultiplier(float value, int decimalPlaces)
    {
        switch (decimalPlaces)
        {
            case 0:
                return "x" + value.ToString("N0");
            case 1:
                return "x" + value.ToString("N1");
            case 2:
                return "x" + value.ToString("N2");
            case 3:
                return "x" + value.ToString("N3");
            case 4:
                return "x" + value.ToString("N4");
            case 5:
                return "x" + value.ToString("N5");
            default:
                return "x" + value.ToString("N0");
        }
    }

    private static string FormatDistance(float value, int decimalPlaces)
    {
        switch (decimalPlaces)
        {
            case 0:
                return value.ToString("N0") + "m";
            case 1:
                return value.ToString("N1") + "m";
            case 2:
                return value.ToString("N2") + "m";
            case 3:
                return value.ToString("N3") + "m";
            case 4:
                return value.ToString("N4") + "m";
            case 5:
                return value.ToString("N5") + "m";
            default:
                return value.ToString("N0") + "m";
        }
    }

    private static string FormatPercent( float value, int  decimalPlaces )
    {
        switch (decimalPlaces ) { 
            case 0: 
                return value.ToString("P0");
            case 1: 
                return value.ToString("P1");
            case 2:
                return value.ToString("P2");
            case 3:
                return value.ToString("P3");
            case 4:
                return value.ToString("P4");
            case 5:
                return value.ToString("P5");
            default:
                return value.ToString("P0");
        }
    }

    private static string FormatBasic(float value, int decimalPlaces)
    {
        int counter = 0;

        while (value > 999)
        {
            value /= 1000;
            counter++;
        }

        switch (decimalPlaces)
        {
            case 0:
                return value.ToString("N0") + _thousandSymbols[counter];
            case 1:
                return value.ToString("N1") + _thousandSymbols[counter];
            case 2:
                return value.ToString("N2") + _thousandSymbols[counter];
            case 3:
                return value.ToString("N3") + _thousandSymbols[counter];
            case 4:
                return value.ToString("N4") + _thousandSymbols[counter];
            case 5:
                return value.ToString("N5") + _thousandSymbols[counter];
            default:
                return value.ToString("N0") + _thousandSymbols[counter];
        }
    }

    private static string FormatBasicNoSymbols(float value, int decimalPlaces)
    {
        switch (decimalPlaces)
        {
            case 0:
                return value.ToString("N0");
            case 1:
                return value.ToString("N1");
            case 2:
                return value.ToString("N2");
            case 3:
                return value.ToString("N3");
            case 4:
                return value.ToString("N4");
            case 5:
                return value.ToString("N5");
            default:
                return value.ToString("N0");
        }
    }
}
