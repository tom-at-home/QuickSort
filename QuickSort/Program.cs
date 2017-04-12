using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public delegate string SmallerHandler(string input, char pivot);
    public delegate string BiggerHandler(string input, char pivot);
    public delegate string QuicksortHandler(string input);

    class Program
    {
        static SmallerHandler smaller;
        static BiggerHandler bigger;
        static QuicksortHandler quicksort;

        static void Main(string[] args)
        {
            /*
smaller(hallo, a) => smaller(allo, a)
smaller(allo, a) => a + smaller(llo, a)
smaller(llo, a) => smaller(lo, a)
smaller(lo, a) => smaller(o, a)
smaller(o, a) => smaller("", a)
smaller("", a) => ""

smaller(sdnfa, g) => smaller(dnfa, g)
smaller(dnfa, g) => d + smaller(nfa, g)
smaller(nfa, g) => smaller(fa, g)
smaller(fa, g) => f + smaller(a, g)
smaller(a, g) => a + smaller("", g)
smaller("", g) => "" 
*/
    
            smaller = (input,pivot) => input == "" ? "" : input[0] <= pivot ? input[0] + smaller(input.Substring(1), pivot): smaller(input.Substring(1), pivot);
            bigger = (input, pivot) => input == "" ? "" : input[0] > pivot ? input[0] + bigger(input.Substring(1), pivot) : bigger(input.Substring(1), pivot);
            quicksort = input => input == "" ? "" : quicksort(smaller(input.Substring(1), input[0])) + input[0] + quicksort(bigger(input.Substring(1), input[0]));
            Console.WriteLine(quicksort("2387920328625023984"));
            Console.ReadLine();

        }
    }
}
