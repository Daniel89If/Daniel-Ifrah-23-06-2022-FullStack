namespace WeatherWeb.Entities
{

//[
//  {
//    "Version": 1,
//    "Key": "215793",
//    "Type": "City",
//    "Rank": 95,
//    "LocalizedName": "Tel-aviv Port",
//    "Country": {
//      "ID": "IL",
//      "LocalizedName": "Israel"
//    },
//    "AdministrativeArea": {
//    "ID": "TA",
//      "LocalizedName": "Tel Aviv"
//    }
//  }
//]
    public class AutocompleteObj
    {
        public string Key;
        public string Type;
        public int Rank;
        public string LocalizedName;
    }
}
