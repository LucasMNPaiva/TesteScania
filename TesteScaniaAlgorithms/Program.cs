

using TesteScaniaAlgorithms.Algoritimos;

var algoritimos = new Algoritimos();

//Fibonacci
Console.WriteLine("Digite o Numero de Elementos para a Sequência de Fibonacci");
var numeroSequencia = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < numeroSequencia; i++)
{
    Console.WriteLine(algoritimos.Fibonacci(i));
}
//Soma de números
Console.WriteLine(algoritimos.SumNumbers(0, 100));
// Números múltiplos
algoritimos.ShowMultipleNumbersOf(7, 100);