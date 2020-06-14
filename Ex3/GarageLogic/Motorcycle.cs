using System;

namespace EX3
{
    public class Motorcycle : Vehicle
    {
        public enum eMotorCycleLicenseTypes
        {
            None = 0,
            A1 = 1,
            A = 2,
            AA = 3,
            B = 4
        }
        
        private eMotorCycleLicenseTypes m_LicenseType;
        private int m_EngineVolume;

        public eMotorCycleLicenseTypes LicenseType
        {
            get
            {

                return m_LicenseType;
            }

            set
            {
                if (!Enum.IsDefined(typeof(eMotorCycleLicenseTypes), (int) value))
                {
                    m_LicenseType = eMotorCycleLicenseTypes.None;
                    throw new ArgumentException("Invalid license value");
                }

                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {

                return m_EngineVolume;   
            }
            
            set
            {
                m_EngineVolume = value;   
            }
        }
        
        public override int DefaultNumberOfWheels()
        {

            return 2;
        }
    }
}