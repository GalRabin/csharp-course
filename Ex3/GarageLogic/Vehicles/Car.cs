using GarageLogic.Exceptions;

namespace GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        private static readonly int sr_DefaultNumberOfWheels = 4;
        private static readonly int sr_DefaultMaxWheelsPressure = 32;
        private Enums.eCarColors m_Color;
        private int m_NumberOfDoors;

        protected Car(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber) :
            base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber)
        {
        }

        public Enums.eCarColors Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                if (2 <= value && value <= 5)
                {
                    m_NumberOfDoors = value;    
                }
                
                throw new ValueOutOfRangeException(2, 5);
            }
        }
    }
}