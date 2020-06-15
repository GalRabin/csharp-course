using System;
using GarageLogic.Exceptions;

namespace GarageLogic.Engines
{
    public class FuelEngine : Engine
    {
        private readonly Enums.eFuelTypes r_FuelType;
        
        public FuelEngine(float i_MaxEnergy, float i_CurrentEnergy, Enums.eFuelTypes i_FuelType) : base(i_MaxEnergy, i_CurrentEnergy)
        {
            r_FuelType = i_FuelType;
        }

        internal override void Recharge(float numberOfHoursToCharge)
        {
            throw new ArgumentException("Fuel engine can't charge.");
        }

        internal override void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Unable to fuel car with not matching fuel type");
            }
            if (m_CurrentEnergy + i_FuelAmount > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergy);
            }

            m_CurrentEnergy += i_FuelAmount;
        }
    }
}