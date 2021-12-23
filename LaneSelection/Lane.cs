using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSelection
{
    class Lane
    {
        public double FailRate { get; protected set; }
        public int AttemptsToAddLoad { get; protected set; }
        public int LoadsDelivered { get; protected set; }
        private Random randomNumber;
        public Lane (double fail)
        {
            randomNumber = new Random();
            FailRate = fail;
            AttemptsToAddLoad = 0;
            LoadsDelivered = 0;
        }
        public bool AddLoad()
        {
            AttemptsToAddLoad++;
            if (randomNumber.NextDouble()*100 < FailRate)
            {
                return false;
            }
            else
            {
                LoadsDelivered++;
                return true;
            }
        }
    }
}
