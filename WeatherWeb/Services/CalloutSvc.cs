
namespace WeatherWeb.Services
{
    internal class CalloutSvc
    {
        private readonly string accessKey;

        /// ctor 
        public CalloutSvc()
        {
            accessKey = "ZuGfkR5VeWwLwe0OoVMpkRe9Exb5Ijrj";
        }
        private string cityKeyApiUrl
        {
            get
            {
                return "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";
            }
        }
        private string currentCityInfoApiUrl
        {
            get
            {
                return "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";
            }
        }

        public string GetCityKey(string cityname)
        {
            string uri = string.Format(cityKeyApiUrl, accessKey, cityname);
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(uri).Result;
            }
        }

        public string GetCityInfo(string citykey)
        {
            string uri = string.Format(currentCityInfoApiUrl, citykey, accessKey);
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(uri).Result;
            }
        }
    }
}
