using System.Collections.Generic;
using GarageLogic.Vehicles;

namespace GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, Vehicle>();
        }

        public List<string> GetLicenses()
        {
            return new List<string>(m_Vehicles.Keys);
        }
        
        public List<string> GetLicensesByStatus(Enums.eVehicleGarageStatus i_GarageStatus)
        {
            List<string> licenses = new List<string>();
            foreach (KeyValuePair<string, Vehicle> entry in m_Vehicles)
            {
                if (entry.Value.VehicleStatus == i_GarageStatus)
                {
                    licenses.Add(entry.Key);
                }
            }

            return licenses;
        }

        public void UpadeVehicleStatus(string i_LicenseNumber, Enums.eVehicleGarageStatus i_Status)
        {
            m_Vehicles[i_LicenseNumber].VehicleStatus = i_Status;
        }

        public bool IsLicenseNumberExists(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            foreach (Wheel wheel in m_Vehicles[i_LicenseNumber].Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void Refuel(string i_LicenseNumber, Enums.eFuelTypes i_FuelType, float i_FuelAmount)
        {
            m_Vehicles[i_LicenseNumber].Engine.Refuel(i_FuelType, i_FuelAmount);
        }
        
        public void Recharge(string i_LicenseNumber, float numberOfHoursToCharge)
        {
            m_Vehicles[i_LicenseNumber].Engine.Recharge(numberOfHoursToCharge);
        }
    }
}