///Zadanie 3 - stos obiektowo
///
///

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stos stos1 = new Stos();
            stos1.init();
            Stos stos2 = new Stos();
            stos2.init();

            Console.WriteLine("Wpisz 10 liczb całkowitych (każdą potwierdź enter'em):");

            ///Ten kod zapisuje 2 stosy na raz przez co stos1 jest nie naruszony jak wymaga tego zadanie
            ///proszę pisać jeśli nie o takie rozwiązanie chodziło, wtedy spróbuję jak najszybciej się poprawić :)
            for (int i = 0; i < 10; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                stos1.push(number);
                stos2.push(number);
            }

            Console.WriteLine("\nWpisane wartości w odwrotnej kolejności to:");

            while(!stos2.empty())
            {
                Console.WriteLine(stos2.top());
                stos2.pop();
            }
        }

        class Stos
        {
            const int resizeAmount = 8;

            int[] values;
            //int capacity;
            int count;

            public void pop()
            {
                if(count < 0)
                    Console.WriteLine("<Stos>.pop(): Stos jest już pusty!");
                else
                    count--;
            }
            public void push(int numberOnStack)
            {
                if(full())
                {
                    values[count++] = numberOnStack;
                }
                else
                {
                    Resize();
                    values[count++] = numberOnStack;
                }
            }
            public int top()
            {
                return values[count-1];
            }
            public bool empty()
            {
                return (count == 0);
            }
            public bool full()
            {
                return (count == values.Length);
            }
            public void init()
            {
                values = new int[16];
            }
            public void destroy()
            {
                ///Kompletnie nie wiem po co jest ta funkcja, nie ma tu nic do posprzątania a Garbage Collector zajmie się instancją obiektu
            }

            ///Poboczna metoda która sprawia że realizacja zadania jest "suchsza"
            void Resize()
            {
                int[] newValues = new int[values.Length + resizeAmount];
                int i = 0;
                foreach (int number in values)
                    newValues[i++] = number;
                values = newValues;
            }
        }
    }
}
