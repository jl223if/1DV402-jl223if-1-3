using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variabler
            int numberOfSalaries;


            //inläsning av löner     
             
                //Console.BackgroundColor = ConsoleColor.Green;
                //Console.WriteLine("Tryck på en tangent för att fortsätta!");
                //Console.ResetColor();
                //if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                //{
                    
                //}

                do
                {
                    numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                    if (numberOfSalaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst 2 värden för att kunna göra en beräkning!");
                        Console.ResetColor();
                    }                  
                } while (numberOfSalaries < 2 );         


            //Bearbaetar lönerna
           processSalaries(numberOfSalaries);
        }

        private static void processSalaries(int count)
        {
            int[] Salaries = new int[count];
            for (int i = 0; i < count; i++)
            {
                Salaries[i] = ReadInt("Ange lön nummer " + (i + 1) + ":");
            }
            Array.Sort(Salaries);

            //beräknar medianen
            int medianSalary;
            int median = (count / 2) + (count % 2);

            if (count % 2 == 0)
            {
                medianSalary = (Salaries[median - 1] + Salaries[median]) / 2;
            }
            else
            {
                medianSalary = Salaries[median - 1];
            }

            //Beräknar medelvärdet
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += Salaries[i];
            }
            int average = sum / count;

            //Lönespridning
            int wagedifference = Salaries.Max() - Salaries.Min();

            //Presentation
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Medianlön:     {0, 20:c0}", medianSalary);
            Console.WriteLine("medellön:      {0, 20:c0}", average);
            Console.WriteLine("löneskillnad:  {0, 20:c0}", wagedifference);
            Console.WriteLine("-----------------------------------------");

            for (int i = 0; i < count; i++)
            {
                
                Console.Write("   ");
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0,10}", Salaries[i]);
                
            }
            Console.WriteLine();
        }

        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int read = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {  
                    read = int.Parse(Console.ReadLine());
                    valid = true;
                    if (read < 2)
                    {
                        valid = false;
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två värden för att göra en beräkning! \n");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar.");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.WriteLine("Inget bra värde");
                } 
            } 
            return read;
        }

    }
}