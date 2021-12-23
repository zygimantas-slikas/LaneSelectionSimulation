using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSelection
{
    class Conveyor
    {
        public List<Lane> destinationLanes { get; private set; }
        private ISelect selectionStrategy;
        private int LoadsPassed;
        public Conveyor(int lanesCount, int selection, int sequenceLenght, double laneFailRate)
        {
            LoadsPassed = 0;
            switch (selection)
            {
                case 1:
                    selectionStrategy = new RoundRobin(lanesCount, sequenceLenght);
                    break;
                case 2:
                    selectionStrategy = new RandomSelect(lanesCount, sequenceLenght);
                    break;
                default:
                    Console.WriteLine("Wrong lane selection parameters.");
                    return;
            }
            destinationLanes = new List<Lane>(lanesCount + 1);
            destinationLanes.Add(new Lane(0.0)); // lane 0 - always succedss
            for (int i = 1; i <= lanesCount; i++)
            {
                destinationLanes.Add(new Lane(laneFailRate));
            }
        }
        public void AddLoad()
        {
            LoadsPassed++;
            if (destinationLanes.Count == 1 || !destinationLanes[selectionStrategy.GetLaneId()].AddLoad())
            { //if adding to selected lane failed, ad to default 0
                destinationLanes[0].AddLoad(); 
            }
        }
        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            for(int i = 0; i <= destinationLanes.Count; i++)
            {
                strBuild.Append("+-------");
            }
            strBuild.Append("+\n|Lane Id");
            for (int i = 0; i < destinationLanes.Count; i++)
            {
                strBuild.Append(String.Format("|{0,7}",i));
            }
            strBuild.Append("|\n");

            for (int i = 0; i <= destinationLanes.Count; i++)
            {
                strBuild.Append("+-------");
            }
            strBuild.Append("+\n|% Total");

            for (int i = 0; i < destinationLanes.Count; i++)
            {
                double percent = (double)(destinationLanes[i].LoadsDelivered) / (double)LoadsPassed;
                strBuild.Append(String.Format("|{0,7:P2}", percent));
            }
            strBuild.Append("|\n");
            for (int i = 0; i <= destinationLanes.Count; i++)
            {
                strBuild.Append("+-------");
            }
            strBuild.Append("+\n|%Target");

            for (int i = 0; i < destinationLanes.Count; i++)
            {
                double percent = (double)(destinationLanes[i].LoadsDelivered) / (double)destinationLanes[i].AttemptsToAddLoad;
                strBuild.Append(String.Format("|{0,7:P2}", percent));
            }
            strBuild.Append("|\n");
            for (int i = 0; i <= destinationLanes.Count; i++)
            {
                strBuild.Append("+-------");
            }
            strBuild.Append("+\n");
            return strBuild.ToString();
        }
    }
}
