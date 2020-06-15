using System.Collections.Generic;
using GarageLogic.Engines;

namespace GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private static readonly int sr_DefaultNumberOfWheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Enums.eVehicleGarageStatus m_VehicleStatus;
        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = Enums.eVehicleGarageStatus.InRepair;
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
        }

        internal string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        internal string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        internal Enums.eVehicleGarageStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        internal string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }
    }
}