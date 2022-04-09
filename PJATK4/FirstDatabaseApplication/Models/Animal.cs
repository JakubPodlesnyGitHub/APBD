using System.ComponentModel.DataAnnotations;

namespace FirstDatabaseApplication.Models
{
    public class Animal
    {

        [Required(ErrorMessage = "Imie jest wymagane")]
        [MaxLength(100, ErrorMessage = "Maskymalna dlugosc imienia wynosi: 100")]
        public string _Name { get; set; }

        [MaxLength(200, ErrorMessage = "Maskymalna dlugosc opisu wynosi: 200")]
        public string _Description { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [MaxLength(100, ErrorMessage = "Maskymalna dlugosc kategori wynosi: 100")]
        public string _Category { get; set; }

        [Required(ErrorMessage = "Kraj jest wymagany")]
        [MaxLength(500, ErrorMessage = "Maskymalna dlugosc kraju wynosi: 500")]
        public string _Area { get; set; }

        public override string ToString()
        {
            return "Name: " + _Name + " Description: " + _Description + " Category: " + _Category + " Area: " + _Area;
        }
    }
}
