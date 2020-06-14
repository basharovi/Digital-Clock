using System.IO;

namespace DigitalClock.WPF.Manager
{
    public class ScheduleManager
    {
        readonly string _path = Directory.GetCurrentDirectory() + "/DB";

        public string GetPrayerTime(string prayerName)
        {
            var filePath = _path + $"/{prayerName}.txt";

            var previousTime = File.ReadAllText(filePath);

            return previousTime;
        }

        public void WriteIntoTxtFile(string time, string prayerName)
        {
            var filePath = _path + $"/{prayerName}.txt";

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(time);
            }
        }
    }
}
