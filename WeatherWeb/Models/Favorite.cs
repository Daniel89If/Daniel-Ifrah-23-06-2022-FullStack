using System.ComponentModel.DataAnnotations;

namespace WeatherWeb.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;

    }
}