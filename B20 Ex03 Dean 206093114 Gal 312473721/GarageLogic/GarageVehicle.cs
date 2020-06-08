namespace EX3
{
    public class GarageVehicle
    {
        public enum VehicleGarageStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }
        
        private string ownerName;
        private string phoneNumber;
        private Vehicle vehicle;
        private VehicleGarageStatus vehicleStatus;
        
        public GarageVehicle(string ownerName, string phoneNumber, Vehicle vehicle)
        {
            this.ownerName = ownerName;
            this.phoneNumber = phoneNumber;
            this.vehicle = vehicle;
            this.vehicleStatus = VehicleGarageStatus.InRepair;
        }

        public string OwnerName => ownerName;

        public string PhoneNumber => phoneNumber;

        public Vehicle Vehicle => vehicle;

        public VehicleGarageStatus VeiclStatus
        {
            get => vehicleStatus;
            set => vehicleStatus = value;
        }
    }
}