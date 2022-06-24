namespace WeatherWeb.Entities

//[
//  {
//    "LocalObservationDateTime": "2022-06-22T11:53:00+03:00",
//    "EpochTime": 1655887980,
//    "WeatherText": "Mostly sunny",
//    "WeatherIcon": 2,
//    "HasPrecipitation": false,
//    "PrecipitationType": null,
//    "IsDayTime": true,
//    "Temperature": {
//      "Metric": {
//        "Value": 28,
//        "Unit": "C",
//        "UnitType": 17
//      },
//      "Imperial": {
//"Value": 82,
//        "Unit": "F",
//        "UnitType": 18
//      }
//    },
//    "MobileLink": "http://www.accuweather.com/en/il/tel-aviv-port/215793/current-weather/215793?lang=en-us",
//    "Link": "http://www.accuweather.com/en/il/tel-aviv-port/215793/current-weather/215793?lang=en-us"
//  }
//]


{
    public class CityInfoObj
    {
        public string WeatherText { get; set; }
        public Temperature Temperature { get; set; }

    }

    public class Temperature
    {
        public Metric  Metric { get; set; }
        public Imperial Imperial { get; set; } 
    }

    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public Int32 UnitType { get; set; }
    }
    public class Imperial
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public Int32 UnitType { get; set; }
    }
}
