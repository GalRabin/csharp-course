namespace EX3
{
    public class Motorcycle : Vehicle
    {
        public enum MotorCycleLicenseTypes
        {
            A1,
            A,
            AA,
            B
        }
        
        private MotorCycleLicenseTypes licenseTypes;
        private int engineVolume;

        public Motorcycle(string modelName, string licenseNumber, MotorCycleLicenseTypes licenseTypes, int engineVolume) : base(modelName, licenseNumber)
        {
            this.licenseTypes = licenseTypes;
            this.engineVolume = engineVolume;
        }
        
        public MotorCycleLicenseTypes LicenseTypes
        {
            get => licenseTypes;
        }

        public int EngineVolume
        {
            get => engineVolume;
        }
    }
}