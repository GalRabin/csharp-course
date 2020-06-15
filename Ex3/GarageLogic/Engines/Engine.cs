namespace GarageLogic.Engines
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergy;
        protected float m_CurrentEnergy;

        protected Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }

        internal abstract void Recharge(float numberOfHoursToCharge);

        internal abstract void Refuel(Enums.eFuelTypes i_FuelType, float i_FuelAmount);

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
        }
    }
}