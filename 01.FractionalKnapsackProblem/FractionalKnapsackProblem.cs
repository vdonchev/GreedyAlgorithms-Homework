namespace _01.FractionalKnapsackProblem
{
    using System;
    using System.Linq;

    class FractionalKnapsackProblem
    {
        static void Main(string[] args)
        {
            Item[] items;
            var capacity = GetInputs(out items);

            var sortedItems = items.OrderByDescending(i => (i.Price / i.Weight));
            double capacityLeft = capacity;
            double totalPriceCollected = 0;
    
            foreach (var item in sortedItems)
            {
                if (item.Weight >= capacityLeft)
                {
                    double percentage = capacityLeft / item.Weight;
                    totalPriceCollected += item.Price * percentage;
                    Print(item.Price, item.Weight, percentage * 100);
                    break;
                }

                Print(item.Price, item.Weight, 100);
                capacityLeft -= item.Weight;
                totalPriceCollected += item.Price;
            }

            Console.WriteLine($"Total price: {$"{totalPriceCollected:F2}"}");
        }

        private static int GetInputs(out Item[] items)
        {
            int capacity = int.Parse(Console.ReadLine().Split(' ')[1]);
            int numItems = int.Parse(Console.ReadLine().Split(' ')[1]);
            items = new Item[numItems];
            for (int i = 0; i < items.Length; i++)
            {
                double[] values = Console.ReadLine()
                    .Split(new[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                items[i] = new Item(values[1], values[0]);
            }
            return capacity;
        }

        private static void Print(double price, double weigth, double part)
        {
            Console.WriteLine($"Take {$"{part:F2}"}% of item with price {$"{price:F2}"} and weight {$"{weigth:F2}"}");
        }
    }

    class Item
    {
        public double Weight { get; }

        public double Price { get; }

        public Item(double weight, double price)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
