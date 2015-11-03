namespace _02.ProcessorScheduling
{
    using System;
    using System.Linq;

    class ProcessorScheduling
    {
        static void Main(string[] args)
        {
            var tasks = new[]
            {
                new {Index = 1, Value = 5, Deadtime = 3},
                new {Index = 2, Value = 6, Deadtime = 4},
                new {Index = 3, Value = 2, Deadtime = 1},
                new {Index = 4, Value = 3, Deadtime = 4},
                new {Index = 5, Value = 8, Deadtime = 2},
                new {Index = 6, Value = 4, Deadtime = 3},
            };

            //var sortedTasks = tasks
            //    .OrderBy(task => task.Deadtime)
            //    .ThenByDescending(task => task.Value);

            var sorted = tasks
                .OrderByDescending(task => task.Value);

            int turns = 1;
            foreach (var task in sorted)
            {
                if (task.Deadtime >= turns)
                {
                    Console.Write(task.Index + " ");
                    turns++;
                }
            }
        } 
    }
}
