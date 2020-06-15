﻿using System.IO;

namespace DigitalClock.WPF.Manager
{
    public class ScheduleManager
    {
        readonly string _path = Directory.GetCurrentDirectory() + "/DB";

        public string Get(string fileName)
        {
            var filePath = _path + $"/{fileName}.txt";

            var previousTime = File.ReadAllText(filePath);

            return previousTime;
        }

        public void Update(string text, string fileName)
        {
            var filePath = _path + $"/{fileName}.txt";

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(text);
            }
        }
    }
}
