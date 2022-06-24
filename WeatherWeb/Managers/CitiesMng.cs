using WeatherWeb.Services;

namespace WeatherWeb.Managers
{
    public class CitiesMng
    {
        private CalloutSvc calloutSvc;
        public CitiesMng()
        {
            calloutSvc = new CalloutSvc();
        }
        public string getCityIdResponse(string city)
        {
            string response = calloutSvc.GetCityKey(city);

            // if return = null or error response then push to log file etc..

            return response;
        }

        public string getCityInfo(string cityId)
        {
            string response = calloutSvc.GetCityInfo(cityId);

            // if return = null or error response then push to log file etc..

            return response;
        }


        public string GetCityKeyResponse = "[{\"Version\":1,\"Key\":\"215793\",\"Type\":\"City\",\"Rank\":95,\"LocalizedName\":\"Tel-aviv Port\",\"Country\":{\"ID\":\"IL\",\"LocalizedName\":\"Israel\"},\"AdministrativeArea\":{\"ID\":\"TA\",\"LocalizedName\":\"Tel Aviv\"}}]";
        public string GetCityInfoResponse = "[{\"LocalObservationDateTime\":\"2022-06-22T16:48:00+03:00\",\"EpochTime\":1655905680,\"WeatherText\":\"Sunny\",\"WeatherIcon\":1,\"HasPrecipitation\":false,\"PrecipitationType\":null,\"IsDayTime\":true,\"Temperature\":{\"Metric\":{\"Value\":28.8,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":84.0,\"Unit\":\"F\",\"UnitType\":18}},\"MobileLink\":\"http://www.accuweather.com/en/il/tel-aviv-port/215793/current-weather/215793?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/il/tel-aviv-port/215793/current-weather/215793?lang=en-us\"}]";
    }
}
