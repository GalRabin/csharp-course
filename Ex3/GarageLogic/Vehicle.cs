using System;
using System.Collections.Generic;
using System.Text;

namespace EX3
{
    public abstract class Vehicle
    {
        private string m_LicenseNumber;
        private string m_ModelName;
        private FuelEngine m_FuelEngine;
        private ElectricEngine m_ElectricEngine;
        private List<Wheel> i_Wheels;
        public string ModelName
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
        public string LicenseNumber
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
        public void SetFuelMax(int i_Max)
        {
            this.m_FuelEngine.MaxAmountOfFuelsLiters = i_Max;
        }
        public void SetFuelType(FuelEngine.eFuelTypes i_Type)
        {
            this.m_FuelEngine.FuelType = i_Type;
        }
        public void SetElectricMax(int i_Max)
        {
            this.m_ElectricEngine.MaxTimeOfEngineHours = i_Max;
        }
        public object Engine
        {
            get
            {
                if (m_ElectricEngine != null)
                {
                    return m_ElectricEngine;
                }
                if (m_FuelEngine != null)
                {
                    return m_FuelEngine;
                }

                return null;
            }
            set
            {
                m_ElectricEngine = null;
                m_FuelEngine = null;

                if (value is FuelEngine)
                {
                    m_FuelEngine = (FuelEngine)value;
                }
                else if (value is ElectricEngine)
                {
                    m_ElectricEngine = (ElectricEngine)value;
                }
                else
                {
                    throw new ArgumentException("Not valid engien object");
                }
            }
        }
        public StringBuilder getEngineInfo()
        {
            StringBuilder str = new StringBuilder();

            if(m_ElectricEngine != null)
            {
                str.Append("Engine type: electric engine\n");
                str.Append(m_ElectricEngine.getInfo() + "\n");
            }
            else
            {
                str.Append("Engine type: fuel engine\n");
                str.Append(m_FuelEngine.getInfo() + "\n");
            }

            return str;
        }
        public List<Wheel> Wheels
        {
            get
            {

                return i_Wheels;
            }
            set
            {
                i_Wheels = value;
            } 
        }
        public StringBuilder getWheelsInfo()
        {
            StringBuilder str = new StringBuilder();
            
            for(int i = 0; i < this.i_Wheels.Count; i++) 
            {
                Wheel wheel = this.i_Wheels[i];
                str.Append("Wheel number " + i + 1 + "\n" + wheel.getInfo() + "\n");
            }
            
            return str;
        }
        public abstract int DefaultNumberOfWheels();

        public float RemainingEnergyPrecentage()
        {
            // TODO implement
            float remainingEnergy = 2;

            return remainingEnergy;
        }
    }
}