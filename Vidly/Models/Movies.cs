using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Por favor introduzca un nombre.")]
        public string name { get; set; }
        
        public int id { get; set; }

        [Display(Name = "Genre")]

        [Required(ErrorMessage = "Por favor inserte un genero.")]
        public string genre { get; set; }

        [Display(Name = "Day of Release")]
        [Required(ErrorMessage = "Especifica una fecha ")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Amount in Stock")]
        [Required(ErrorMessage = "Necesita especificar,cuantas peliculas quedan en bodega")]
        [Range(1, 20, ErrorMessage = "Por favor introduzca un numero de 1 a 20.")]
        public int inStock { get; set; }
    }
}