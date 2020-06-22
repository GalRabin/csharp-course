using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
    public class VehiclesDictionary
    {
        public static readonly Dictionary<Enums.eVehicleType, Dictionary<string, object>> sr_DefaultDictionary = 
            new Dictionary<Enums.eVehicleType, Dictionary<string, object>>()
        {
            {Enums.eVehicleType.FuelMotorcycle, new Dictionary<string, object>
                {
                    {"Number Of Wheels", 2 },
                    {"Maximum Air Pressure", 30f},
                    {"Fuel Type", Enums.eFuelTypes.Octan95},
                    {"Maximum Energy", 1.2f}
                }
            },
            {Enums.eVehicleType.ElectricMotorcycle, new Dictionary<string, object>
                {
                    {"Number Of Wheels", 2 },
                    {"Maximum Air Pressure", 30f},
                    {"Maximum Energy", 1.2f}
                }
            },
            {Enums.eVehicleType.FuelCar, new Dictionary<string, object>
                {
                    {"Number Of Wheels", 4 },
                    {"Maximum Air Pressure", 32f},
                    {"Fuel Type", Enums.eFuelTypes.Octan96},
                    {"Maximum Energy", 60f}
                }
            },
            {Enums.eVehicleType.ElectricCar, new Dictionary<string, object>
                {
                    {"Number Of Wheels", 4 },
                    {"Maximum Air Pressure", 32f},
                    {"Maximum Energy", 2.1f}
                }
            },
            {Enums.eVehicleType.FuelTruck, new Dictionary<string, object>
                {
                    {"Number Of Wheels", 16 },
                    {"Maximum Air Pressure", 28f},
                    {"Fuel Type", Enums.eFuelTypes.Soler},
                    {"Maximum Energy", 120f}
                }
            }
        };   
    }
}
