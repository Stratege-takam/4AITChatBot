﻿using Chatbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Speech.Synthesis;

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
                list = db.TravelHelps.ToList().Where(f => !string.IsNullOrEmpty(f.Key)).ToList();
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
                    //Il est propable que le fait (question)  qui contient plus de mot de l'utilisateur
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
                    System.Threading.Thread.Sleep(500);
                    response = new Response()
                    {
                        Key = null,
                        BotBegin = false,
                        Value = ListNotResult[(new Random()).Next(0, ListNotResult.Count)],
                        Search = search
                    };
                    listResponse.Add(response);
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