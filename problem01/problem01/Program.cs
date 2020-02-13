using System;
using System.IO;

namespace problem01
{
    class Program
    {

        public static void checkResult(int test_no, int result, int expected)
        {
            if (result == expected)
            {
                Console.Write("Test " + test_no + " passed \n");
            }
            else
            {
                Console.Write("Test " + test_no + " failed \n");
            }
        }
        public static int countFloor(StreamReader input)
        {

            char ch;
            char open_paenthesis = '(';
            int floor = 0;

            //Continue to read until you reach end of file
            while (!input.EndOfStream)
            {
                ch = (char)input.Read();

                if (ch == open_paenthesis)
                {
                    floor = floor + 1;
                  //  Console.Write("Go up \n ");
                }
                else
                {
                    floor = floor - 1;
                  //  Console.Write("Go down \n ");
                }
            }

            return floor;
        }
        static void Main(string[] args)
        {
            try
            { 
                //Pass the file path and file name to the StreamReader constructor
                StreamReader input = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\question01_input.txt");

                //test files
                StreamReader test_file1 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test1.txt");
                StreamReader test_file2 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test2.txt");
                StreamReader test_file3 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test3.txt");
                StreamReader test_file4 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test4.txt");
                StreamReader test_file5 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test5.txt");
                StreamReader test_file6 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test6.txt");
                StreamReader test_file7 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test7.txt");
                StreamReader test_file8 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test8.txt");
                StreamReader test_file9 = new StreamReader("C:\\Users\\reyar\\Desktop\\Clevest Solution\\problem01\\problem01\\test9.txt");

                //call countFloor function with the input file to compute the final destination floor
                int final_floor = countFloor(input);

                int result_test1 = countFloor(test_file1);
                int result_test2 = countFloor(test_file2);
                int expected_test1_test2 = 0;

                checkResult(1, result_test1, expected_test1_test2);
                checkResult(2, result_test2, expected_test1_test2);

                int result_test3 = countFloor(test_file3);
                int result_test4 = countFloor(test_file4);
                int result_test5 = countFloor(test_file5);
                int expected_test3_test4_test5 = 3;

                checkResult(3, result_test3, expected_test3_test4_test5);
                checkResult(4, result_test4, expected_test3_test4_test5);
                checkResult(5, result_test5, expected_test3_test4_test5);


                int result_test6 = countFloor(test_file6);
                int result_test7 = countFloor(test_file7);
                int expected_test6_test7 = -1;

                checkResult(6, result_test6, expected_test6_test7);
                checkResult(7, result_test7, expected_test6_test7);

                int result_test8 = countFloor(test_file8);
                int result_test9 = countFloor(test_file9);
                int expected_test8_test9 = -3;

                checkResult(8, result_test8, expected_test8_test9);
                checkResult(9, result_test9, expected_test8_test9);

                //close the file
                input.Close();

                Console.Write("Final Destination floor is : " + final_floor);
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
