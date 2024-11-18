using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        return View(id);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infopage"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            //if (modelv.Address == null || modelv.Address.Length < 5)
            //{
            //    ModelState.AddModelError("", "address too short");
            //}

            // if (ModelState.IsValid)
            //{
            //    var model = new FormationModel { InfoPage = infopage };
            // All data is valid, show success page
            //    return RedirectToAction("ValidationForm", model);
            //}
            //else
            //{
            // Validation failed, return to the form with errors
            //    return View("Form");
            //}
            //return null;
            
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Validation", model);
            }

            return View(model);
        }
        }
        public IActionResult ValidationPage(ErrorViewModel model)
        {
            return View(model);  // La vue de validation affichera les données
        }
// Action pour afficher la liste des avis
public IActionResult ListReviews()
        {
            // Spécifiez le chemin vers votre fichier XML (exemple : "wwwroot/avis.xml")
            string filePath = "chemin/vers/votre/fichier.xml";

            // Instanciation de la classe OpinionList et récupération des avis
            OpinionList opinionList = new OpinionList();
            var opinions = opinionList.GetAvis(filePath);

            // Passer la liste des avis à la vue
            return View(opinions);
        }


    }
}

    
        
        
  