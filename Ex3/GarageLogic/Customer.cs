using System;
using System.Collections.Generic;
using System.Text;
using GarageLogic.Vehicles;

namespace GarageLogic
{
    public class Customer
    {
        private string m_Name;
        private string m_PhoneNumber;
        
        public Customer(string i_Name, string i_PhoneNumber)
        {
            this.m_Name = i_Name;
            this.m_PhoneNumber = i_PhoneNumber;
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.m_PhoneNumber;
            }
            set
            {
                this.m_PhoneNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Customer name: {0}" + Environment.NewLine+
                                "Customer phone number: {1}",
                                this.Name,
                                this.PhoneNumber);
        }
    }
}
