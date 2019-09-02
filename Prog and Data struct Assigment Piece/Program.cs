using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assigment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            string userText;
            int choice;
            int sentences = 0;
            int vowels = 0;
            int consonants = 0;
            int upperCase = 0;
            int lowerCase = 0;
            int[] frequency = new int[(int)char.MaxValue];
            int numbers = 0;
            


            Console.WriteLine("Please choose an option:");
			Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Before chosing option 2 please change input file location in the script under Enter File Location \nto where it is on your computer ie the test.txt file and for the output file just change \nwhere you want it on your computer and name it and make sure to include.txt after the name. e.g. bla.txt .");
            Console.ResetColor();
            Console.WriteLine("1. Do you want to enter the text via the keyboard? ");
            Console.WriteLine("2. Do you want to read in the text from a file?  ");
			
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter the text you want analysed.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("note that the . is read as the end of a sentance by this program");
                    Console.ResetColor();
                    userText = Console.ReadLine();

                    foreach (char myChar in userText)
                    {
                        if (myChar == ' ')
                            continue;

                        switch (myChar)
                        {
                            case '.':
                                sentences++;
                                break;

                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                            case 'A':
                            case 'E':
                            case 'I':
                            case 'O':
                            case 'U':
                                vowels++;
                                break;

                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                numbers++;
                                break;

                            default:                                
                                consonants++;                               
                                break;
                        }

                        upperCase = userText.Count(c => char.IsUpper(c));
                        lowerCase = userText.Count(c => char.IsLower(c));


                    }
                    Console.WriteLine("\nNumber of sentences entered = {0}", sentences);
                    Console.WriteLine("Number of vowels = {0}", vowels);
                    Console.WriteLine("Number of consonants  = {0}", consonants);
                    Console.WriteLine("Number of upper case letters  = {0}", upperCase);
                    Console.WriteLine("Number of lower case letters  = {0}", lowerCase);
                    Console.WriteLine("The amout of numbers  = {0}", numbers);
                    foreach (char myChar2 in userText)
                    {

                        frequency[(int)myChar2]++;
                    }


                    for (int i = 0; i < (int)char.MaxValue; i++)
                    {
                        if (frequency[i] > 0 &&
                        char.IsLetterOrDigit((char)i))
                        {
                            Console.WriteLine("Letter: {0}  Frequency: {1}",
                                (char)i,
                                frequency[i]);
                        }
                    }
                    break;

                case 2:
                    //Please Enter File Loaction here
                    string filename = @"C:\Users\oskar sobon\Desktop\Games, etc\Uni Work\Prog and Data Structure\Part B\Assigment Piece\test.txt";
                    string outfilename = @"C:\Users\oskar sobon\Desktop\Games, etc\Uni Work\Prog and Data Structure\Part B\Assigment Piece\long words.txt";

                    file = File.ReadAllText(filename);
                    foreach (char myChar in file)
                    {

                        if (myChar == ' ')
                        {
                            continue;
                        }

                        switch (myChar)
                        {
                            case '.':
                                sentences++;
                                break;

                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                            case 'A':
                            case 'E':
                            case 'I':
                            case 'O':
                            case 'U':
                                vowels++;
                                break;

                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                numbers++;
                                break;

                            default:
                                    consonants++;                           
                                break;
                        }

                        upperCase = file.Count(c => char.IsUpper(c));
                        lowerCase = file.Count(c => char.IsLower(c));




                    }

                    Console.WriteLine("\nNumber of sentences entered = {0}", sentences);
                    Console.WriteLine("Number of vowels = {0}", vowels);
                    Console.WriteLine("Number of consonants  = {0}", consonants);
                    Console.WriteLine("Number of upper case letters  = {0}", upperCase);
                    Console.WriteLine("Number of lower case letters  = {0}", lowerCase);
                    Console.WriteLine("The amout of numbers  = {0}", numbers);
                    foreach (char myChar2 in file)
                    {

                        frequency[(int)myChar2]++;
                    }


                    for (int i = 0; i < (int)char.MaxValue; i++)
                    {
                        if (frequency[i] > 0 &&
                        char.IsLetterOrDigit((char)i))
                        {
                            Console.WriteLine("Letter: {0}  Frequency: {1}",
                                (char)i,
                                frequency[i]);
                        }
                    }
                    file = file.Replace("\r\n", " ");
                    file = file.Replace(".", "");
                    string[] words = file.Split(' ');        
                    string[] filteredWords = words.Where(w => w.Length >= 7).ToArray();
                    File.WriteAllLines(outfilename, filteredWords);
                    

                    break;

                default:
                    Console.WriteLine("Please enter either 1 or 2");
                    break;
            }




        }
    }
}
