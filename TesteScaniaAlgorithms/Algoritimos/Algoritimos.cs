using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteScaniaAlgorithms.Algoritimos
{
    public class Algoritimos
    {
        // Fibonacci recursivo
        public int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        // Retorna a soma dos números no intervalo de 'min' até 'range'
        public int SumNumbers(int min, int range)
        {
            Console.WriteLine($"Soma de números de {min} à {range}");
            var sum = 0;
            for (int i = min; i <= range; i++)
            {
                sum += i;
            }
            return sum;
        }
        // Mostra os números múltiplos de 'referencialNumber' dentro do intervalo de 0 até 'range'
        public void ShowMultipleNumbersOf(int referencialNumber, int range)
        {
            Console.WriteLine("Números múltiplos  de " + referencialNumber);
            for (int i = 1; i <= range; i++)
            {
                if (i % referencialNumber == 0)
                    Console.WriteLine(i);
            }
        }
    }
}
