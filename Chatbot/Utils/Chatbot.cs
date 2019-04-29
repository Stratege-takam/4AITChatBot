using Chatbot.Models;
using Chatbot.Models.SE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Utils
{
    public static class Chatbot
    {

        // liste des mots sans pronom et adjectifs
        public static List<string> WordswithoutPronoun(this string search)
        {
            var l = search.SplitPhrase();
            var results = new List<string>();
            foreach (var item in l)
            {
                if(!Articles.Any(f=> f.ToLower() == item.ToLower()))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        //decoupage de la phrase en une liste sans pontuation et espace
        public static List<string> SplitPhrase(this string search)
        {
            var param = new char[] { ' ', ',', ';', '!', '?', '.'};
            var list = search.Split(param).ToList();
            
            return list;
        }




        // recuper la liste des articles
        public static List<string> Articles => new List<string>()
        {
           "je", "me", "m’", "moi", "tu", "te", "t’",
           "toi", "nous", "vous", "il", "elle", "ils", "elles", "se", "en", "y",
           "le", "la", "l’", "les", "lui", "soi", "leur", "eux", "lui", "leur",
           "celui", "celui-ci", "celui-là", "celle", "celle-ci", "celle-là",
           "ceux", "ceux-ci", "ceux-là", "celles", "celles-ci", "celles-là",
           "ce", "ceci", "cela", "ça","cet","cette","des","ses","tes","ces",
           "mes","mon","ton","son","nos","vos","que","quelles","quel","quels",
           "quelle","comment",
           "mien", "tien", "sien", "mienne", "tienne", "sienne",
           "miens", "tiens","siens" , "miennes", "tiennes", "siennes",
           "nôtre", "vôtre","leur", "nôtre", "vôtre", "leur",
            "nôtres", "vôtres", "leurs","dont", "où",
            "qui", "que", "quoi", "qu'","est-ce",
            "lequel", "auquel", "duquel", "laquelle", "à", "laquelle", "de", "laquelle",
            "lesquels", "auxquels", "desquels", "lesquelles", "auxquelles", "desquelles",
            "on","tout","un", "une", "l'","un", "l'","une", "les", "uns", "les", "unes",
             "autre" , "d'","autres", "l'","autre", "les","autres",
             "aucun", "aucune", "aucuns", "aucunes",
            "certains", "certaine", "certains", "certaines",
            "tel", "telle", "tels", "telles" , "tout", "toute", "tous", "toutes",
            "le", "même", "la","même", "les", "mêmes",  "nul", "nulle", "nuls", "nulles",
            "quelqu'un", "quelqu'une" , "quelques" ,"uns", "quelques" ,"unes",
            "aucun", "autrui", "quiconque","pourquoi","en",
            "d’aucuns","mais", "donc","or", "ni", "car", "alors"
        };

        //liste des qualificateurs
        public static List<string> Qualificators => new List<string>()
        {
           "et","ou","conjoint","disjoint","avec","plus"
        };

        // recuperation de liste des synonymes et la parcourir,associé chaque mot
        //du decoupage à un thème

         // liste des domaines contenus dans le mot
        public static List<string> AllDomainWorldsInPhrase(this List<string> worlds)
        {
            var list = new List<string>();

            using (var db = new ChatbotContext())
            {
                var l = db.Facts.ToList().OrderBy(f => f.Question.Length).ToList();
                foreach (var item in worlds)
                {
                    if (l.Any(f=>item.ToLower().Trim().Contains(f.Question.ToLower().Trim())))
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        // liste des domaines groupés

        public static List<Response> AllDomainWorldsGroup()
        {
            var list = new List<Response>();

            using (var db = new ChatbotContext())
            {
                list.Add(new Response()
                {
                    Search = "Vehicule",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id>93 && f.Id<118).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Reservation|Participant",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 58 && f.Id < 66).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Reservation|Standard",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 72 && f.Id < 79).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Reservation",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 63 && f.Id < 73).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Escale",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 117 && f.Id < 130).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Voyage",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 54 && f.Id < 85).Select(f => f.Question).ToList()
                });

                list.Add(new Response()
                {
                    Search = "Trajet",
                    results = db.Facts.ToList().Where(f => f.Name.Contains("FS") && f.Id > 129 && f.Id < 155).Select(f => f.Question).ToList()
                });


            }
            return list;
        }

        //recuperer les resultats en fonction du domaine
        public static List<string> GetResult(List<string> worlds)
        {
            var list = new List<string>();
            var domaines = AllDomainWorldsGroup();
            var response = new Response();
            using (var db = new ChatbotContext())
            {
                foreach (var item in worlds)
                {
                    //cas de vehicule
                    response = domaines.FirstOrDefault(f => f.Search == "Vehicule");
                    //si le mot correspond à un synonym de vehicule
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Participant
                    response = domaines.FirstOrDefault(f => f.Search == "Reservation|Participant");
                    //si le mot correspond à un synonym de particpant
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Standard
                    response = domaines.FirstOrDefault(f => f.Search == "Reservation|Standard");
                    //si le mot correspond à un synonym de standard
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Reservation
                    response = domaines.FirstOrDefault(f => f.Search == "Reservation");
                    //si le mot correspond à un synonym de Reservation
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Escale
                    response = domaines.FirstOrDefault(f => f.Search == "Escale");
                    //si le mot correspond à un synonym de Escale
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Voyage
                    response = domaines.FirstOrDefault(f => f.Search == "Voyage");
                    //si le mot correspond à un synonym de Voyage
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }

                    //cas de Trajet
                    response = domaines.FirstOrDefault(f => f.Search == "Trajet");
                    //si le mot correspond à un synonym de Trajet
                    if (response.results.Any(f => item.ToLower().Trim().Contains(f.ToLower().Trim())))
                    {

                    }
                }
               
            }
            return list;
        }


        public static List<TravelHelp> GetTravel()
        {
            List<TravelHelp> travelHelps = new List<TravelHelp>();
            
            using(var db = new ChatbotContext())
            {
                var vehicules = db.Vehicles.ToList();
                var travels = db.Travels.ToList();
                var paths = db.Paths.ToList();
                var stops = db.Stops.ToList();
                var reservations = db.Reservations.ToList();
                foreach (var vehicle in vehicules.ToList())
                {
                    var tvels = travels.
                                    Where(f => f.TransportId == vehicle.Id).ToList();

                    foreach (var travel in tvels)
                    {
                        var travelhelp = new TravelHelp()
                        {
                           Travel = travel,
                           Path = vehicle.Path,
                           Vehicle = vehicle,
                           Reservations = reservations.Where(f=> f.TravelId == travel.Id).ToList(),
                           Stops = stops.Where(f=> f.PathId == vehicle.PathId).ToList()
                        };
                        travelHelps.Add(travelhelp);
                    }

                }
            }
            return travelHelps;
        }

    }
}