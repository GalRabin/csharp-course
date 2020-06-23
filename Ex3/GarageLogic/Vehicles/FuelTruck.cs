using GarageLogic.Engines;
using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public class FuelTruck : Vehicle
    {
        private float m_CargoVolume;
        private bool m_DangerousCargo;
        
        public FuelTruck(Customer i_Customer, string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, 
            FuelEngine i_FuelEngine, float i_CargoVolume, bool i_DangerousCargo) : 
            base(i_Customer, i_ModelName, i_LicenseNumber, i_Wheels, i_FuelEngine)
        {
            this.m_CargoVolume = i_CargoVolume;
            this.m_DangerousCargo = i_DangerousCargo;
        }
        
        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }

        public bool DangerousCargo
        {
            get
            {
                return m_DangerousCargo;
            }
            set
            {
                m_DangerousCargo = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("Cargo volume: {0}" + Environment.NewLine +
                                                    "Contain dangerous cargo: {1}" + Environment.NewLine,
                                                    this.CargoVolume,
                                                    this.DangerousCargo);
        }
    }
}