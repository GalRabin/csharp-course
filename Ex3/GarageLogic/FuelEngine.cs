using System;

namespace EX3
{
    public class FuelEngine
    {
        public enum eFuelTypes
        {
            None,
            Soler,
            Octane95,
            Octane96,
            Octane98
        }

        private eFuelTypes m_FuelType;
        private float m_CurrentAmountOfFuelsLiters;
        private float m_MaxAmountOfFuelsLiters;

        public eFuelTypes FuelType
        {
            get
            {

                return m_FuelType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(eFuelTypes), (int) value))
                {
                    m_FuelType = eFuelTypes.None;
                    throw new ArgumentException("Invalid fuel type");
                }

                m_FuelType = value;  
            } 
        }

        public float MaxAmountOfFuelsLiters
        {
            get
            {

                return m_MaxAmountOfFuelsLiters;
            }
            set
            {
                m_MaxAmountOfFuelsLiters = value;  
            } 
        }

        public float CurrentAmountOfFuelsLiters
        {
            get
            {

                return m_CurrentAmountOfFuelsLiters;
            }
            set
            {
                if (value > m_MaxAmountOfFuelsLiters)
                {
                    throw new System.Exception("Current amount in tank can not be more than maximum, " + this.m_MaxAmountOfFuelsLiters);
                }

                m_CurrentAmountOfFuelsLiters = value;   
            }
        }
        public string getInfo()
        {
            string str = string.Format(
                "Fuel type: {0}\n" +
                "Maximum liters on full tank: {1}\n" +
                "Current amount of litrs in tank: {2}\n",
                this.m_FuelType.ToString(),
                this.m_MaxAmountOfFuelsLiters,
                this.m_CurrentAmountOfFuelsLiters);

            return str;
        }
        public void RefuelOperation(float i_LitersToRefuel)
        {
            if (i_LitersToRefuel + m_CurrentAmountOfFuelsLiters > m_MaxAmountOfFuelsLiters)
            {
                throw new ArgumentException("Unable to fuel more than full capacity.");
            }

            m_CurrentAmountOfFuelsLiters += i_LitersToRefuel;
        }
    }
}