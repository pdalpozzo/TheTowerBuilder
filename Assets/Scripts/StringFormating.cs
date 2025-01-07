using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StringFormatType { BASIC, MULTIPLIER, DISTANCE, PERCENT, TIME };

public class StringFormating : MonoBehaviour
{
    private static string[] _thousandSymbols = { "", "K", "M", "B", "T", "q", "Q", "s", "S", "o", "n", "d", "u", "D" };

    public static string Format(float value, StringFormatType formatType, int decimalPlaces)
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
            default:
                return value.ToString("N2") + "s";
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
            default:
                return "x" + value.ToString("N2");
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
            default:
                return value.ToString("N2") + "m";
        }
    }

    private static string FormatPercent( float value, int  decimalPlaces )
    {
        switch (decimalPlaces ) { 
            case 0: 
                return value.ToString("P0");
            case 1: 
                return value.ToString("P1");
            default :
                return value.ToString("P2");
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
            default:
                return value.ToString("N2") + _thousandSymbols[counter];
        }
    }
}
