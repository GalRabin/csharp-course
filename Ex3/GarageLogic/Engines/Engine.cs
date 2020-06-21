using GarageLogic.Exceptions;
using System;

namespace GarageLogic.Engines
{
    public abstract class Engine
    {
        protected float m_MaxEnergy;
        protected float m_CurrentEnergy;
        
        protected Engine(float i_CurrentEnergy, float i_MaxEnergy = float.MaxValue )
        {
            m_MaxEnergy = i_MaxEnergy;
            if (m_CurrentEnergy > m_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, i_MaxEnergy);
            }
            else
            {
                m_CurrentEnergy = i_CurrentEnergy;
            }
        }
        
        internal abstract void Recharge(float numberOfHoursToCharge);

        internal abstract void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount);

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                this.m_CurrentEnergy = value;
            }
        }

        public override string ToString()
        {

            return string.Format("Current Energy: {0}" + Environment.NewLine +
                                 "Max Energy: {1}" + Environment.NewLine, 
                                this.CurrentEnergy,
                                this.MaxEnergy);
        }
    }
}