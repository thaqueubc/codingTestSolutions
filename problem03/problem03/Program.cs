using System;
using System.IO;

namespace problem03
{
    class Program
    {
        static bool count_vowel(char[] letter_array)
        {
            int array_length = letter_array.Length;
           
            int vowel = 0;

            bool totalVowel = false;

            for (int i=0; i<array_length; i++)
            {
                if(letter_array[i] == 'a' || letter_array[i] == 'e' || letter_array[i] == 'i' || letter_array[i] == 'o' || letter_array[i] == 'u')
                {
                    vowel = vowel + 1;
                }
            }
    
            if(vowel >= 3)
            {
                totalVowel = true;
            }

            return totalVowel;
        }

        static bool check_double(char[] letter_array)
        {
            bool isDoubleFound = false;
            int array_length = letter_array.Length;

            for (int i = 0; i < array_length-1; i++)
            {
                if (letter_array[i] == letter_array[i+1] )
                {
                    isDoubleFound = true;
                }
            }

            return isDoubleFound;
        }

        static bool check_disallowed_letter(char[] letter_array)
        {
            int array_length = letter_array.Length;
            bool isDisallowedFound = false;

            for (int i = 0; i < array_length - 1; i++)
            {
                int letter1 = Convert.ToInt32(letter_array[i]);
                int letter2 = Convert.ToInt32(letter_array[i+1]);

                if (letter2 - letter1 == 1)
                {
                    isDisallowedFound = true;
                }
            }

            return isDisallowedFound;
        }
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            int good_string = 0;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
               //StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem03\\problem03\\sample.txt");
               StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem03\\problem03\\question03_input.txt");

                while ((line = input.ReadLine()) != null)
                {
                    char[] letter_array = line.ToCharArray();
                    Console.Write("\n Line : " + line );

                    bool totalVowel = count_vowel(letter_array);
                    //Console.WriteLine(totalVowel + "\n");

                    bool isDoubleFound = check_double(letter_array);
                    //Console.Write(isDoubleFound);

                    bool isDisallowedFound = check_disallowed_letter(letter_array);
                    //Console.Write(isDisallowedFound);

                    if(totalVowel && isDoubleFound && !isDisallowedFound)
                    {
                        Console.Write("\n string is good");
                        good_string = good_string + 1;
                    }
                    else
                    {
                        Console.Write("\n string is bad");
                        if (!totalVowel)
                        {
                            Console.Write("\n Vowel is less than 3 \n");
                        }
                           
                        if (!isDoubleFound)
                        {
                            Console.Write("\n Double letter is not found\n");
                        }

                        if (isDoubleFound)
                        {
                            Console.Write("\n Disallowed letter is found\n");
                        }
                    }
                    counter++;
                }
                Console.Write("\n Total Good Strings are : " + good_string);
                //close the file
                input.Close();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
    }
}
