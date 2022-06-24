using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherWeb.Models
{
    public class City
    {
        [Key]
        public int key { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string WeatherText { get; set; } = String.Empty;
        [Required]
        public double Temperature { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
