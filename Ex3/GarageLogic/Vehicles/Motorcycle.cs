using GarageLogic.Engines;
using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public abstract class Motorcycle : Vehicle
    {
        private Enums.eMotorcycleLicenseTypes m_LicenseType;
        private int m_EngineVolume;
        
        public Motorcycle(Customer i_Customer, string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels,
            Engine i_Engine, Enums.eMotorcycleLicenseTypes i_LicenseType, int i_EngineVolume) :
            base(i_Customer, i_ModelName, i_LicenseNumber, i_Wheels, i_Engine)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
        }

        public Enums.eMotorcycleLicenseTypes LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
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
        public override string ToString()
        {
            return base.ToString() + string.Format("License type: {0}" + Environment.NewLine +
                                                    "Engine volume: {1}" + Environment.NewLine,
                                                    this.LicenseType,
                                                    this.EngineVolume);
        }
    }
}