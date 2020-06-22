using GarageLogic.Engines;
using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        private Enums.eCarColors m_Color;
        private int m_NumberOfDoors;
        
        protected Car(Customer i_Customer, string i_ModelName, string i_LicenseNumber,
             List<Wheel> i_Wheels, Engine i_Engine, Enums.eCarColors i_Color, int i_NumberOfDoors) :
            base(i_Customer, i_ModelName, i_LicenseNumber, i_Wheels, i_Engine)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }

        public Enums.eCarColors Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                if (2 <= value && value <= 5)
                {
                    m_NumberOfDoors = value;    
                }
                
                throw new ValueOutOfRangeException(2, 5);
            }
        }
        public override string ToString()
        {

            return base.ToString() + string.Format("Car color: {0}" + Environment.NewLine + 
                                                    "Number of doors: {1}" + Environment.NewLine,
                                                    this.Color,
                                                    this.NumberOfDoors);
        }
    }
}