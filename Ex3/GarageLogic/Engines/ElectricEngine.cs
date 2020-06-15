using System;
using GarageLogic.Exceptions;

namespace GarageLogic.Engines
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy, float i_CurrentEnergy) : base(i_MaxEnergy, i_CurrentEnergy)
        {
            
        }

        internal override void Recharge(float numberOfHoursToCharge)
        {
            if (numberOfHoursToCharge + m_CurrentEnergy > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergy);
            }

            m_CurrentEnergy += numberOfHoursToCharge;
        }

        internal override void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount)
        {
            throw new ArgumentException("Electric car can't fuel.");
        }
    }
}