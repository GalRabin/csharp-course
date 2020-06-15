using System;

namespace GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue; 
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
        
        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
    }
}