using Nancy.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace problem04
{
    class Program
    {
        //  Declare a Dictionary to store all results using key-value pair
        static IDictionary<string, int> wordDictionary = new Dictionary<string, int>();
        
        static void addToDictionary(string key, int value)
        {
            wordDictionary.Add(new KeyValuePair<string, int>(key, value));

            foreach(KeyValuePair<string, int> ele in wordDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", ele.Key, ele.Value);
            }

            Console.Write("\n\n\n");
        }

        static int calculateResult(string[] operand, string op)
        {
            int x;
            int y;
            int result = 0;

            if (op == "AND")
            {
                x = wordDictionary[operand[0]];
                y = wordDictionary[operand[1]];
                result = x & y;
               // Console.Write("Result : " + result);
            }
            else if (op == "OR")
            {
                x = wordDictionary[operand[0]];
                y = wordDictionary[operand[1]];
                result = x | y;
               // Console.Write("Result : " + result);
            }
            else if (op == "RSHIFT")
            {
                x = wordDictionary[operand[0]];
                result = x >> 2;
              //  Console.Write("Result : " + result);
            }
            else if (op == "LSHIFT")
            {
                x = wordDictionary[operand[0]];
                result = x << 2;
               // Console.Write("Result : " + result);
            }
            else if (op == "NOT")
            {
                x = wordDictionary[operand[0]];
                result = ~ x ;
               // Console.Write("Result : " + result);
            }

            return result;
        }

        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            bool hasUpper = false;
            bool hasNumber = false;
            bool haslower = false;

            string[] operand = new string[4];
            string op = "";
            int result = 0;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem04\\problem04\\sample.txt");

                while ((line = input.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');

                    int j = 0;
                    foreach (string word in words)
                    {
                       
                       // take each word from words array and check whether it is an operand or operator or result
                        for (int i = 0; i < word.Length; i++)
                        {
                            char c = word[i];
                            if (!hasUpper || !hasNumber || !haslower)
                            {
                                hasUpper = char.IsUpper(c);
                                hasNumber = char.IsNumber(c);
                                haslower = char.IsLower(c);
                                break;
                            }

                        }

                        if (hasUpper)
                        {
                          //  if the word the all upeercase then it is a operator 
                            op = word;
                            //Console.Write("\n Operator : " + op);
                            hasUpper = false;
                        }
                        else if (hasNumber)
                        {
                            //if the word is a number then it is a result
                            result = int.Parse(word);
                            //Console.Write("\n Result : " + result);
                            hasNumber = false;
                        }
                        else if (haslower)
                        {
                            // if the word is all loweracase then it is an operand
                            if (words.Length == 3)
                            {
                                operand[0] = word;
                            }
                            else
                            {
                                operand[j] = word;
                            }

                            //Console.Write("\n Operand : " + operand[j]);
                            haslower = false;
                            j++;
                        }
                        else
                        {
                            operand[j] = word;
                            j++;
                        }

                        
                    }
                    if (words.Length == 3)
                    {
                         addToDictionary(operand[0], result);
                    }
                    else if (words.Length == 4 || op =="RSHIFT" || op=="LSHIFT")
                    {
                        int newResult = calculateResult(operand, op);
                        addToDictionary(operand[2], newResult);
                    }
                    else if(words.Length == 5)
                    {
                        int newResult = calculateResult(operand, op);
                        addToDictionary(operand[3], newResult);
                    }

                     counter++;
                }

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
