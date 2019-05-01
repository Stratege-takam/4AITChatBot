using Chatbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Speech.Synthesis;
using System.Net;
using System.Collections.Specialized;

namespace Chatbot.Controllers
{
    public class HomeController : Controller
    {
        public static List<TravelHelp> list = new List<TravelHelp>();
        public static List<Response> listResponse = new List<Response>();
        private ChatbotContext db = new ChatbotContext();


        public ActionResult Index()
        {
            Response response = new Response();
            try
            {
                list = db.TravelHelps.ToList().Where(f => !string.IsNullOrEmpty(f.Key)).OrderBy(f => f.Key).ToList();
                response.travelHelps = list;
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }
            
            return View(response);
        }

        public Response GetResult(string search)
        {
            Response response = new Response();
            var ListCompetence = new List<string>()
            {
                "Nous espérons que notre reponse correspond à vos attentes",
                "Cette réponse générique."
            };

            var ListNotResult = new List<string>()
            {
                 "Nous rencontrons quelques problèmes techniques, nous vous invitons à consulter notre " +
                "FAQ ou de consulter note service par téléphone au +32 000 111 222",
                "Nous ne pouvons pas vous donner de reponse à cette question",
                "Aucun resultat pour cette question",
                  "Nous n'avons pas de reponse à cette préocupation",
                "Votre question contient probablement des fautes de frappes. Vérifiez et réessayez",
                "Votre question est en dehors de notre domaine de compétence."
            };


            var search1 = search.ToLower().Trim();
            var l = list.Where(f => f.Key.ToLower().Trim().Contains(search1)).ToList();
            // ||
          //  search1.Contains(f.Key.ToLower().Trim())
            bool istrue = false;

            string competence = null;

            if (l.Count==0)
            {
                l = list.Where(f =>f.Value.ToLower().Trim().Contains(search1)).ToList();
                System.Threading.Thread.Sleep(500);
                competence = ListCompetence[(new Random()).Next(0, ListCompetence.Count)];
                istrue = true;
            }

          
            if (l.Count ==0)
            {
                list.Where(f => search1.Contains(f.Key.ToLower().Trim())).ToList();

                if (l.Count == 0)
                {
                    l = list.Where(f => search1.Contains(f.Value.ToLower().Trim())).ToList();
                }
                if (l.Count > 0)
                {
                    System.Threading.Thread.Sleep(500);
                    competence = ListCompetence[(new Random()).Next(0,ListCompetence.Count)];
                }
            }

            //enlever tous les reponses qui n'ont pas de valeur
            l = l.Where(f => !string.IsNullOrEmpty(f.Value)).ToList();

            //indisponibilité de la reponse
            if (l.Count == 0)
            {
                l = list.Where(f => f.Key.ToLower().Trim().Contains(search1)).ToList();
                // principe 
                // parcourir la liste de nos faits
                // pour chaque fait
                // on doit verifier la presence de chaque mot de la liste des mots de la recherche de l'utilisateur
                //dans un fait et si un mot s'y trouve on compte.
                //si au final plus de la moitié des mots de la recherche de l'utilisateur se trouve dans 
                // le fait alors on suppose que le fait est resultat de la recherche
                // par consequent on ajoute le fait dans la liste des resultats
                var result = SplitPhrase(search);
                foreach (var travelHelp in list)
                {
                    var countValue = 0;
                    var countKey = 0;
                    foreach (var item in result)
                    {
                        if (travelHelp.Key.ToLower().Trim().Contains(item.Trim().ToLower()))
                        {
                            countKey++;
                        }
                        if (travelHelp.Value.ToLower().Trim().Contains(item.Trim().ToLower()))
                        {
                            countValue++;
                        }
                    }


                    if (countValue> result.Count/2 || countKey> result.Count/2)
                    {
                        travelHelp.Id = countValue > countKey ? countValue : countKey;
                        l.Add(travelHelp);
                    }

                }




                if (l.Count>0)
                {
                    //Il est propable que le fait (question)  qui contient plus de mots de l'utilisateur
                    // soit la question que  l'utilisateur souhaite poser
                    var travel = l.OrderByDescending(f => f.Id).FirstOrDefault();
                    response = response = new Response()
                    {
                        Key = null,
                        BotBegin = false,
                        Value = travel.Value, 
                        Search = search
                    };
                    listResponse.Add(response);
                }
                else
                {
                    //aucune reponse trouvé il n'y a aucun fait qui correspond 
                    // à la question de l'utilisateur

                    System.Threading.Thread.Sleep(500);
                    response = new Response()
                    {
                        Key = null,
                        BotBegin = false,
                        Value = ListNotResult[(new Random()).Next(0, ListNotResult.Count)],
                        Search = search
                    };
                    listResponse.Add(response);

                    string uriString = "http://www.google.com/search";

                    WebClient webClient = new WebClient();

                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection.Add("q", search);

                    webClient.QueryString.Add(nameValueCollection);
                   var  val = webClient.DownloadString(uriString);

                    //ajouter le fait dans la bd 
                    var tHp = new TravelHelp()
                    {
                         Key = search,
                         Value = val
                    };
                    db.TravelHelps.Add(tHp);
                    db.SaveChanges();
                    list = db.TravelHelps.ToList().Where(f => !string.IsNullOrEmpty(f.Key)).OrderBy(f => f.Key).ToList();
                }
            }
            else
            {
                if (l.Count ==1)
                {
                    var travelhelp = l.FirstOrDefault();
                     response = new Response()
                    {
                        Key = istrue ? competence: null,
                        Value = travelhelp.Value,
                        BotBegin = false,
                        Search = search
                    };
                    response.Key = string.IsNullOrEmpty(competence) ? response.Key : competence;
                    listResponse.Add(response);
                }
                else
                {
                    var alea = new Random();
                    l = l.Where(f => !f.Value.ToString().ToLower().Contains("html")).ToList();
                    var travelhelp = l[alea.Next(0,l.Count)];
                    response = new Response()
                    {
                        Key = istrue ? competence : null,
                        Value = travelhelp.Value,
                        BotBegin = false,
                        Search = search
                    };
                    response.Key = string.IsNullOrEmpty(competence) ? response.Key : competence;
                    listResponse.Add(response);
                }
            }
            return response;
        }

        
        [HttpPost]
        public ActionResult  ChatBody(Response response)
        {
            try
            {
                var search = Request.Form["search"];

                if (!string.IsNullOrEmpty(search))
                {
                    response = GetResult(search);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }
            
            return View(listResponse);
           
        }

        //le client utilise cette methode
        [HttpPost]
        public JsonResult GenerateQuestion(Response response)
        {
            try
            {
                list = list.Count> 0? list : db.TravelHelps.ToList().Where(f => !string.IsNullOrEmpty(f.Key)).OrderBy(f=> f.Key).ToList();
                System.Threading.Thread.Sleep(500);
                var nber = (new Random()).Next(0, list.Count);
                var travelhelp = list[nber];
                response = new Response()
                {
                    Key = travelhelp.Key,
                };
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }


            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PreChatBot(Response response)
        {
            try
            {
                var search = Request.Form["search"];

                if (!string.IsNullOrEmpty(search))
                {
                    response =new Response() {
                         Search = search,
                          Value = "icon"
                    };
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }

            return View(response);

        }

        [HttpPost]
        public async Task<JsonResult> ReadAudio(Response response)
        {
            Task<JsonResult> task = null;
            try
            {
                var text = Request.Form["text"];


                task = Task.Run(() =>
                {
                    using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
                    {
                        speechSynthesizer.Speak(text);
                        return Json(text, JsonRequestBehavior.AllowGet);
                    }
                });
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }


            return await task;
        }


        [HttpPost]
        public ActionResult SingleChatBot(Response response)
        {
            try
            {
                var search = Request.Form["search"];
                response = new Response()
                {
                    Search = search
                };
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }

            return View(response);

        }

     
      

        public  List<string> SplitPhrase( string search)
        {
            var param = new char[] { ' ', ',', ';', '!', '?', '.' };
            var list = search.Split(param).ToList();
            return list;
        }

        public ActionResult ChatBody()
        {
            return View(listResponse);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var result = new List<TravelHelp>();
            try
            {
                 result = db.TravelHelps.ToList();

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}