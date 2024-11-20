using Microsoft.AspNetCore.Mvc;
using TPLOCAL1.Models;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        // Méthode d'index, appelée par le router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View();
            else
            {
                switch (id)
                {
                    case "OpinionList":
                        var opinions = ReadOpinionsFromXml();
                        return View("OpinionList", opinions);
                    case "Form":
                        var formModel = new FormModel(); // Créez un modèle de formulaire vide
                        return View("Form", formModel);
                    default:
                        return View();
                }
            }
        }
        public IActionResult Form()
        {
            // Assurez-vous que FormModel est correctement initialisé
            var formModel = new FormModel
            {
                Form = "Sélectionner une formation" // Initialisez la valeur par défaut
            };

            return View(formModel);
        }


        // Méthode pour lire les avis depuis un fichier XML
        private List<Opinion> ReadOpinionsFromXml()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "opinions.xml");
            if (!System.IO.File.Exists(filePath))
            {
                return new List<Opinion>();  // Retourne une liste vide si le fichier n'existe pas
            }

            var serializer = new XmlSerializer(typeof(List<Opinion>), new XmlRootAttribute("Opinions"));
            using (var reader = new StreamReader(filePath))
            {
                return (List<Opinion>)serializer.Deserialize(reader);
            }
        }

        // Méthode pour envoyer les données du formulaire à la page de validation
        [HttpPost]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            if (ModelState.IsValid)
            {
                // Créez un FormationModel et envoyez-le à la vue ValidationForm
                var formationModel = new FormationModel { InfoPage = model };
                return RedirectToAction("ValidationForm", new { model = formationModel });
            }
            // Si le modèle est invalide, retourner à la vue Form avec des erreurs
            return View("Form", model);
        }

        // Méthode pour afficher la page de validation avec les données du modèle
        public IActionResult ValidationForm(FormationModel model)
        {
            if (model != null)
            {
                return View(model);
            }
            return View("Form");
        }

        // Action pour afficher la liste des avis
        public IActionResult ListReviews()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "DataAvis.xml");
            OpinionList opinionList = new OpinionList();
            var opinions = opinionList.GetAvis(filePath);
            return View(opinions);
        }
    }
}




