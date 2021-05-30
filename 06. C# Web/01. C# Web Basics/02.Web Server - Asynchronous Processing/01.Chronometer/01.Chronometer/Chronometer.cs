using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    public class Chronometer : IChronometer
    {
        private List<string> laps;
        private Stopwatch sw;
        public Chronometer()
        {
            this.sw = new Stopwatch();
            this.laps = new List<string>();
        }
        public string GetTime => sw.Elapsed.ToString();

        public List<string> Laps => this.laps;


        public string Lap()
        {
            var currentLap = this.sw.Elapsed.ToString();
            this.laps.Add(currentLap);
            return currentLap;
        }

        public void Reset()
        {
            Stop();
            sw.Reset();
            this.laps.Clear();
        }

        public void Start()
        {
            this.sw.Start();
        }

        public void Stop()
        {
            this.sw.Stop();
        }
    }
}
