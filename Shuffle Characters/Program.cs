using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string example = ShuffleChars("My name is Makar", 7);
            Console.WriteLine(example);
        }

        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("Source string is null.");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("source is white space");
            }

            if (count < 0)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentException(nameof(count));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            int numOfIterations = 0;
            var resChars = source.ToCharArray();  //12345678
            var sourceChars = new char[source.Length];
            do
            {
                var temp = sourceChars;
                sourceChars = resChars;
                resChars = temp;
                int indexEven = 0;
                int indexOdd = (source.Length + 1) / 2;
                for (int j = 0; j < source.Length; j++)
                {
                    if (j % 2 == 0)
                    {     //135792468
                        resChars[indexEven++] = sourceChars[j];
                    }
                    else
                    {
                        resChars[indexOdd++] = sourceChars[j];
                    }
                }

                numOfIterations++;
            }

            while (new string(resChars) != source && numOfIterations != count);

            if (numOfIterations == count)
            {
                return new string(resChars);
            }

            int modCount = count;
            while (modCount > numOfIterations)
            {
                modCount -= numOfIterations;
            }

            for (int i = 1; i <= modCount; i++)
            {
                var temp = sourceChars;
                sourceChars = resChars;
                resChars = temp;
                int indexEven = 0;
                int indexOdd = (source.Length + 1) / 2;
                for (int j = 0; j < source.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        resChars[indexEven++] = sourceChars[j];
                    }
                    else
                    {
                        resChars[indexOdd++] = sourceChars[j];
                    }
                }
            }

            return new string(resChars);
        }
    }
}
