using System;
using GarageLogic.Exceptions;

namespace GarageLogic.Engines
{
    public class ElectricEngine : Engine
    {
        
        public ElectricEngine( float i_CurrentEnergy, float i_MaxEnergy = float.MaxValue) : base(i_CurrentEnergy, i_MaxEnergy)
        {
        }

        internal override void Recharge(float i_NumberOfHoursToCharge)
        {
            if (i_NumberOfHoursToCharge + m_CurrentEnergy > m_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy);
            }

            m_CurrentEnergy += i_NumberOfHoursToCharge;
        }

        internal override void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount)
        {
            throw new ArgumentException("Electric car can't fuel.");
        }

        public override string ToString()
        {
            return "Type: Electric Engine" + Environment.NewLine + base.ToString();
        }
    }
}