using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic.Engines;
using GarageLogic.Exceptions;

namespace GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private Customer m_Owner;
        private Enums.eVehicleGarageStatus m_VehicleStatus;
        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;
        
        
        public Vehicle(Customer i_Customer, string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels,
            Engine i_Engine)
        {
            this.m_Owner = i_Customer;
            this.m_VehicleStatus = Enums.eVehicleGarageStatus.InRepair;
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Wheels = i_Wheels;
            this.m_Engine = i_Engine; 
        }

        public Customer Customer
        {
            get
            {
                return this.m_Owner;
            }
            set
            {
                this.m_Owner = value;
            }
        }
        public Enums.eVehicleGarageStatus VehicleStatus
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

        public List<Wheel> Wheels
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
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(m_Owner.ToString() + Environment.NewLine);
            stringBuilder.Append(string.Format("Vehicle status: {0}" + Environment.NewLine +
                                                "Model name: {1}" + Environment.NewLine +
                                                "License number: {2}" + Environment.NewLine,
                                                m_VehicleStatus,
                                                m_ModelName,
                                                m_LicenseNumber));
            int i = 0;

            foreach(Wheel wheel in m_Wheels)
            {
                stringBuilder.Append(string.Format("Wheel number {0} details: ", i + 1) + Environment.NewLine);
                stringBuilder.Append(wheel.ToString());
                i++;
            }

            stringBuilder.Append(m_Engine.ToString());

            return stringBuilder.ToString();
        }
    }
}
 