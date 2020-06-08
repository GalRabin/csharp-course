using System;

namespace EX3
{
    public class Motorcycle : Vehicle
    {
        public enum MotorCycleLicenseTypes
        {
            None = 0,
            A1 = 1,
            A = 2,
            AA = 3,
            B = 4
        }
        
        private MotorCycleLicenseTypes licenseType;
        private int engineVolume;


        public MotorCycleLicenseTypes LicenseType
        {
            get
            {
                return licenseType;
            }

            set
            {
                if (!Enum.IsDefined(typeof(MotorCycleLicenseTypes), (int) value))
                {
                    licenseType = MotorCycleLicenseTypes.None;
                    throw new ArgumentException("Invalid license value");
                }

                licenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return engineVolume;   
            }
            
            set
            {
                engineVolume = value;   
            }
        }
    }
}