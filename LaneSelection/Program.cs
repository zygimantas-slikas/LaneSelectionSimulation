using System;

namespace LaneSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            int lanesCount, selectionStrategy, sequenceLenght, loadsCount;
            double failRate;
            Console.WriteLine("Lane selection simulation");
            lanesCount = GetLanesCount();
            selectionStrategy = GetSelectionStrategy();
            sequenceLenght = GetSequenceLenght();
            failRate = GetFailRate();
            loadsCount = GetLoadsCount();
            Conveyor conveyor1 = new Conveyor(lanesCount, selectionStrategy, sequenceLenght, failRate);
            //simulating loads
            for (int i = 0; i < loadsCount; i++)
            {
                conveyor1.AddLoad();
            }
            //results output
            Console.WriteLine(conveyor1.ToString());
        }
        static int GetLanesCount()
        {
            string input = "";
            int lanesCount;
            Console.WriteLine("Input lanes count: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out lanesCount) || lanesCount < 0)
            {
                Console.WriteLine("Wrong data, can't parse, try again.");
                input = Console.ReadLine();
            }
            return lanesCount;
        }
        static int GetSelectionStrategy()
        {
            string input = "";
            int selectionStrategy;
            Console.WriteLine("Input lanes selection strategy, 1 - Round Robin, 2 - Randon Select: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out selectionStrategy) || !(selectionStrategy == 1 || selectionStrategy == 2))
            {
                Console.WriteLine("Wrong data, can't parse, try again.");
                input = Console.ReadLine();
            }
            return selectionStrategy;
        }
        static int GetSequenceLenght()
        {
            string input = "";
            int sequenceLength;
            Console.WriteLine("Input loads sequence length: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out sequenceLength) || !(sequenceLength >= 1))
            {
                Console.WriteLine("Wrong data, can't parse, try again.");
                input = Console.ReadLine();
            }
            return sequenceLength;
        }
        static int GetLoadsCount()
        {
            string input = "";
            int loadsCount;
            Console.WriteLine("Input loads count: ");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out loadsCount) || (loadsCount < 0))
            {
                Console.WriteLine("Wrong data, can't parse, try again.");
                input = Console.ReadLine();
            }
            return loadsCount;
        }
        static double GetFailRate()
        {
            string input = "";
            double failRate;
            Console.WriteLine("Input percentage of failure for load to be diverted: ");
            input = Console.ReadLine();
            while (!Double.TryParse(input, out failRate) || (failRate < 0 || failRate > 100))
            {
                Console.WriteLine("Wrong data, can't parse, try again.");
                input = Console.ReadLine();
            }
            return failRate;
        }
    }
}
