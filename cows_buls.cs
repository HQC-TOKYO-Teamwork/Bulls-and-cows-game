using System;
using System.Collections.Generic;
using System.Text;

// Tova e zadachata za kravite i bikovete ot kursa po KPK na Nakov ava FMI, mnogo e lesna, ama taka ne e interesna, ebasi?
public class cows_buls
{
    // // Move to guess command
    //private static void ProcessDigitCommand(string tryNumberString)
    //{
    //    if (tryNumberString.Length == 4)
    //    {
    //        count2++;
    //        if (isEqualToNumberForGuess(tryNumberString))
    //        {
    //            isGuessed = true;
    //            PrintCongratulationMessage();
    //        }
    //        else
    //        {
    //            PrintBullsAndCows(tryNumberString);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("You have entered invalid number!");
    //    }
    //}

    //private static void PrintBullsAndCows(string tryNumberString)
    //{
    //    int bullsCount = 0;
    //    int cowsCount = 0;
    //    CountBullsAndCows(
    //        tryNumberString, ref bullsCount, ref cowsCount);
    //    Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}!",
    //                      bullsCount, cowsCount);
    //}

    //private static void CountBullsAndCows(
    //    string tryNumberString, ref int bullsCount, ref int cowsCount)
    //{
    //    bool[] bulls = new bool[4];
    //    bool[] cows = new bool[10];



    //    bullsCount = CountBulls(tryNumberString, bullsCount, bulls);
    //    cowsCount = CountCows(tryNumberString, cowsCount, bulls, cows);
    //}

    //private static int CountCows(
    //    string tryNumberString, int cowsCount, bool[] bulls, bool[] cows)
    //{
    //    for (int i = 0; i < tryNumberString.Length; i++)
    //    {
    //        int digitForTry = int.Parse(tryNumberString[i].ToString());
    //        if (!bulls[i] && !cows[digitForTry])
    //        {
    //            cows[digitForTry] = true;
    //            cowsCount =
    //            CountCowsForCurrentDigit(
    //                tryNumberString, cowsCount, bulls, i);
    //        }
    //    }
    //    return cowsCount;
    //}
    //private static int CountBulls(
    //    string tryNumberString, int bullsCount, bool[] bulls)
    //{
    //    for (int i = 0; i < tryNumberString.Length; i++)
    //    {
    //        if (tryNumberString[i] == numberForGuessString[i])
    //        {
    //            bullsCount++;
    //            bulls[i] = true;
    //        }
    //    }
    //    return bullsCount;
    //}
    //private static int CountCowsForCurrentDigit(
    //    string tryNumberString, int cowsCount, bool[] bulls, int i)
    //{
    //    for (int j = 0; j < tryNumberString.Length; j++)
    //    {
    //        if (tryNumberString[i] == numberForGuessString[j])
    //        {
    //            if (!bulls[j])
    //            {
    //                cowsCount++;
    //            }
    //        }
    //    }
    //    return cowsCount;
    //}
    //private static void PrintCongratulationMessage()
    //{
    //    if (count1 == 0)
    //    {
    //        Console.WriteLine(
    //            "Congratulations! You guessed" +
    //            " the secret number in {0} attempts.",
    //            count2);
    //    }
    //    else
    //    {
    //        Console.WriteLine(
    //            "Congratulations! You guessed the" +
    //            " secret number in {0}" +
    //            " attempts and {1} cheats.",
    //            count2, count1);
    //    }
    //    Console.WriteLine();
    //}
    //private static bool isEqualToNumberForGuess(string tryNumber)
    //{
    //    bool isEqualToNumberForGuess =
    //    (tryNumber == numberForGuessString);
    //    return isEqualToNumberForGuess;
    //}

    //private static void RevealDigit()
    //{
    //    bool flag = false;
    //    int c = 0;
    //    while (!flag &&
    //           c != 2 * numberForGuessString.Length){
    //        int digitForReveal = randomGenerator.Next(0, 4);
    //        if (helpingNumber[digitForReveal] == 'X')
    //        {
    //            helpingNumber[digitForReveal] =
    //            numberForGuessString[digitForReveal];



    //            flag = true;
    //        }
    //        c++;
    //    }
    //    PrintHelpingNumber();
    //}

    //private static void PrintHelpingNumber()
    //{
    //    Console.Write("The number looks like ");
    //    foreach (char ch in helpingNumber) { Console.Write(ch); }
    //    Console.Write(".");
    //    Console.WriteLine();
    //}

    //private static void CreateNewGame()
    //{
    //    Play();
    //}

    //private static void AddPlayerToScoreboard(int guesses)
    //{
    //    if (count1 > 0)
    //    {
    //        Console.WriteLine(
    //            "You are not allowed to enter the top scoreboard.");
    //    }
    //    else
    //    {
    //        if (klasirane.Count < 5)
    //        {
    //            AddPlayer(guesses);
    //        }
    //        else if (klasirane[4].Guesses > guesses)
    //        {
    //            klasirane.RemoveAt(4);
    //            AddPlayer(guesses);
    //        }
    //    }
    //}

    //private static void AddPlayer(int guesses)
    //{
    //    Console.WriteLine("You can add your nickname to top scores!");
    //    string playerNick = String.Empty;
    //    while (playerNick == String.Empty)
    //        try
    //        {
    //            Console.Write("Enter your nickname: ");
    //            playerNick = Console.ReadLine();
    //            PlayerInfo newPlayer = new PlayerInfo(playerNick, guesses);
    //            klasirane.Add(newPlayer);
    //        }
    //        catch (ArgumentException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            continue;
    //        }
    //}

    //private static void PrintScoreboard()
    //{
    //    Console.WriteLine();
    //    if (klasirane.Count > 0)
    //    {
    //        Console.WriteLine("Scoreboard:");
    //        klasirane.Sort();
    //        int currentPosition = 1;
    //        Console.WriteLine("  {0,7} | {1}", "Guesses", "Name");
    //        PrintLine(40);
    //        foreach (var currentPlayerInfo in klasirane)
    //        {
    //            Console.WriteLine("{0}| {1}",
    //                              currentPosition, currentPlayerInfo);
    //            PrintLine(40);
    //            currentPosition++;
    //        }
    //        Console.WriteLine();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Scoreboard is empty!");
    //    }
    //}

    //private static void PrintLine(int dashesForPrint)
    //{
    //    for (int i = 0; i < dashesForPrint; i++)
    //    {
    //        Console.Write("-");
    //    }
    //    Console.WriteLine();
    //}
}