namespace _02.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProcessorScheduling
    {
        private static Task[] tasks;

        static void Main(string[] args)
        {
            GetInputData();
            var sorted = tasks.OrderByDescending(task => task.Value);
            var taskList = new List<Task>();
            foreach (var task in sorted)
            {
                if (ValidateTask(taskList, task))
                {
                    taskList.Add(task);
                }
            }

            Print(taskList);
        }

        private static void GetInputData()
        {
            int count = int.Parse(Console.ReadLine().Split(' ')[1]);
            tasks = new Task[count];
            for (int i = 1; i <= count; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(new[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                tasks[i - 1] = new Task {Index = i, Value = tokens[0], Deadline = tokens[1]};
            }
        }

        private static void Print(List<Task> taskList)
        {
            Console.WriteLine("Optimal schedule: " + string.Join(
                " -> ",
                taskList
                    .OrderBy(task => task.Deadline)
                    .ThenByDescending(task => task.Value)
                    .Select(s => s.Index)
                ));
            Console.WriteLine($"Total value: {taskList.Sum(task => task.Value)}");
        }

        static bool ValidateTask(List<Task> tasks, Task task)
       {
            var tempTasks = new List<Task> {task};
            tempTasks.AddRange(tasks);
            var tempTaskList = tempTasks.OrderBy(t => t.Deadline);
            int step = 1;
            foreach (var t in tempTaskList)
            {
                if (step > t.Deadline)
                {
                    return false;
                }

                step++;
            }

            return true;
        }
    }

    class Task
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public int Deadline { get; set; }
    }
}