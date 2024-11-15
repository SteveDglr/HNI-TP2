using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class FormModel
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Sexe { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Merci d'introduire un code postal à 5 chiffres.")]
        public string CodePostal { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2020", ErrorMessage = "La date doit être avant le 01/01/2021")]
        public DateTime DebForm { get; set; }

        [Required]
        public string Form { get; set; }

        [Required]
        public string Cobol { get; set; }

        [Required]
        public string Dotnet { get; set; }
    }
    public class FormationModel
    {
        public FormModel InfoPage { get; set; }
    }
}