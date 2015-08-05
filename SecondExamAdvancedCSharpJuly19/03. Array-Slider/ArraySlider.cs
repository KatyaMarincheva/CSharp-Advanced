namespace _03.Array_Slider
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text.RegularExpressions;

    class ArraySlider
    {
        static void Main()
        {
            long currentIIndex = 0;
            const string SplitPattern = @"\s+";
            Regex splitter = new Regex(SplitPattern);

            string[] inputStringNumbers = splitter.Split(Console.ReadLine()).Where(s => s != string.Empty).ToArray();
            BigInteger[] numberArray = inputStringNumbers.Select(BigInteger.Parse).ToArray();
            long arrayLength = numberArray.Length;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }

                string[] commandArgs = splitter.Split(command).Where(s => s != string.Empty).ToArray();

                long operationIndex = CalculateOperationIndex(commandArgs, currentIIndex, arrayLength);

                ExecuteCommand(commandArgs, numberArray, operationIndex);

                currentIIndex = operationIndex;

            }

            string output = string.Format("[{0}]", string.Join(", ", numberArray));
            Console.WriteLine(output);
        }

        private static long CalculateOperationIndex(string[] commandArgs, long currentIIndex, long arrayLength)
        {
            long offsetInput = long.Parse(commandArgs[0]);
            long operationIndex = (currentIIndex + offsetInput)%arrayLength;

            if (operationIndex < 0)
            {
                operationIndex = arrayLength + operationIndex;
            }
            return operationIndex;
        }

        private static void ExecuteCommand(string[] commandArgs, BigInteger[] collection, long operationIndex)
        {
            string operation = commandArgs[1];
            BigInteger operand = long.Parse(commandArgs[2]);

            switch (operation)
            {
                case "&":
                    collection[operationIndex] &= operand;
                    break;
                case "|":
                    collection[operationIndex] |= operand;
                    break;
                case "^":
                    collection[operationIndex] ^= operand;
                    break;
                case "+":
                    collection[operationIndex] += operand;
                    break;
                case "-":
                    BigInteger subtractionResult = collection[operationIndex] - operand;
                    collection[operationIndex] = (subtractionResult > 0) ? subtractionResult : 0;
                    break;
                case "*":
                    collection[operationIndex] *= operand;
                    break;
                case "/":
                    collection[operationIndex] /= operand;
                    break;
            }
        }
    }
}