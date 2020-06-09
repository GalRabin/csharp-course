namespace EX3
{
    public class GarageVehicle
    {
        public enum VehicleGarageStatus
        {
            None,
            InRepair,
            Repaired,
            PayedFor
        }
        
        private string ownerName;
        private string phoneNumber;
        private Vehicle vehicle;
        private VehicleGarageStatus vehicleStatus;

        public string OwnerName
        {
            get
            {
                return ownerName;
            }
            set
            {
                ownerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }
        }

        public VehicleGarageStatus VehicleStatus
        {
            get
            {
                return vehicleStatus;
            }
            set
            {
                vehicleStatus = value;
            }
        }
    }
}