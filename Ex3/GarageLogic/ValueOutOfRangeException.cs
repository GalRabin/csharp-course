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

        public override string Message
        {
            get
            {
                return string.Format("Value out of range." + Environment.NewLine + 
                    "Min value: {0}." + Environment.NewLine + 
                    "Max value: {1}" + Environment.NewLine,
                    this.MinValue, this.MaxValue);
            }
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