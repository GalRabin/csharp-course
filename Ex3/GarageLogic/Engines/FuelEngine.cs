using System;
using GarageLogic.Exceptions;

namespace GarageLogic.Engines
{
    public class FuelEngine : Engine
    {
        private Enums.eFuelTypes m_FuelType;

         public FuelEngine(float i_CurrentEnergy, float i_MaxEnergy = float.MaxValue, Enums.eFuelTypes i_FuelType = Enums.eFuelTypes.None) : 
             base( i_CurrentEnergy, i_MaxEnergy)
         {
             m_FuelType = i_FuelType;
         }

        public Enums.eFuelTypes FuelType
        {
            get
            {
                return this.m_FuelType;
            }
            set
            {
                this.m_FuelType = value;
            }
        }
        internal override void Recharge(float numberOfHoursToCharge)
        {
            throw new ArgumentException("Fuel engine can't charge.");
        }

        internal override void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Unable to fuel car with not matching fuel type");
            }
            if (m_CurrentEnergy + i_FuelAmount > m_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy);
            }

            m_CurrentEnergy += i_FuelAmount;
        }
        public override string ToString()
        {
            return "Type: Fuel Engine" + Environment.NewLine + base.ToString();
        }
    }
}