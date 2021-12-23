using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSelection
{
    abstract class ISelect
    {
        public int LanesCount { get; protected set; }
        public int SeriesLength { get; protected set; }
        public int CurrentLane { get; protected set; }
        public int SeriesCounter { get; protected set; }
        public ISelect(int lanesCount, int seriesLength)
        {
            LanesCount = lanesCount;
            SeriesLength = seriesLength;
            CurrentLane = 0;
            SeriesCounter = 0;
        }
        public abstract int GetLaneId();
    }
    class RoundRobin : ISelect
    {
        public RoundRobin(int lanesCount, int seriesLength) : base(lanesCount, seriesLength)
        {
        }
        public override int GetLaneId()
        {
            if (SeriesCounter <= 0)
            {
                SeriesCounter = SeriesLength - 1;
                CurrentLane = CurrentLane % LanesCount + 1;
            }
            else
            {
                SeriesCounter -= 1;
            }
            return CurrentLane;
        }
    }
    class RandomSelect : ISelect
    {
        private Random randomNumber;
        public RandomSelect(int lanesCount, int seriesLength) : base(lanesCount, seriesLength)
        {
            randomNumber = new Random();
        }
        public override int GetLaneId()
        {
            if (SeriesCounter <= 0)
            {
                SeriesCounter = SeriesLength - 1;
                CurrentLane = randomNumber.Next(1, LanesCount + 1);
            }
            else
            {
                SeriesCounter -= 1;
            }
            return CurrentLane;
        }
    }
}
