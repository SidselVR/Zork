using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorkProgram
{
    public enum Directions
    {
        West,
        North,
        South,
        East
    }

   class Area
    {
        //something to hold connected nodes/areas
        public Dictionary<Directions, Area> neighbors = new Dictionary<Directions, Area>();

        //name of area
        public string name;

        //description of area
        public string description;

        //constructor
        public Area(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        //method to add an area to a specific direction
        public void AddArea(Area other, Directions dir)
        {
            neighbors.Add(dir, other);
            //other.neighbors.Add(, this);

        }
        //method that returns connected area in specific direction


    }

    namespace Zork
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Add Areas
                Area a = new Area("A", "");
                Area b = new Area("B", "");
                Area c = new Area("C", "");
                Area d = new Area("D", "");

                //connect Areasto each other
                a.AddArea(c, Directions.West);
                c.AddArea(a, Directions.East);
                c.AddArea(d, Directions.West);
                d.AddArea(c, Directions.East);
                a.AddArea(b, Directions.North);
                b.AddArea(a, Directions.South);

                //Where do you start
                Area currentArea = a;

                //Read input in console
                string Command = Console.ReadLine();
                //split the command into pieces
                string[] inputs = Command.Split(' ');
                //looks ar the first word in the command and sees if it is a command
                switch (inputs[0])
                {
                    //if "go" command is given
                    case "go":
                    case "Go":
                        switch (inputs[1])
                        {
                            case "east":
                            case "East":
                                GoToDirection(Directions.East, ref currentArea);
                                break;
                            case "west":
                            case "West":
                                GoToDirection(Directions.West, ref currentArea);
                                break;
                            case "north":
                            case "North":
                                GoToDirection(Directions.North, ref currentArea);
                                break;
                            case "south":
                            case "South":
                                GoToDirection(Directions.South, ref currentArea);
                                break;
                        }
                        break;

                    default:
                        break;
                }

            }

            public static void GoToDirection(Directions dir, ref Area currentArea)
            {
                if (currentArea.neighbors.ContainsKey(dir))
                    currentArea = currentArea.neighbors[dir];
                else Console.WriteLine("There is nothing there");
            }
        }
    }
}
