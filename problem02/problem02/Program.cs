using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace problem02
{
    class Program
    {
        public static int house = 0;
        static bool compareArray(char[] arr1, char[] arr2)
        {
            for(int i = 0; i<arr1.Length; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    //arrays are different
                    return false;
                }
            }
            //arrays are same
            return true;
        }

        static int computeHouse(char[] arr)
        {
            char north = '^';
            char south = 'v';
            char east = '>';
            char west = '<';

            for(int i=0; i<arr.Length; i++)
            {

                if (arr[i] == east)
                {
                    house = house + 1;
                  //  Console.Write("Go east \n ");
                }
                else if (arr[i] == north)
                {
                    house = house + 1;
                  //  Console.Write("Go north \n ");
                }
                else if (arr[i] == south)
                {
                    house = house + 1;
                  //  Console.Write("Go south \n ");
                }
                else if (arr[i] == west)
                {
                    house = house + 1;
                  //  Console.Write("Go west \n ");
                }
            }
            return house;
        }

        static bool isEmptyArray(char[] arr)
        {
            bool empty = true;
            for (int i = 0; i < 2; i++)
            {
                char c = arr[i];
                if(c == '^' || c== '<' || c == '>' || c== 'v')
                {
                    empty = false;
                }
            }
            return empty;
        }


        static int countUniqueDirection(char[] arr)
        {
            int count = 1;
            char[] uniqueDirectionArray = new char[8];
             int k = 1;
            uniqueDirectionArray[0] = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                int found = 0;
                for (int j = 0; j < uniqueDirectionArray.Length; j++)
                {
                    if (arr[i] == uniqueDirectionArray[j] )
                    {
                        // Console.Write("Duplicate found");
                        found = found +1 ;
                        break;
                    }
                }

                if (found == 0)
                {
                    uniqueDirectionArray[k] = arr[i];
                    count = count + 1;
                    k = k + 1;
                }
            }

           // Console.Write("Count : " + count);
            return count;
        }
        static void Main(string[] args)
        {
            // read 8 chars at a time
            int size = 8; 
            try
            {

                //test file
                //StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem02\\problem02\\sample.txt");

                //Pass the file path and file name to the StreamReader constructor
                StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem02\\problem02\\question02_input.txt");

                //start from the 1st char
                int count = 0;

                //Continue to read until end of file is found
                while (!input.EndOfStream)
                {
                    //read 8 characters from the text file using ReadBlock()
                    char[] charArray = new char[size];
                    input.ReadBlock(charArray, 0, charArray.Length);

                    // count no of unique direction
                    int uniqueDirection = countUniqueDirection(charArray);

                    // if the char array has just one unique character then it just move to one unique house
                    if (uniqueDirection == 1)
                    {
                        house = house + 1;
                    }
                    // if the char array has two unique characters then it moves two houses; other directions are repetative 
                    else if(uniqueDirection == 2)
                    {
                        house = house + 2;
                    }
                    // if  the char array has more than two direction then need to count houses for all of them 
                    else if (uniqueDirection > 2)
                    {
                        //split the char array into two arrays

                        char[] firstArray = new char[4];
                        Array.Copy(charArray, 0, firstArray, 0, firstArray.Length);

                        char[] secondArray = new char[4];
                        Array.Copy(charArray, 4, secondArray, 0, secondArray.Length);

                        bool isSameArray = compareArray(firstArray, secondArray);
                        
                        //if 1st 4 directions are same as 2nd 4 directions that means it came to the starting point again. 
                        // so only need to count the first arry and no need to count the secondArray
                        if (isSameArray)
                        {
                           // Console.Write("Came back to the starting point. So no need to count the secondArray");
                            house = computeHouse(firstArray);
                        }
                        else
                        {
                            //firstArray and SecondArray are different.
                            for (int i = 0; i < charArray.Length; i += 4)
                            {
                                //split it into thirdArray of char 2 to check it is similar or not
                                char[] thirdArray = new char[2];

                                Array.Copy(charArray, i, thirdArray, 0, thirdArray.Length);

                                char[] fourthArray = new char[2];
                                Array.Copy(charArray, i + 2, fourthArray, 0, fourthArray.Length);
                              
                                isSameArray = compareArray(thirdArray, fourthArray);

                                if (isSameArray)
                                {
                                    house = computeHouse(thirdArray);
                                }
                                else
                                {
                                    // thirdArray and fourthArray are not same; then check any of them are empty or not
                                    bool isThirdArrayEmpty = isEmptyArray(thirdArray);
                                   
                                    if (!isThirdArrayEmpty)
                                    {
                                        house = computeHouse(thirdArray);
                                    }

                                    bool isFourthArrayEmpty = isEmptyArray(fourthArray);
                                    if (!isFourthArrayEmpty)
                                    {
                                        house = computeHouse(thirdArray);
                                    }
                                }
                               
                            }

                        }
                    }

                    count = count + 4;

                }


                //close the file
                input.Close();

                Console.Write("Number of houses visited at least once : " + house);
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
