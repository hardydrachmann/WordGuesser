using System;

public class WordGuesser
{

    private WordLogic logic = new WordLogic("Pave");
    public WordGuesser()
    {
        Console.WriteLine("WordGuesser game started");
        logic.evaluateLetter('a');
    }

    public void Start()
    {

    }
}
