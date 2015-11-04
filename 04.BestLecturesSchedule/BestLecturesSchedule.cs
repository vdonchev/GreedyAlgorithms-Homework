namespace _04.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BestLecturesSchedule
    {
        static void Main(string[] args)
        {
            var lectures = new Dictionary<string, Tuple<int, int>>();
            int count = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                lectures.Add(tokens[0], new Tuple<int, int>(int.Parse(tokens[1]), int.Parse(tokens[2])));
            }

            var sortedLectures = lectures.OrderBy(l => l.Value.Item2);
            int resCount = 0;
            int earliestFinish = 0;
            foreach (var lecture in sortedLectures)
            {
                if (lecture.Value.Item1 >= earliestFinish)
                {
                    resCount++;
                    earliestFinish = lecture.Value.Item2;
                }
                else
                {
                    lectures.Remove(lecture.Key);
                }
            }

            Console.WriteLine($"Lectures ({resCount}):");
            foreach (var lecture in lectures.OrderBy(l => l.Value.Item2))
            {
                Console.WriteLine($"{lecture.Value.Item1}-{lecture.Value.Item2} -> {lecture.Key}");
            }
        }
    }
}
