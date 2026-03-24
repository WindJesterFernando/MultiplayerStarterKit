using System;

static public class Utilities
{
    public const string Delineator = ",";

    static public string Concatenate(int signal, params string[] parameters)
    {
        string concatenatedString = signal.ToString();

        foreach (string p in parameters)
        {
            concatenatedString = concatenatedString + Delineator + p;
        }

        return concatenatedString;
    }

}

