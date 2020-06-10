using System;

namespace EX3
{
    public class Car : Vehicle
    {
        public enum Colors
        {
            None,
            Red,
            Blue,
            Black,
            Gray
        }

        private int numberOfDoors;
        private Colors color;
        public Colors Color
        {
            get
            {
                return color;
            }
            set
            {    
                if (!Enum.IsDefined(typeof(Colors), (int) value))
                {
                    color = Colors.None;
                    throw new ArgumentException("Invalid color value");
                }

                color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
              return  numberOfDoors;
            }
            set
            {
                if (IsValidNumberOfDoors(value))
                {
                    numberOfDoors = value;   
                }
                else
                {
                    throw new ArgumentException("Number of doors is not valid");
                }
            }
        }

        private static bool IsValidNumberOfDoors(int numberOfDoors)
        {
            return numberOfDoors >= 2 && numberOfDoors <= 5;
        }

        public override int DefaultNumberOfWheels()
        {
            return 4;
        }
    }
}