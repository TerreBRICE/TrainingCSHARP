namespace GestionContacts.Console.Helpers;

public class TextConsoleGenerator
{

    private void InvalidValue(string value)
    {
        System.Console.WriteLine("You entered an invalid " + value);
    }

    public string AskStringValue(string question)
    {
        System.Console.WriteLine(question + " :");
        var output = System.Console.ReadLine();
        if (string.IsNullOrEmpty(output))
        {
            InvalidValue(question);
            System.Console.Write(question + " :");
            output = System.Console.ReadLine();
        }

        return output;
    }

    public int AskIntValue(string question)
    {
        System.Console.WriteLine(question + " :");
        int output;
        while (!int.TryParse(System.Console.ReadLine(), out output))
        {
            InvalidValue(question);
            System.Console.Write(question + " :");
        }

        return output;
    }
}