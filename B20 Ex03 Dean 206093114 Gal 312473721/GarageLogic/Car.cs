using System;

namespace EX3
{
    public class Car : Vehicle
    {
        public enum CarColors
        {
            None,
            Red,
            Blue,
            Black,
            Gray
        }

        private int numberOfDoors;
        private CarColors color;

        public CarColors Color
        {
            get
            {
                return color;
            }
            set
            {    
                if (!Enum.IsDefined(typeof(CarColors), (int) value))
                {
                    color = CarColors.None;
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
    }
}