using System;

namespace EX3
{
    public class Car : Vehicle
    {
        public enum eColors
        {
            None,
            Red,
            Blue,
            Black,
            Gray
        }

        private int m_NumberOfDoors;
        private eColors m_Color;

        public eColors Color
        {
            get
            {
                return m_Color;
            }
            set
            {    
                if (!Enum.IsDefined(typeof(eColors), (int) value))
                {
                    m_Color = eColors.None;
                    throw new ArgumentException("Invalid color value");
                }

                m_Color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {

              return  m_NumberOfDoors;
            }
            set
            {
                if (IsValidNumberOfDoors(value))
                {
                    m_NumberOfDoors = value;   
                }
                else
                {
                    throw new ArgumentException("Number of doors is not valid, only 2-5");
                }
            }
        }
        
        private static bool IsValidNumberOfDoors(int i_NumberOfDoors)
        {

            return i_NumberOfDoors >= 2 && i_NumberOfDoors <= 5;
        }

        public override int DefaultNumberOfWheels()
        {

            return 4;
        }
    }
}