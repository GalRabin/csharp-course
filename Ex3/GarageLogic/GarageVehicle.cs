using System;

namespace EX3
{
    public class GarageVehicle
    {
        public enum eVehicleGarageStatus
        {
            None,
            InRepair,
            Repaired,
            PayedFor
        }
        
        private string m_OwnerName;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleGarageStatus m_VehicleStatus;

        public string OwnerName
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

        public string PhoneNumber
        {
            get
            {

                return m_PhoneNumber;
            }
            set
            {
                m_PhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public eVehicleGarageStatus VehicleStatus
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

        public void InflateAllWheels()
        {
            foreach (Wheel wheel in m_Vehicle.Wheels)
            {
                float missingPressure = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.CurrentAirPressure += missingPressure;
            }
        }
        
        public void RefuelEngine(FuelEngine.eFuelTypes i_FuelType, float i_LitersToFill)
        {
            if (m_Vehicle.Engine is FuelEngine)
            {
                FuelEngine fuelEngine = m_Vehicle.Engine as FuelEngine;
                if (fuelEngine.FuelType != i_FuelType)
                {
                    throw new ArgumentException("Unable to fuel wrong type of fuel.");
                }
                fuelEngine.RefuelOperation(i_LitersToFill);
            }
            else
            {
                throw new ArgumentException("Can't fuel car because engine is not fuel.");
            }
        }

        public void ChargeEngine(float i_HoursToCharge)
        {
            if (m_Vehicle.Engine is ElectricEngine)
            {
                ElectricEngine electricEngine = m_Vehicle.Engine as ElectricEngine; 
                electricEngine.RechargeOperation(i_HoursToCharge);
            }
            else
            {
                throw new ArgumentException("Can't charge car because engine is not electric.");
            }
        }
    }
}