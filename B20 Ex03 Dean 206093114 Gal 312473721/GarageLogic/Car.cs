namespace EX3
{
    public class Car : Vehicle
    {
        public enum CarColors
        {
            Red,
            Blue,
            Black,
            Gray
        }

        private int numberOfDoors;
        private CarColors colors;
        
        public Car(string modelName, string licenseNumber, int numberOfDoors, CarColors colors) : base(modelName, licenseNumber)
        {
            this.numberOfDoors = numberOfDoors;
            this.colors = colors;
        }

        public CarColors Colors => colors;

        public int NumberOfDoors => numberOfDoors;
    }
}