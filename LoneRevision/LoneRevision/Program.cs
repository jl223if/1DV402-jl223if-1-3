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
            do
            {                          
                do
                {
                    Console.WriteLine(); 
                    numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                    Console.WriteLine();       
                } while (numberOfSalaries < 2 );
             
            //Bearbaetar lönerna
           processSalaries(numberOfSalaries);

           //Kollar ifall man vill skriva in mer löner
           Console.BackgroundColor = ConsoleColor.DarkGreen;
           Console.WriteLine(); 
           Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar.");
           Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void processSalaries(int count)
        {
            int[] Salaries = new int[count];
            for (int i = 0; i < count; i++)
            {
                Salaries[i] = ReadInt("Ange lön nummer " + (i + 1) + ":");
                Console.WriteLine(); 
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
           
            int read = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write(prompt);
                //fångar argument
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
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inget bra värde");
                    Console.ResetColor();
                }


            } 
            return read;
        }

    }
}
