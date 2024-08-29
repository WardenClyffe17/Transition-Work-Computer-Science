using System.Diagnostics.Tracing;
using Transition_Work_Computer_Science;

Console.WriteLine(HangmanAssets.Logo);

Random number = new Random();
int rnumber = number.Next(0,4319);

string filePath = "C:\\Users\\wande\\source\\repos\\Transition Work Computer Science\\Transition Work Computer Science\\english_words.csv";

List<string> words = new List<string>();

using (StreamReader sr = new StreamReader(filePath))
    {
    string line;
    while ((line = sr.ReadLine()) != null)
        {
        string[] fields = line.Split(',');

        foreach (var field in fields)
            {
                words.Add(field.Trim());
            }
        }
    }

string chosenword = words[rnumber];

string placeholder = string.Empty;

for (int i = 0; i < chosenword.Length; i++)
    placeholder += "_";

Console.WriteLine(placeholder);
List<char> CorrectLetters = new List<char>();
int lives = 6;

bool gameover = false;

while (!gameover) 
{
    Console.WriteLine("Guess a letter: ");
    string input = Console.ReadLine();
    char userinput = Convert.ToChar(input);

    string display = string.Empty;

    for (int i = 0; i < chosenword.Length; i++)
        if (userinput == chosenword[i])
        {
            display += userinput;
            CorrectLetters.Add(userinput);
        }
        else if (CorrectLetters.Contains(chosenword[i]))
        {
            display += chosenword[i];
        }
        else
        {
            display += "_";
        }

    Console.WriteLine(display);

    if (!chosenword.Contains(userinput))
        {
        lives--;
        }


    if (!display.Contains("_"))
    {
        gameover = true;
        Console.WriteLine("You Win!");
    }
    else if (lives == 0) 
    {
        gameover = true;
        Console.WriteLine(chosenword);
        Console.WriteLine("You Lose!");
    }

    Console.WriteLine(HangmanAssets.Stages[lives]);
}

Console.ReadKey();