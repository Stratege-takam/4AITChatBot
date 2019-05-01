using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chatbot;
using Chatbot.Models;

namespace Chatbot.Controllers
{
    public class TravelHelpsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();
        

        // GET: TravelHelps
        public async Task<ActionResult> Index()
        {
            //foreach (var item in this.getHelp())
            //{
            //    db.TravelHelps.Add(item);
            //    db.SaveChanges();
            //}
            //var sh = @"D:\M.Sc.1\4AIT\projet\Chatbot\Chatbot\Content\data\reservation.txt";
            //var path = Server.MapPath("~/Content/data/texte.txt");
            //var lines = System.IO.File.ReadLines(path);
            //foreach (var item in lines)
            //{
            //    var elt = item.Split(':');
            //    db.TravelHelps.Add(new TravelHelp()
            //    {
            //        Key = elt.First(),
            //        Value = elt.Last()
            //    });
            //    db.SaveChanges();
            //}
            // path = Server.MapPath("~/Content/data/TransportRutier.txt");
            // lines = System.IO.File.ReadLines(path);
            //foreach (var item in lines)
            //{
            //    var elt = item.Split(':');
            //    db.TravelHelps.Add(new TravelHelp()
            //    {
            //        Key = elt.First(),
            //        Value = elt.Last()
            //    });
            //    db.SaveChanges();
            //}
            return View(await db.TravelHelps.ToListAsync());
        }

        // GET: TravelHelps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelHelp travelHelp = await db.TravelHelps.FindAsync(id);
            if (travelHelp == null)
            {
                return HttpNotFound();
            }
            return View(travelHelp);
        }

        // GET: TravelHelps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelHelps/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Key,Value")] TravelHelp travelHelp)
        {
            if (ModelState.IsValid)
            {
                db.TravelHelps.Add(travelHelp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(travelHelp);
        }

        // GET: TravelHelps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelHelp travelHelp = await db.TravelHelps.FindAsync(id);
            if (travelHelp == null)
            {
                return HttpNotFound();
            }
            return View(travelHelp);
        }

        // POST: TravelHelps/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Key,Value")] TravelHelp travelHelp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelHelp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(travelHelp);
        }

        // GET: TravelHelps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelHelp travelHelp = await db.TravelHelps.FindAsync(id);
            if (travelHelp == null)
            {
                return HttpNotFound();
            }
            return View(travelHelp);
        }

        // POST: TravelHelps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TravelHelp travelHelp = await db.TravelHelps.FindAsync(id);
            db.TravelHelps.Remove(travelHelp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<TravelHelp> getHelp()
        {
            return new List<TravelHelp>()
            {
               new TravelHelp()
               {
                   Key="Combien de temps à l'avance dois-je rester à l'arrêt ?",
                   Value="Le bus ou le tram peut parfois être un peu en avance. C'est pourquoi nous vous recommandons " +
                   "d'arriver à l'arrêt cinq minutes avant l'heure de passage.",
               } ,
               new TravelHelp()
               {
                   Key="Comment dois-je lire les horaires à l'arrêt ?",
                   Value="Les horaires aux arrêts sont des tableaux de passage. " +
                   "Les heures indiquées sont celles" +
                   " auxquelles le bus ou le tram arrive à l'arrêt concerné.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je prendre des rollers ou un skate dans le tram ?",
                   Value="Non. Si vous portez des rollers ou si vous vous trouver" +
                   " sur un skate, vous n'avez pas de contact avec le sol si le chauffeur doit freiner brusquement." +
                   " C'est pourquoi ils sont interdits dans le bus ou le tram.",
               } ,
               new TravelHelp()
               {
                   Key="Comment dois-je lire les horaires à l'arrêt ?",
                   Value="Les horaires aux arrêts sont des tableaux de passage. Les heures indiquées sont cel" +
                   "les auxquelles le bus ou le tram arrive à l'arrêt concerné.",
               } ,
               new TravelHelp()
               {
                   Key="Comment puis-je arrêter le bus ou le tram à un arrêt ?",
                   Value="Lorsque vous vous trouvez à un arrêt, levez " +
                   "votre main lorsque vous voyez le bus. Ainsi, " +
                   "le chauffeur sait que vous voulez monter car à " +
                   "certains arrêts, plusieurs bus passent. ",
               } ,
               new TravelHelp()
               {
                   Key="Où dois-je monter dans le bus ou le tram ?",
                   Value="En ce qui concerne le bus, vous devez " +
                   "obligatoirement monter à l'avant. Cette obligation " +
                   "ne s'applique pas aux personnes qui se déplacent avec " +
                   "une poussette, un déambulateur à roues ou un fauteuil " +
                   "roulant. Dans ce cas, nous vous recommandons de faire " +
                   "savoir au chauffeur que vous voulez monter par une autre " +
                   "porte. De grands pictogrammes au-dessus ou sur les portes" +
                   " indiquent à quel endroit vous pouvez monter et descendre.",
               } ,
               new TravelHelp()
               {
                   Key="Où dois-je descendre du bus ou du tram ?",
                   Value="Dans le bus, de grands pictogrammes" +
                   " au-dessus ou sur les portes indiquent à" +
                   " quel endroit vous pouvez descendre. " +
                   "D'une manière générale, vous ne devez " +
                   "pas descendre à l'avant. Dans un tram, " +
                   "vous pouvez descendre à toutes les portes." +
                   "Pour des raisons de sécurité, vous ne pouvez " +
                   "descendre qu'à un arrêt. Il est interdit de descendre entre deux arrêts.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je prendre mon animal domestique dans le bus ou le tram ?",
                   Value="Un chien peut voyager gratuitement avec son maître en bus ou en " +
                   "tram. Cependant, vous devez le tenir en laisse et le placer sur vos genoux " +
                   "ou par terre. Si nécessaire, vous devez utiliser une muselière. Les autres " +
                   "petits animaux (par ex. chat, hamster) peuvent voyager avec vous s'ils sont " +
                   "en cage. Le chauffeur peut toujours refuser les animaux en cas de grande affluence ou s'ils gênent les autres voyageurs.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je prendre mon vélo dans le bus ou le tram ?",
                   Value="Les simples vélos ne peuvent pas être emportés" +
                   " dans le bus ou le tram. Si vous ne dérangez pas les " +
                   "autres voyageurs, vous pouvez cependant emporter un " +
                   "vélo pliant.Seul le Tram du littoral vous permet " +
                   "d'emporter un vélo moyennant paiement. Pour ce " +
                   "faire, achetez un billet spécial vélo. " +
                   "2 à 3 vélos peuvent être emportés dans chaque Tram du littoral.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je prendre des bagages dans le bus ou le tram ?",
                   Value="Les bagages à main (maximum 2 valises de taille normale), " +
                   "poussettes, fauteuils roulants, " +
                   "caddies et autres peuvent être emportés gratuitement. " +
                   "Le chauffeur peut toujours refuser des bagages en cas " +
                   "de grande affluence ou lorsqu'ils gênent les autres voyageurs.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je prendre des rollers ou un skate dans le tram ?",
                   Value="Non. Si vous portez des rollers ou si vous vous trouver " +
                   "sur un skate, vous n'avez pas de contact avec le sol si le chauffeur " +
                   "doit freiner brusquement. C'est pourquoi ils sont interdits dans le bus ou le tram.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je écouter de la musique dans le bus ou le tram " +
                   "(par ex. sur un gsm ou un lecteur mp3) ?",
                   Value="Vous pouvez profiter sans problème " +
                   "de votre musique dans le bus ou le tram " +
                   "mais ne mettez pas le volume trop fort. " +
                   "Ce ne sera pas uniquement bon pour votre " +
                   "audition mais également pour l'humeur des autres voyageurs.",
               } ,
               new TravelHelp()
               {
                   Key="Puis-je fumer dans les abris et les véhicules de De Lijn ?",
                   Value="Non. L'interdiction de fumer est générale :" +
                   "dans les véhicules de De Lijndans les abris (abri-bus) " +
                   "de De Lijndans les espaces couverts de De Lijn (par ex. à un arrêt de bus)",
               } ,
               new TravelHelp()
               {
                   Key="Où puis-je m'adresser pour les objets trouvés ?",
                   Value="Si vous avez oublié ou perdu quelque chose dans " +
                   "le bus ou le tram, vous pouvez contacter De LijnInfo par " +
                   "téléphone au 070 220 200 (0,30 euro/min).Si vous n'avez " +
                   "pas de nouvelles dans les 14 jours ouvrables après votre appel, " +
                   "cela signifie malheureusement que l'objet n'a pas été trouvé.",
               } ,
               new TravelHelp()
               {
                   Key="Qu'est-ce que la mobilité de base ?",
                   Value="La mobilité de base offre à chaque habitant de Flandre un " +
                   "service minimum des transports publics.",
               } ,
               new TravelHelp()
               {
                   Key="Qu'est-ce que la gestion de réseau ?",
                   Value="La gestion de réseau est une méthode permettant " +
                   "d'optimiser le réseau des bus et des trams. " +
                   "Elle vise une offre optimale des transports publics en " +
                   "fonction de la demande.",
               } ,
               new TravelHelp()
               {
                   Key="Comment De Lijn travaille-t-elle à l'accessibilité ?",
                   Value="Nous voulons que tout le monde puisse utiliser nos " +
                   "services. De Lijn prend donc de nombreuses mesures et initiatives " +
                   "pour rendre son offre plus accessible.",
               } ,
               new TravelHelp()
               {
                   Key="De Lijn entretient-elle son matériel historique ?",
                   Value="Oui, par le biais du Vlaams Tram- en AutobusMuseum " +
                   "(Vlatam ou Musée flamand du Tram et de l'Autobus). Il s'agit d'un musée De Lijn " +
                   "situé à Berchem où vous pouvez admirer, entre autres, d'anciens bus ou trams.",
               } ,
               new TravelHelp()
               {
                   Key="Conseils pour réserver un bus ou un tram facile d'accès",
                   Value="Coordonnées de la centrale busphone <br/>Anvers" +
                   "<br/>Limbourg" +
                   "<br/>Flandre Orientale" +
                   "<br/>Brabant flamand" +
                   "</br>Flandre Occidentale",
               } ,
               new TravelHelp()
               {
                   Key="Comment réserver un transport accessible aux fauteuils roulants ?",
                   Value="Contactez la centrale busphone au moins 2 heures à l'avance (1 heure dans le Limbourg). " +
                   "<ul>" +
                       "<li>" +
                       "Contactez la centrale busphone au moins 2 heures à l'avance (1 heure dans le Limbourg). "+
                       "</li>"+
                        "<li>" +
                        "Indiquez votre nom, votre adresse et votre numéro de téléphone, la date et l'heure de départ, l'arrêt de départ et d'arrivée et le nombre de voyageurs." +
                       "</li>" +
                       "Un collaborateur vérifiera pour vous si le véhicule et l'arrêt sont accessibles. Le collaborateur vérifiera également si la place pour l'utilisateur du fauteuil roulant est encore libre."+
                        "<li>" +
                        "Si la place est encore libre, vous pouvez réserver le trajet." +
                       "</li>"+
                   "</ul>",
               } ,
               new TravelHelp()
               {
                   Key="A quel moment un bus ou un tram est-il considéré comme facile d'accès ?",
                   Value="Un bus ou un tram est facile d'accès si : <ul>" +
                   "<li>" +
                   "il dispose d'un plancher surbaissé ;" +
                   "</li>" +
                   "<li>" +
                   "il est équipé d'une rampe de chargement ;" +
                   "</li>" +
                   "<li>" +
                   "il est équipé d'une plateforme pour les fauteuils roulants." +
                   "</li>" +
                   "</ul>",
               } ,
               new TravelHelp()
               {
                   Key="",
                   Value="",
               } ,
               new TravelHelp()
               {
                   Key="Tous les véhicules De Lijn sont-ils accessibles ?",
                   Value="Non mais nous veillons à ce qu'ils le deviennent. " +
                   "Depuis 2004, De Lijn achète exclusivement des véhicules " +
                   "faciles d'accès. Fin 2013, près de 3 bus sur 4 et 1 tram 3 " +
                   "étaient faciles d'accès. Et avec le récent achat et les " +
                   "adjudications pour de nouveaux véhicules, cette part augmentera " +
                   "encore dans les années à venir.",
               } ,
               new TravelHelp()
               {
                   Key="Coordonnées de la centrale busphone",
                   Value="<ul>" +
                       "<li>Anvers</li>" +
                       "<li>Limbourg</li>" +
                       "<li>Flandre Orientale</li>" +
                       "<li>Brabant flamand</li>" +
                       "<li>Flandre Occidentale</li>" +
                   "</ul>" +
                   "",
               },
               new TravelHelp()
                   {
                       Key="Comment puis-je obtenir un abonnement ?",
                       Value="<ul>" +
                       "<li>Lijnwinkel : dans le Lijnwinkel, vous recevez votre abonnement sur " +
                       "présentation de votre carte d'identité et après paiement</li>" +
                       "<li>En ligne : si vous disposez d'une carte d'identité électronique " +
                       "et d'un lecteur de e-ID, vous pouvez commander votre abonnement en ligne. " +
                       "Attention : les familles en coparentalité qui peuvent bénéficier d'une " +
                       "remise pour familles nombreuses pour le Buzzy Pazz ne peuvent pas commander " +
                       "leur abonnement en ligne. La remise accordée par certaines communes pour " +
                       "une certaine catégorie d'âge ou une date de début de validité donnée " +
                       "n'est pas réglée automatiquement. Pour ce faire, vous devez toujours " +
                       "envoyer l'attestation au service Abonnements. </li>" +
                       "<li>Par écrit : téléchargez le formulaire de demande " +
                       "Buzzy Pazz ou le formulaire de demande Omnipas. Complétez-le et envoyez-le au service " +
                       "Abonnements. N'oubliez pas de joindre une copie de votre carte d'identité</li>" +
                       "<li>Par courrier : envoyez un courrier au service Abonnements avec les nom, adresse, " +
                       "date de naissance, sexe du futur abonné, la date de début souhaitée de l'abonnement " +
                       "et la durée de validité souhaitée (1, 3 ou 12 mois). " +
                       "N'oubliez pas de joindre une copie de votre carte d'identité</li>" +
                       "<li>Par e-mail : envoyez un e-mail au service Abonnements avec vos nom, adresse, date " +
                       "de naissance, sexe, la date de début souhaitée de l'abonnement et la durée de validité " +
                       "souhaitée (1, 3 ou 12 mois). N'oubliez pas de joindre une version scannée de votre carte d'identité</li>" +
                       "<li></li>" +
                       "</ul>"
                   },
               new TravelHelp()
                   {
                       Key="Que dois-je faire pour pouvoir obtenir une remise pour famille nombreuse ?",
                       Value="Tous les abonnements avec remise pour famille nombreuse doivent avoir la même date de début et la même durée de validité. " +
                       "<ul>" +
                            "<li>Tous les abonnements avec remise pour famille nombreuse doivent avoir la même date de début et la même durée de validité. </li>" +
                                "<li>Tous les abonnés vivent-ils officiellement à la même adresse ? Remettez-nous une attestation de composition familiale " +
                                "(datant de 2 mois maximum) lors de la demande concernant vos abonnements. " +
                            "</li>" +
                            "<li>Tous les abonnés ne vivent pas officiellement à la même adresse (coparentalité) ? Remettez-nous une " +
                                "attestation de composition familiale (datant de 2 mois maximum) pour tous les enfants " +
                                "domiciliés chez le parent demandeur. Remettez-nous un acte de naissance, un certificat " +
                                "d'adoption ou un acte de reconnaissance pour tous les enfants qui ne sont " +
                                "pas domicilités chez le parent demandeur.</li>" +
                            "<li></li>" +
                       "</ul>"
                   },
               new TravelHelp()
                   {
                       Key="Je n'ai pas obtenu la remise pour familles nombreuses sur le Buzzy Pazz. Que dois-je faire ?",
                       Value="Vérifiez que vous avez remis une attestation de la composition " +
                       "de votre famille (datant de max. 2 mois) à De Lijn. " +
                       "Tenez compte du fait que la remise s'applique uniquement " +
                       "aux abonnements ayant une même date de début et une même durée " +
                       "de validité. "
                   },
               new TravelHelp()
                   {
                       Key="Quand ai-je droit à un abonnement gratuit ou à un abonnement à tarif réduit ?",
                       Value="Dans certaines conditions, vous pouvez acheter " +
                       "un abonnement à tarif réduit ou vous avez droit vous-même à " +
                       "un abonnement gratuit. Consultez le récapitulatif des remises pour savoir si vous y avez droit."
                   },
               new TravelHelp()
                   {
                       Key="Combien coûte un duplicata ?",
                       Value="Un duplicata coûte 10 euros, quel que soit le nombre de duplicatas que vous avez demandés."
                   },
               new TravelHelp()
                   {
                       Key="Que faire si j'ai perdu mon abonnement ou s'il a été volé ?",
                       Value="<ul>" +
                       "<li>Lijnwinkel : Dans le Lijnwinkel, " +
                           "après paiement des frais administratifs et signature d'une " +
                           "déclaration écrite de vol ou de perte, vous obtenez " +
                           "immédiatement un duplicata.</li>" +
                       "<li>Services Abonnements : Envoyez une déclaration écrite indiquant le nom, " +
                       "l'adresse, la date de naissance, le type d'abonnement et la raison de la demande " +
                       "de duplicata au service Abonnements. Vous pouvez également imprimer le formulaire " +
                       "de demande de duplicata et l'envoyer une fois complété. Vous recevrez alors un " +
                       "ordre de virement. Après réception " +
                       "de votre paiement, le service Abonnements envoie votre duplicata.</li>" +
                       "<li></li>" +
                       "<li></li>" +
                       "</ul>"
                   },
               new TravelHelp()
                   {
                       Key="Que dois-je faire si mon abonnement est endommagé ou si " +
                       "les informations sur mon abonnement sont devenues illisibles ?",
                       Value="Vous pouvez demander un duplicata par le biais du Lijnwinkel " +
                       "ou du Service Abonnements (voir 'Comment demander un duplicata de mon " +
                       "abonnement ?'). Si les informations essentielles (nom, date de naissance, " +
                       "adresse, durée de validité et numéro de client) sont encore lisibles, " +
                       "votre abonnement est remplacé gratuitement."
                   },
               new TravelHelp()
                   {
                       Key="Que dois-je faire si mon abonnement est endommagé ou si les " +
                       "informations sur mon abonnement sont devenues illisibles ?",
                       Value="Vous pouvez demander un duplicata par le biais du " +
                       "Lijnwinkel ou du Service Abonnements (voir 'Comment demander un " +
                       "duplicata de mon abonnement ?'). Si les informations essentielles" +
                       " (nom, date de naissance, adresse, durée de validité et numéro de " +
                       "client) sont encore lisibles, votre abonnement est remplacé gratuitement."
                   },
               new TravelHelp()
               {
                   Key="Comment puis-je modifier les informations de mon abonnement ?",
                   Value="En tant qu'abonné, vous devez communiquer immédiatement à De " +
                   "Lijn tout changement d'adresse ou d'identité. Vous pouvez contacter le service Abonnements " +
                   "par courrier ou par e-mail pour transmettre la modification. Vous pouvez aussi passer ans un Lijnwinkel " +
                   "pour faire remplacer votre abonnement. " +
                   "Cependant, l'abonnement avec l'ancienne adresse reste valide."
               },
               new TravelHelp()
               {
                   Key="Puis-je plastifier mon abonnement ?",
                   Value="Non. Vous devez présenter le titre de transport original en cas de contrôle."
               },
               new TravelHelp()
               {
                   Key="Puis-je être remboursé si je rends mon abonnement ?",
                   Value="Seuls les abonnements d'une durée de 3 et 12 mois peuvent être pris en considération pour un remboursement. " +
                   "Un abonnement mensuel n'est pas remboursé. 10 euros de frais administratifs sont toujours facturés. Les abonnements à tarif réduit " +
                   "(abonnement Intervention majorée, abonnement GT, Buzzy Pazz pour les 6 à 12 ans et Omnipas 65+) ne sont pas remboursés. " +
                   "Pour avoir plus de detail veillez consultez https://www.delijn.be/fr/contact/faq-detail.html?v=2854"
               },
               new TravelHelp()
               {
                   Key="Où dois-je remettre mon abonnement pour obtenir un remboursement ?",
                   Value="Pour un remboursement, vous avez les possibilités suivantes :" +
                   "Le service Abonnements.Le Lijnwinkel. " +
                   "Le collaborateur du Lijnwinkel remet votre " +
                   "abonnement au service Abonnements et ne vous rembourse donc rien."
               },
               new TravelHelp()
               {
                   Key="Suis-je remboursé si je restitue mon Omnipas 65+ ?",
                   Value="Un abonnement Omnipas 65+ n'est pas remboursé, sauf en cas de décès de l'abonné."
               },
               new TravelHelp()
               {
                   Key="La période de validité de ma carte MOBIB a expiré. Que dois-je faire ?",
                   Value="Vous pouvez encore utiliser la carte MOBIB expirée jusqu'au prochain " +
                   "renouvellement de votre abonnement. À la prochaine proposition de renouvellement " +
                   "d'un abonnement, vous devrez à nouveau payer 5 euros de frais administratifs pour " +
                   "votre nouvelle carte MOBIB.Attention ! Vous ne pouvez pas charger de nouveaux produits sur une carte expirée. "
               },
               new TravelHelp()
               {
                   Key="Quelles personnes handicapées ont droit à des transports gratuits chez De Lijn ?",
                   Value="<ul>" +
                       "<li>Les personnes handicapées qui sont inscrites à la Vlaams Agentschap voor Personen met een Handicap (VAPH)</li>" +
                       "<li>Les personnes handicapées qui perçoivent une intervention du Service public fédéral de la Sécurité sociale (SPF SS) " +
                       "et qui sont domiciliées en Flandre</li>" +
                       "<li>Les personnes handicapées qui ont droit aux BTOM " +
                       "(Bijzondere TewerkstellingsOndersteunende Maatregelen</li>" +
                   "Les enfants de moins de 6 ans ne sont jamais communiquées à De " +
                   "Lijn car ils voyagent gratuitement de toute façon." +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="D'autres catégories de personnes handicapées ont-elles également droit à des avantages chez De Lijn ?",
                   Value="Toute personne ayant un statut VIPO/OMNIO peut acheter des titres de transport à un tarif réduit :" +
                   "<ul>" +
                   "<li>Omnipas ou Buzzy Pazz de 12 mois à tarif réduit</li>" +
                   "<li>Lijnkaart % pour 8 euros (en prévnte)</li>" +
                   "Ces titres de transport à tarif réduit sont remis sur présentation d'une attestation VIPO/OMNIO de " +
                   "la mutuelle. Si vous avez une Carte d'Intervention majorée de la SNCB, vous n'avez pas à fournir d'attestation." +
                   " Une copie de la Carte d'Intervention majorée et de votre carte d'identité suffit. " +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="D'autres catégories de personnes handicapées ont-elles également droit à des avantages chez De Lijn ?",
                   Value="Toute personne ayant un statut VIPO/OMNIO peut acheter des titres de transport à un tarif réduit :" +
                   "<ul>" +
                        "<li>Omnipas ou Buzzy Pazz de 12 mois à tarif réduit </li>" +
                        "<li>Lijnkaart % pour 8 euros (en prévnte)</li>" +
                       "Ces titres de transport à tarif réduit sont remis sur présentation " +
                       "d'une attestation VIPO/OMNIO de la mutuelle. Si vous avez une Carte " +
                       "d'Intervention majorée de la SNCB, vous n'avez pas à fournir d'attestation. " +
                       "Une copie de la Carte d'Intervention majorée et de votre carte d'identité suffit. " +
                       "Vous pouvez acheter le titre de transport dans le Lijnwinkel ou le demander par " +
                       "le biais du service Abonnements." +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="Où l'abonnement gratuit pour personnes handicapées est-il valide ?",
                   Value="L'abonnement est valide uniquement dans les véhicules " +
                   "De Lijn (donc apas pour la STIB ou le TEC)."
               },
               new TravelHelp()
               {
                   Key="Que faire pour obtenir un abonnement gratuit au réseau pour personnes handicapées ?",
                   Value="Rien. Cet abonnement vous est envoyé automatiquement à domicile. Selon votre âge, " +
                   "vous recevrez un BuzzyPazz (-25 ans) ou un Omnipas (25-64 ans)."
               },
               new TravelHelp()
               {
                   Key="Que dois-je faire si j'ai encore un abonnement payant ?",
                   Value="Remettez l'abonnement au service Abonnements. La valeur " +
                   "restante vous sera remboursée selon la réglementation générale en vigueur. " +
                   "Un abonnement au réseau VG n'est pas remboursé."
               },
               new TravelHelp()
               {
                   Key="Que faire si je n'ai pas reçu l'abonnement gratuit au réseau pour personnes handicapées ?",
                   Value="Contactez le service Abonnements " +
                   "ou passez dans le Lijnwinkel. " +
                   "Ils vérifieront que vos " +
                   "informations ont été transmises." +
                   "Si De Lijn a reçu vos informations, " +
                   "un problème s'est produit lors de la " +
                   "remise de l'abonnement. Nous vous enverrons " +
                   "gratuitement un nouvel abonnement. Vous obtiendrez " +
                   "un titre de transport provisoire au Lijnwinkel." +
                   "Si nous n'avons pas reçu vos informations, " +
                   "vous devrez contacter l'institution qui a reconnu " +
                   "le handicap (le SPF SS ou la VAPH)."
               },
               new TravelHelp()
               {
                   Key="Que faire si aucun abonnement n'était joint au courrier de De Lijn ?",
                   Value="Une erreur s'est probablement produite lors de l'envoi. " +
                   "Contactez le service Abonnements. Ils vérifieront quelle erreur " +
                   "s'est produite et ils rechercheront une solution adaptée."
               },
               new TravelHelp()
               {
                   Key="Que faire si j'ai reçu 2 courriers avec à chaque fois un abonnement ?",
                   Value="Contactez le service Abonnements. Ils vérifieront quel numéro de carte est enregistré dans le fichier clients et est donc valide. Vous devez retourner l'autre à De Lijn."
               },
               new TravelHelp()
               {
                   Key="Que faire si je déménage ou si mes coordonnées postales ne sont pas correctes sur la carte ?",
                   Value="En tant qu'abonné, vous devez communiquer immédiatement à De Lijn tout changement d'adresse ou " +
                   "d'identité. Vous pouvez contacter le service Abonnements par courrier ou par e-mail pour transmettre la " +
                   "modification. Vous pouvez aussi passer dans un Lijnwinkel pour faire remplacer votre abonnement. Cependant, " +
                   "l'abonnement avec l'ancienne adresse reste valide."
               },
               new TravelHelp()
               {
                   Key="Que dois-je faire si ma date de naissance et/ou mon nom ne sont pas " +
                   "correctement indiqué s sur mon abonnement pour personnes handicapées ?",
                   Value="Contactez la VAPH ou le SPF SS. Ils corrigeront vos informations " +
                   "personnelles et les transmettront à De Lijn avec la mise à jour mensuelle. " +
                   "De Lijn créera alors une nouvelle carte Omnipas/Buzzy Pazz. " +
                   "Renvoyez l'abonnement avec les informations erronées au "
               },
               new TravelHelp()
               {
                   Key="Que dois-je faire si j'ai perdu mon abonnement, s'il a été volé, endommagé ou détruit ?",
                   Value="<ul>" +
                       "<li>Lijnwinkel : Dans le Lijnwinkel, après paiement des frais administratifs et signature d'une déclaration écrite de vol ou de perte, " +
                       "vous obtenez immédiatement un duplicata.</li>" +
                       "<li>Services Abonnements : Envoyez une déclaration écrite indiquant le nom, l'adresse, la date de naissance, le type " +
                       "d'abonnement et la raison de la demande de duplicata au service Abonnements. Vous pouvez également imprimer le formulaire de " +
                       "demande de duplicata et l'envoyer une fois complété. Vous recevrez alors un ordre de virement. Après réception " +
                       "de votre paiement, le service Abonnements envoie votre duplicata.</li>" +
                       "Tant que vous n'avez pas de duplicata, vous devez avoir un titre de transport en règle pour tous vos déplacements. Dans le cas contraire, vous risquez une amende. " +
                       "De Lijn ne rembourse pas ces frais." +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="Que devient l'abonnement si l'abonné est décédé ?",
                   Value="Si l'abonné est décédé, les parents proches doivent l'annuler."
               },
               new TravelHelp()
               {
                   Key="L'abonnement gratuit pour personnes handicapées s'applique-t-il également aux accompagnateurs ou au représentant légal ou tuteur de la personne handicapée ?",
                   Value="L'abonnement pour personnes handicapées est strictement personnel. Cependant, la personne handicapée peut demander un ‘Billet pour Accompagnateur’ par le biais de la SNCB. Ce billet " +
                   "est gratuit et il est également valable pour les véhicules De Lijn."
               },
               new TravelHelp()
               {
                   Key="Qu’est-ce qu’une 'Carte Accompagnateur gratuit'?",
                   Value="" +
                   "Vous voyagez avec l'aide d'une personne ou de votre chien. Avec la 'Carte accompagnateur gratuit' " +
                   "votre guide vous assiste sans payer le voyage." +
                   "<ul>" +
                       "<li>Sur présentation de la carte spéciale, votre accompagnateur voyage gratuitement</li>" +
                       "<li>Pas de billet, votre titre de transport personnel payant vaut pour votre accompagnateur</li>" +
                       "<li>L’accompagnateur voyage dans la même classe et sur le même trajet que vous </li>" +
                       "La durée de validité de la carte correspond à celle indiquée sur votre certificat soumis, " +
                       "avec une durée maximale de cinq ans. La 'Carte accompagnateur gratuit' est délivré par la SNCB. " +
                       "Vous trouverez plus d'informations sur le site Web de la SNCB." +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="Quelles sont les conditions d'attribution d'une Carte Accompagnateur gratuit?",
                   Value="Vous avez droit au Carte Accompagnateur gratuit si vous ne pouvez pas voyager seul pour l'une des raisons suivantes: " +
                   "<ul>" +
                    "<li>Une perte d'autonomie d'au moins 12 points selon le manuel d'évaluation du degré d'autonomie</li>" +
                    "<li>Une invalidité permanente ou une incapacité de travail d'au moins 80% </li>" +
                    "<li>Une invalidité permanente directement imputable aux membres inférieurs d'au moins 50% </li>" +
                    "<li>Une paralysie complète ou une amputation des membres supérieurs</li>" +
                    "<li>Une intervention d'intégration de catégorie III ou supérieure</li>" +
                   "</ul>"
               },
               new TravelHelp()
               {
                   Key="J'ai un abonnement gratuit pour personnes handicapées mais je ne souhaite pas l'utiliser. Que dois-je faire ?",
                   Value="Vous pouvez renvoyer l'abonnement au Service des Abonnements. Indiquez également à l'institution d'agrément (la VAPH ou le SPF SS) " +
                   "que vous ne souhaitez pas utiliser l'abonnement gratuit. " +
                   "Si vous voulez tout de même utiliser l'abonnement gratuit plus tard, vous devez contacter la VAPH ou le SPF SS."
               },
                 new TravelHelp()
                {
                    Key = "Quelles sont les règles à respecter pour prendre un bus ? ",
                    Value = "Pour faciliter les trajets DELIJN pour tous, quelques bonnes pratiques sont à respecter quand vous prenez le bus. Par exemple" +
                    "<ul>" +
                    "<li>" +
                     "Pour prendre le bus, lorsqu’il approche de son arrêt, placez-vous bien en évidence et faites signe au conducteur" +
                    "</li>" +
                     "<li>" +
                    "Validez votre titre de transport lorsque vous montez à bord (même en correspondance)" +
                    "</li>" +
                     "<li>" +
                    "Si vous devez acheter un ticket de dépannage à bord du bus, préparez si possible le montant exact. Dans tous les cas, le conducteur ne pourra pas vous rendre la monnaie au-dessus de 10 €" +
                    "</li>" +
                    "</ul>"
                },
                 new TravelHelp()
                {
                    Key = "Puis-je transporter mon vélo à bord du bus ?",
                    Value = "Oui, s’il s’agit d’un vélo pliable et qu’il est replié et à condition qu’il ne puisse blesser, salir ou incommoder les voyageurs." +
                    "<br>" +
                    "Non, s’il s’agit d’un autre type de vélo."
                },
                new TravelHelp()
                {
                    Key = "Puis-je prendre un transport DELIJN avec mon animal de compagnie ?",
                    Value = "Oui, vous pouvez emprunter un transport DELIJN avec votre animal de compagnie à condition qu’il ne représente pas une source de désagréments pour les autres voyageurs"
                },
                new TravelHelp()
                {
                    Key = "Quels sont les risques si je voyage sans titre de transport valable ?",
                    Value = "Si vous voyagez sans titre de transport valable, avec un titre à tarif réduit alors que vous n’y avez pas droit, ou si vous voyagez au-delà des limites géographiques de votre titre de transport, vous êtes passible d'une amende de :" +
                    "<ul class='list-group'>" +
                    "<li class='list-group-item list-group-item-danger'>" +
                    "75 € en cas de première infraction (excepté si le prix du transport majoré de frais administratifs de 50 € est payé dans les 10 jours suivant l’infraction)" +
                    "</li>" +
                     "<li class='list-group-item list-group-item-danger'>" +
                     "150 € en cas de deuxième infraction " +
                    "</li>" +
                     "<li class='list-group-item list-group-item-danger'>" +
                     "300 € pour les infractions suivantes" +
                    "</li>" +
                     "</ul>" +
                    "<br>" +
                     "Si vous voyagez avec un titre de transport falsifié ou si vous utilisez le titre de transport nominatif d'une autre personne, vous serez passible d'une amende administrative de 300 €" +
                    "<br>" +
                    "<Si vous ne validez pas votre titre de transport, vous vous exposez à des frais administratifs de 10 €.>"
                },
                new TravelHelp()
                {
                    Key = "Comment puis-je payer ma m-card10 ?",
                    Value = "Vous pouvez payer votre m-card10 par Bankcontact, Visa ou MasterCard. Si vous voulez payer par Bankcontact, veillez à ce que l'appli correspondante ou l'appli de votre banque ait été installée sur votre smartphone"
                },
                new TravelHelp()
                {
                    Key = "Que faire si j'achète un nouvel appareil ? Ai-je perdu ma m-card10 ?",
Value = "Si vous achetez un nouveau smartphone, vous ne perdez pas votre m-card10. Cependant, vous devez faire réinitialiser le numéro de gsm afin que la carte ne soit plus associée à l'id de votre ancien appareil. Pour ce faire, contactez-nous par l'intermédiaire du formulaire de contact. Dans votre message, indiquez votre ancien numéro de gsm. "+
                        "Dès que notre service clientèle vous a informé que la réinitialisation a été effectuée, vous pouvez réutiliser votre m-card10 : "+
                        "Si vous avez conservé votre ancien numéro de téléphone, il suffit d'installer l'appli et d'acheter une nouvelle m-card10. Dès que vous entrez et confirmez votre numéro de GSM, la m-card10 avec les trajets restants s'affiche à nouveau dans l'appli."+
                        "Vous avez un nouveau numéro de téléphone? Dans ce cas, installez l'appli sur votre nouvel appareil et indiquez votre ancien numéro de GSM. Ensuite, la m-card10 avec les trajets restants s'affichera à nouveau dans l'appli (sans que vous ayez à payer). Une fois que les trajets de votre m-card10 ont été utilisés et si vous voulez acheter une nouvelle m-card10, introduisez le nouveau numéro de GSM."
                },
                 new TravelHelp()
                {
                    Key = "J'ai commandé une m-card10 par l'intermédiaire de ma tablette. Puis-je activer mes billets sur mon smartphone ?",
                    Value = "Non, ce n'est pas possible. Achetez toujours votre m-card10 avec votre smartphone."
                },
                  new TravelHelp()
                {
                    Key = "Que faire en cas de panne sur le réseau ou si je ne capte pas ?",
                    Value = "Vous ne pouvez pas prendre le bus ou le tram sans titre de transport valide. Si le réseau gsm ne fonctionne pas ou s'il est provisoirement perturbé, vous n'avez pas de titre de transport valide et vous devez donc acheter un autre titre de transport. Dans le cas où vous ne captez pas également, vous devez acheter un autre titre de transport."
                },
                  new TravelHelp()
                {
                    Key = "Que se passe-t-il si j'ai un billet valide mais que la batterie de mon smartphone est vide au moment du contrôle ?",
                    Value = "Si votre smartphone tombe en panne après votre montée dans le véhicule, le contrôleur peut effectuer un contrôle en ligne. Il vérifie alors si un billet a été activé avec votre smartphone. Dans ce cas, vous êtes obligé de communiquer votre numéro de GSM au contrôleur."
                },
                  new TravelHelp()
                {
                    Key = "Que se passe-t-il si je dois à nouveau installer l'appli ? Ai-je perdu ma m-card10 ?",
                    Value = "Si vous devez à nouveau installer l'appli sur le même appareil, une m-card10 déjà achetée reste valide. En revanche, vous perdez les billets actifs."
                },
                  new TravelHelp()
                {
                    Key = "Quelles informations personnelles dois-je partager pour acheter une m-card10 ?",
                    Value = "QuPour acheter une m-card10, vous devez utiliser votre numéro de GSM. Nous reprenons l'id de votre appareil en tâche de fond également. elles informations personnelles dois-je partager pour acheter une m-card10 ?"
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter une m-card10 avec un numéro de GSM étranger ?",
                    Value = "Oui, vous pouvez. Pour l'activation de votre billet, nous vous demandons votre numéro de téléphone portable. Vous pouvez acheter un m-ticket, m-card10 ou m-daypass avec un numéro de téléphone portable étranger"
                },
                  new TravelHelp()
                {
                    Key = "Puis-je activer des billets pour plusieurs personnes sur ma m-card10 ?",
Value = "Oui, c’est possible. Vous pouvez activer autant de billets qu'il en reste sur votre m-card10. Si nécessaire, vous pouvez aussi acheter une m-card10 supplémentaire. Veillez bien à ce que toutes les personnes concernées restent avec celle qui a activé les billets sur son smartphone pendant toute la durée du trajet."
                },
                  new TravelHelp()
                {
                    Key = "Qu'est-ce que je reçois lorsque j'ai activé un billet ?",
                    Value = "Lorsque vous avez activé un billet de votre m-card10, vous obtenez un titre de transport numérique De Lijn avec les informations suivantes :" +
                    "<ul>" +
                    "<li>" +
                    "le code de sécurité grâce auquel nous pouvons contrôler le billet" +
                    "</li>"+
                    "<li>" +
                    "la fin de validité du billet (la limite de temps)" +
                    "</li>"+
                    "<li>" +
                    "le prix" +
                    "</li>" +
                    "</ul>" +
                    "La validité du billet commence immédiatement après son émission, vous ne pouvez pas choisir vous-même à quel moment elle débute. "
                },
                  new TravelHelp()
                {
                    Key = "Comment payer mon trajet avec ma m-card10 ?",
                    Value = "Avant de monter dans le véhicule, activez un trajet sur votre m-card10. Procédez comme suit : <br>" +
                    "À partir de l'écran d'accueil de l'appli, rendez-vous sur votre m-card10 <br>" +
                    "Augmentez éventuellement le nombre de trajets que vous voulez activer. Le compteur est sur 1 de manière standard. Si vous voyagez avec deux personnes ou plus, vous devez activer autant de trajets que de personnes <br>" +
                    "Tapez sur 'Activer'" +
                    "Votre titre de transport est émis et après quelques secondes, le billet s'affiche sur votre smartphone. À présent, vous avez un titre de transport valide pendant 1 heure"
                },
                  new TravelHelp()
                {
                    Key = "Comment acheter une m-card10 ?",
                    Value = "Installez l'appli De Lijn sur votre smartphone (vers les boutiques:  iPhone ou Android)  <br/>" +
                    "En bas de l'écran d'accueil, tapez sur 'acheter billet' <br>" +
                    "Sous m-card10, tapez sur 'acheter maintenant' <br>" +
                    "Acceptez les conditions générales <br>" +
                    "Indiquez le numéro de téléphone de votre appareil <br>" +
                    "Payez <br>" +
                    "À présent, votre m-card10 s'affiche sur votre smartphone"
                },
                  new TravelHelp()
                {
                    Key = "Qu'est-ce qu'une m-card10 ?",
                    Value = "Une m-card10 est un titre de transport numérique. Si vous achetez une m-card10, vous avez droit à 10 fois 60 minutes de trajet avec nos bus et nos trams. Actuellement, la m-card10 n'est disponible que par l'intermédiaire de l'appli De Lijn. A l'avenir, d'autres fournisseurs proposeront également ce titre de transport."
                },
                  new TravelHelp()
                {
                    Key = "Quelles informations sont enregistrées si j'achète une m-card10 ?",
                    Value = "Une m-card10 est un titre de transport numérique. Si vous achetez une m-card10, vous avez droit à 10 fois 60 minutes de trajet avec nos bus et nos trams. Actuellement, la m-card10 n'est disponible que par l'intermédiaire de l'appli De Lijn. A l'avenir, d'autres fournisseurs proposeront également ce titre de transport."
                },
                  new TravelHelp()
                {
                    Key = "Que dois-je faire si le temps disponible (60) de mon m-ticket est écoulé ?",
Value = "Un m-ticket est valable 60 minutes. Ce temps commence à courir lorsque vous recevez le message. Si vous voulez poursuivre votre voyage avec De Lijn après ces 60 minutes, vous devez acheter un nouveau titre de transport. Il peut s'agir d'un nouveau ticket sms ou de l'un des autres titres de transport possibles. <br>" +
                    "Ce principe s'applique également lorsque votre bus ou votre tram a du retard."
                },
                  new TravelHelp()
                {
                    Key = "De Lijn heeft dispose aussi de ses propres applis (informations sur les trajets). Les applis pour les m-tickets continuent-elles d'exister indépendamment ou sont-elles intégrées aux applications d'informations sur les trajets?",
                    Value = "Aucun m-ticket n'est délivré dans nos propres applications d'informations sur les trajets. Vous utilisez notre appli ? Dans ce cas, vous pouvez utiliser le lien vers les applis des fournisseurs de m-tickets ou acheter une m-card10."
                },
                  new TravelHelp()
                {
                    Key = "Comment De Lijn contrôle un m-ticket?",
                    Value = "<ul class='list-group'>" +
                    "<li class='list-group-item list-group-item-light'>" +
                    "Il y a plusieurs clés visuelles sur un m-ticket. Ainsi, il indique jusqu'à quel moment il est valide et la couleur de la barre de contrôle change pendant la durée de validité." +
                    "</li>" +
                    "<li class='list-group-item list-group-item-light'>" +
                    "Si vous utilisez un m-ticket, nos contrôleurs peuvent demander le numéro de gsm de l'utilisateur.  " +
                    "<ul>" +
                        "<li>" +
                        "Le contrôleur peut transmettre ce numéro de gsm au helpdesk qui vérifie si un m-ticket a été demandé pour ce numéro." +
                        "</li>" +
                         "<li>" +
                        "Le helpdesk peut aussi envoyer un sms pour vérifier si le numéro indiqué est celui du smartphone en question." +
                        "</li>" +
                    "</ul>" +
                    "</li>"
                },
                  new TravelHelp()
                {
                    Key = "Y-a-t-il une différence d'utilisation entre les utilisateurs de gsm prépayés et sur facture?",
                    Value = "Non. Le m-ticketing fonctionne avec des plans tarifaires prépayés ou sur facture. <br/>" +
                    "Le paiement ne passe pas par votre opérateur GSM mais par la (les) méthode(s) de paiement choisie(s) auprès du fournisseur de l'appli."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter un m-ticket par le biais d'un opérateur gsm étranger?",
                    Value = "Oui, vous pouvez. Pour l'activation de votre billet, nous vous demandons votre numéro de téléphone portable. Vous pouvez acheter un m-ticket, m-card10 ou m-daypass avec un numéro de téléphone portable étranger "
                },
                  new TravelHelp()
                {
                    Key = "L'achat de m-tickets foncionne-t-il avec tous les opérateurs de services de gsm?",
                    Value = "<ul>" +
                    "<li>" +
                    "Vous pouvez acheter un m-ticket avec n'importe quel opérateur. Cependant, vous devez avoir un plan tarifaire ou un crédit d'appel pour téléphoner ou surfer sur Internet sur votre mobile. " +
                    "</li>" +
                    "<li>" +
                    "Vous n'achetez pas votre m-ticket par l'intermédiaire de votre opérateur GSM mais par l'intermédiaire de l'appli du fournisseur de votre m-ticket" +
                    "</li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter des m-tickets sans limitation si j'ai un abonnement auprès de mon opérateur GSM?",
Value = "<li>" +
                    "C'est possible. L'achat de m-tickets est indépendant du plan tarifaire de votre opérateur." +
                    "</li>" +
                    "<li>" +
                    "Ce qui compte, c'est que vous ayez suffisamment de crédit auprès du fournisseur de votre appli. Il peut s'agir de votre crédit personnel ou de celui de votre employeur." +
                    "</li>"
                },
                  new TravelHelp()
                {
                    Key = "J'ai un abonnement d'entreprise pour téléphoner et surfer acec mon smartphone. Puis-je acheter des m-tickets?",
                    Value = "<ul>" +
                    "<li>" +
                    "Vous pouvez acheter un m-ticket avec un abonnement d'entreprise. Cependant, vous devez avoir indiqué vos moyens de paiement personnels lors de l'enregistrement. " +
                    "</li>"+
                    "<li>" +
                    "La facturation ne passe donc pas par la facture de GSM de votre employeur. " +
                    "</li>"+
                    "<li>" +
                    "L'employeur ne reçoit une facture indépendante pour les m-tickets que ses collaborateurs ont acheté que si le fournisseur de l'appli a un contrat avec l'employeur en question. C'est possible par exemple en cas de budget mobilité. Parlez-en de préférence avec votre employeur." +
                    "</li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Que se pass-t-il si je n'ai pas suffisamment de crédit pur achter un m-ticket?",
                    Value = "<ul>" +
                    "<li>" +
                    "Lors de votre demande, le fournisseur de votre m-ticket vérifiera toujours si vous avez suffisamment de crédit (restant) avant de délivrer le m-ticket dans l'appli correspondante. Si votre crédit (restant) est insuffisant, vous recevez un message du fournisseur de votre m-ticket selon lequel vous ne pouvez plus commander de m-tickets (provisoirement). " +
                    "</li>" +
                    "<li>" +
                    "De Lijn ne peut pas vérifier si vous avez suffisamment de crédit. Pour toute question à ce propos, vous pouvez vous adresser au fournisseur de votre m-ticket." +
                    "</li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Que faire en cas de panne sur le réseau ou si je ne capte pas?",
                    Value = "C'est possible mais votre smartphone doit avoir une carte sim. Ainsi, le fournisseur d'un m-ticket peut envoyer un sms de contrôle pour vérifier votre numéro de GSM. "+
                            "En outre, nous devons également avoir un numéro auquel envoyer un sms de contrôle. Vous avez donc également besoin d'un abonnement ou d'un crédit d'appel auprès d'un opérateur de télécommunications."+
                            "Vous ne pouvez pas prendre le bus ou le tram sans titre de transport valide. Si le réseau gsm ne fonctionne pas ou s'il est provisoirement perturbé, vous n'avez pas de titre de transport valide. Dans le cas où vous ne captez pas également, vous devez acheter un autre titre de transport. "
                },
                  new TravelHelp()
                {
                    Key = "Puis je demander un m-ticket en passant par le WiFi gratuit?",
                    Value = "<ul>" +
                    "<li>" +
                    "C'est possible mais votre smartphone doit avoir une carte sim. Ainsi, le fournisseur d'un m-ticket peut envoyer un sms de contrôle pour vérifier votre numéro de GSM. " +
                    "</li>" +
                    "<li>" +
                    "En outre, nous devons également avoir un numéro auquel envoyer un sms de contrôle. Vous avez donc également besoin d'un abonnement ou d'un crédit d'appel auprès d'un opérateur de télécommunications." +
                    "</li>" +
                    "</ul>"
                },
new TravelHelp()
                {
                    Key = "Que se passe-t-il si la batterie de mon GSM est vide?",
                    Value = "<ul class='list-group'>" +
                    "<li class='list-group-item list-group-item-light'>" +
                    "Si votre smartphone ne fonctionne pas, vous n'avez pas de titre de transport valide. Vous devez alors passer par le chauffeur ou un autre canal de vente pour acheter un autre titre de transport. " +
                    "</li>" +
                    "<li class='list-group-item list-group-item-light'>" +
                    "Si votre smartphone tombe en panne après votre montée dans le véhicule, le contrôleur peut effectuer un contrôle en ligne. Il vérifie alors si un m-ticket a été demandé avec votre smartphone. Dans ce cas, vous êtes obligé de communiquer votre numéro de GSM au contrôleur" +
                    "</li>" +
                    "<ul>"
                },
                   new TravelHelp()
                {
                    Key = "Puis-je voyager avec plusieurs personnes en utilisant un seul smartphone?",
                    Value = "Oui. Vous devez alors acheter un m-ticket pour chaque personne. Etant donné que ces billets ne sont conservés que sur un seul smartphone, vous devez rester ensemble pendant tout le voyage"
                },
                  new TravelHelp()
                {
                    Key = "Qu'est-ceque j'obtiens lorsque je commande un m-ticket?",
                    Value = "La validité du m-ticket commence immédiatement après son émission, vous ne pouvez pas choisir vous-même à quel moment elle débute. <br/>" +
                    "Si aucun m-ticket ne peut être délivré pour des raisons techniques, vous recevez un message d'erreur. Ce message d'erreur n'est pas un titre de transport valable. Vous ne devez pas payer pour un message d'erreur. "
                },
                  new TravelHelp()
                {
                    Key = "Comment acheter un m-ticket?",
                    Value = "Choisissez d'abord quelle appli installer sur votre smartphone. Ensuite, vous devez vous enregistrer une seule fois et choisir une méthode de paiement. C'est possible par le biais d'un crédit prépayé, d'une domiciliation et d'une carte de crédit. Un employeur peut également payer les m-tickets de ses collaborateurs. Ensuite, vous pouvez demander des m-tickets. <br/>" +
                    "Pour acheter un m-ticket valide, vous devez appuyer sur le bouton ‘Payez 60 minutes’ dans l'appli (éventuellement avec indication d'un mot de passe ou d'un code pin, en fonction de l'appli utilisée). <br/>" +
                    "Il est important que vous achetiez votre m-ticket avant de monter à bord du véhicule. Nous vous recommandons de le faire lorsque vous verrez le bus ou le tram approcher. Lorsque vous montez, vous présentez le m-ticket au chauffeur <br/>" +
                    "Si vous n'achetez le m-ticket qu'une fois dans le véhicule, vous êtes en fraude."
                },
                  new TravelHelp()
                {
                    Key = "Pourquoi ma carte MOBIB coûte-t-elle 5 euros?",
                    Value = "Pour chaque carte MOBIB, vous payez cinq euros de frais d'administration. Ces frais d'administration couvrent l'achat, la personnalisation et la distribution de la carte MOBIB."
                },
                  new TravelHelp()
                {
                    Key = "J'ai déjà une carte MOBIB d'une autre compagnie. Puis-je ajouter mon abonnement De Lijn à cette carte?",
                    Value = "Oui, c’est possible. Si vous avez une carte MOBIB de la SNCB, du TEC ou de la STIB, vous ne devez pas acheter de nouvelle carte. Vous pouvez faire ajouter votre abonnement à votre carte existante. Pour ce faire, passez dans un Lijnwinkel à proximité. Prenez également votre courrier avec la proposition de paiement. <br/>" +
"Si vous prolongez ensuite votre abonnement De Lijn, votre carte sera connue de notre système et vous pourrez acheter simplement votre abonnement en ligne. Dans ce cas, inutile de passer encore au Lijnwinkel. "
                },
                  new TravelHelp()
                {
                    Key = "Pourquoi De Lijn Passe-t-elle à MOBIB? Quels sont les avantages?",
                    Value = "Nous remplaçons peu à peu les titres de transport actuels par un nouveau système de billetterie : MOBIB. Avec MOBIB, nous voulons simplifier vos déplacements"
                },
                  new TravelHelp()
                {
                    Key = "J'ai 65 ans ou plus mais je ne suis pas domicilié en Flandre. Puis-je acheter un Omnipas65+?",
                    Value = "Etant donné que l'Omnipas 65+ est un titre de transport payant, les personnes de 65 ans ou plus qui ne vivent pas en Flandre peuvent également acheter un Omnipas 65+"
                },
                  new TravelHelp()
                {
                    Key = "Que faire si le scanner MOBIB ne fonctionne pas?",
                    Value = "Si le scanner MOBIB du bus ou du tram ne fonctionne pas, dirigez-vous vers un autre scanner du véhicule ou adressez-vous au chauffeur."
                },
                  new TravelHelp()
                {
                    Key = "Il n'y a pas de date de fin sur ma carte MOBIB. Comment savoir jusqu'à quand la carte est valide?",
                    Value = "La carte MOBIB est une carte à puce électronique valide pendant 5 ans. Vous pouvez toujours consulter la durée de validité de votre abonnement sur n'importe quel scanner MOBIB. Appuyez sur la touche 'Info' du scanner MOBIB. L'appareil émettra un bip. Placez votre carte MOBIB devant le scanner. La date de fin de votre abonnement s'affiche à l'écran."
                },
                  new TravelHelp()
                {
                    Key = "Dois-je envoyer une photo d'identité pour ma carte MOBIB?",
                    Value = "Votre carte MOBIB est personnalisée avec une photo. Cette photo d'identité est reprise automatiquement à partir du registre national. </br>" +
                    "Vous commandez un abonnement pour votre enfant de moins de 12 ans et votre enfant n'a pas de carte d'identité enfant ? Dans ce cas, aucune photo d'identité n'est disponible dans le registre national et vous devez envoyer une photo d'identité "
                },
                  new TravelHelp()
                {
                    Key = "Je ne veux pas acheter de carte MOBIB. Que faire?",
                    Value = "A partir du 26 mars, tous nos abonnements seront sur MOBIB à l'exception de certains abonnements avec réduction. Si vous ne voulez pas acheter de carte MOBIB, nous ne pouvons pas délivrer d'abonnement."
                },
                  new TravelHelp()
                {
                    Key = "Comment utiliser ma carte MOBIB?",
                    Value = "Vous scannez à chaque fois que vous montez et que vous prenez une correspondance : placez votre carte devant le cercle bleu en bas du scanner composteur MOBIB <br/>" +
                    "Dès que le scanner MOBIB reconnaît votre carte, une coche (V) s'affiche sur fond vert à l'écran. Vous pouvez alors avancer. </br>" +
                    "Vous ne devez pas scanner en descendant du véhicule. <br/>" +
                    "<br/>" +
                    "Important : votre abonnement est un titre de transport nominatif et il est donc strictement personnel. Seul le titulaire peut l'utiliser. En cas de contrôle, vous devez pouvoir présenter votre abonnement et votre carte d'identité."
                },
                  new TravelHelp()
                {
                    Key = "Comment puis-je vérifier si mon abonnement se trouve sur ma carte MOBIB après paiement?",
Value = "Appuyez sur la touche d'information du scanner dans le bus ou le tram. Ensuite, maintenez votre carte MOBIB devant le cercle bleu et vous verrez votre abonnement s'afficher à l'écran."
                },
                  new TravelHelp()
                {
                    Key = "J'ai payé mar carte MOBIB mais je ne l'ai pas encore reçue. Que dois-je faire ?",
                    Value = "Si vous n'avez pas encore reçu votre carte MOBIB trois semaines après votre paiement, contactez le Service Abonnements."
                },
                  new TravelHelp()
                {
                    Key = "J'ai versé le montant de mon abonnement. Que faire ?",
                    Value = "Avec une carte MOBIB, il faut environ 1 semaine pour que votre abonnement soit disponible. Lors du premier enregistrement dans le bus, votre abonnement est chargé sur votre carte. <br>" +
                    "Sans carte MOBIB, il faut environ 2 semaines pour que vous receviez votre carte MOBIB. Lors du premier enregistrement dans le bus, l'abonnement est chargé sur votre carte."
                },
                  new TravelHelp()
                {
                    Key = "J'ai perdu ma carte MOBIB / Ma carte MOBIB est défectueuse. Que faire ?",
                    Value = "Vous avez perdu ou vous vous êtes fait voler votre carte ?  Faites-le nous savoir au moyen du 'Formulaire de demande de remplacement de carte MOBIB'.  Vous pouvez également demander un titre de transport provisoire dans l'un de nos Lijnwinkels. "+
                        "Si votre carte MOBIB est défectueuse, renvoyez-la avec le même Formulaire de demande.  Dans ce cas également, vous pouvez demander un titre de transport provisoire dans l'un de nos Lijnwinkels. "
                },
                  new TravelHelp()
                {
                    Key = "A quoi dois-je faire attention ?",
                    Value = "Saviez-vous que le Tram du littoral a toujours la priorité ? Même en tant que cycliste ou piéton, vous devez le laisser passer, même sur le passage pour piétons. <br/>" +
                    "Évitez le site propre du Tram du littoral et les bandes de stationnement contiguës."
                },
                  new TravelHelp()
                {
                    Key = "Voyager avec le Tram du littoral : conseils",
                    Value = "Le Tram du littoral comporte en son centre une partie surbaissée : elle facilite l'accès au véhicule, surtout avec une poussette, un fauteuil roulant ou un rollator. "
                },
                  new TravelHelp()
                {
                    Key = "Comment utiliser ma carte MOBIB ?",
                    Value = "Pensez à passer votre carte électronique devant le valideur pour enregistrer votre voyage."
                },
                  new TravelHelp()
                {
                    Key = "Comment utiliser mon titre de transport ?",
                    Value = "Tout titre de transport doit être composté dans l'appareil jaune, soit dans le Lijnwinkel, soit dans le véhicule. Par conséquent, vous devez (faire) valider également un titre de transport que vous avez acheté dans un magasin de journaux, par exemple. La carte MOBIB pour les personnes de plus de 65 ans doit être validée en étant tenue devant le composteur MOBIB."
                },
                  new TravelHelp()
                {
                    Key = "Quel titre de transport dois-je acheter ?",
                    Value = "Vous pouvez acheter en prévente des tickets en librairie, dans le magasin de proximité ou au supermarché. <br/>" +
                    "Il y en a pour tous les goûts. Le guichetier du Lijnwinkel se fait un plaisir de vous aider à déterminer la formule qui vous convient le mieux."
                },
                  new TravelHelp()
                {
                    Key = "Que sont les Lijnwinkels ?",
                    Value = "Il y a 40 Lijnwinkels le long du littoral. Les heures d'ouverture de ces Lijnwinkels varient en fonction de la période."+
"Rendez-vous dans ce Lijnwinkel avant de monter. Vous y achetez ou validez votre titre de transport et vous pouvez également demander des infos."
                },
                  new TravelHelp()
                {
                    Key = "Comment planifier ma sortie ?",
                    Value = "Les horaires reprennent les principaux arrêts et vous voyez à quel moment le Tram du littoral passe."
                },
                  new TravelHelp()
                {
                    Key = "Où trouver des infos à propos du Tram du littoral ?",
                    Value = "Vous trouvez les infos nécessaires sur le Tram du littoral par le biais de divers canaux : dans le Lijnfolder du Tram du littoral, auprès de l'employé du Lijnwinkel, du conducteur du tram..."
                },
                   new TravelHelp()
                {
                    Key = "Pour quelles infractions est-ce que je me vois infliger une amende de type 3 ?",
                    Value = "<ul>" +
                    "<li>" +
                    "Ne pas pouvoir présenter d'abonnement valide au moment du contrôle ;" +
                    "</li>" +
                    "<li>" +
                    "Ne pas enregistrer votre carte MOBIB dans le véhicule." +
                    "</li>"+
                    "<li>" +
                    "A la première infraction, vous ne recevez pas d'amende. En cas de 2ème ou de 3ème infraction dans les 12 mois, une amende vous est infligée." +
                    "</li>"+
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Que faire si j'ai oublié mon abonnement ?",
                    Value = "Il peut vous arriver de ne pas avoir votre abonnement, votre carte de réduction ou votre carte d'identité sur vous. Le personnel de contrôle ne peut pas vérifier sur place si vous avez bien un abonnement ou une carte de réduction. C'est pourquoi le contrôleur établira toujours un procès-verbal. Dans ce cas, vous devez prouver dans les trente jours que vous êtes bien titulaire d'un abonnement ou d'une carte de réduction."+
                            "Si vous oubliez votre abonnement, votre carte de réduction ou votre carte d'identité une deuzième fois pendant une période de douze mois, vous écoperez d'une amende administrative (type 3)."
                },
                  new TravelHelp()
                {
                    Key = "Comment éviter une amende pour fraude ?",
                    Value = "Si vous avez acheté un titre de transport en prévente, vous devez le composter immédiatement après être monté dans le véhicule, dans le composteur jaune. Si vous ne le faites pas, le titre de transport est invalide. Conservez votre billet pendant tout le voyage, afin de pouvoir le présenter en cas de contrôle."
                },
                new TravelHelp()
                {
                    Key = "Comment éviter une amende pour fraude ?",
                    Value = "Si vous n'avez pas encore de titre de transport, vous pouvez acheter un ticket sms avec votre gsm avant de monter dans le véhicule. Un ticket SMS est un titre de transport valable pour votre trajet en bus ou en tram. Il reste valable pendant 60 minutes, selon votre demande. Lorsque vous montez, vous devez présenter votre ticket sms au chauffeur. "
                },
                 new TravelHelp()
                {
                    Key = "Comment éviter une amende pour fraude ?",
                    Value = "Si vous n'avez pas de titre de transport, vous devez acheter un billet au chauffeur. Il le validera pour vous. Dans ce cas, vous payez toutefois au moins 20 % de plus qu'en prévente. Vous devez naturellement aussi pouvoir montrer ce billet en cas de contrôle."
                },
                  new TravelHelp()
                {
                    Key = "Quelles sont les compétences du personnel de contrôle ?",
Value = "Le personnel de contrôle de De Lijn est compétent pour contrôler tous les titres de transport et toutes les cartes de réduction, pour constater les infractions et pour vérifier votre identité."
                },
                  new TravelHelp()
                {
                    Key = "Comment puis-je interjeter appel à l'encontre d'une amende ?",
                    Value = "Vous pouvez intenter un recours contre une amende en envoyant un courrier recommandé au service Amendes administratives : <br>" +
                    "De Lijn – Service des Amendes administratives Boîte 10000 2800 Malines "
                },
                  new TravelHelp()
                {
                    Key = "Comment réagir à un procès-verbal ?",
                    Value = "Si vous n'êtes pas d'accord avec le procès-verbal, vous pouvez y réagir auprès de notre service Amendes administratives. Vous ne pouvez le faire que par courrier adressé à : <br>" +
                    "De Lijn – Service des Amendes administratives <br>" +
                    "Boîte 10000 <br> 2800 Malines"
                },
                  new TravelHelp()
                {
                    Key = "Comment se déroule un contrôle ?",
                    Value = "Le personnel de contrôle constate une infraction. Il demande votre carte d'identité et dresse un procès-verbal. Le personnel de contrôle remet l'exemplaire original du procès-verbal au service Amendes administratives de De Lijn. Vous recevez également un exemplaire de ce procès-verbal."
                },
                  new TravelHelp()
                {
                    Key = "Pour quelles infractions est-ce que je me vois infliger une amende de type 2 ?",
                    Value = "faire usage d'un titre de transport falsifié, d'un justificatif falsifié pour le transport gratuit ou d'une carte de réduction falsifiée ;" +
                    "<br> faire usage du titre de transport de quelqu'un d'autre ;" +
                    "<br> dégrader, entraver ou ralentir un véhicule ; " +
                    "<br> dégrader ou dérégler les installation, l'infrastructure ou les appareils ;" +
                    "être en possession d'un objet ou d'une substance qui peut blesser les autres ou peut les exposer à un danger ; "
                },
                  new TravelHelp()
                {
                    Key = "Pour quelles infractions est-ce que je me vois infliger une amende de type 2 ?",
                    Value = "<br> utiliser la commande d'urgence d'une porte ou l'ouvrir d'une autre manière alors qu'il n'y a pas de situation d'urgence ; " +
                    "monter ou descendre d'un véhicule pendant qu'il est en train de manoeuvrer ou avant que celui-ci soit totalement à l'arrêt ; <br/>" +
                    "faire un usage abusif du signal d'alarme ; <br/>" +
                    "toucher aux câbles ou installations électriques ; " +
                    "toucher aux signaux ou en bloquer la visibilité."
                },
                  new TravelHelp()
                {
                    Key = "A combien une amende peut-elle s'élever ?",
                    Value = "Une amende peut aller de 20 à 500 euros. Le montant de votre amende dépend de deux choses : le type d'infraction que vous avez commise et si vous avez déjà eu une amende au cours des 12 derniers mois."
                },
                  new TravelHelp()
                {
                    Key = "Liste des tarifs d'une amande",
                    Value = "<table class='table'>" +
                    "<tr>" +
                    "<th> Type </th>" +
                    "<th> 1ère infraction</th>" +
                    "<th>  2ème infraction dans les 12 mois </th>" +
                    "<th> 3ème infraction  dans les 12 mois </th>" +
                    "</tr>" +
                    "<tr>  " +
                    "<td> Type 1 </td>" +
                    "<td> 107 euros </td>"+
                    "<td>  250 euros </td>"+
                    "<td>   0 euros </td>"+
                    "</tr>" +
                     "<tr>  " +
                      "<td> Type 2 </td>" +
                    "<td>   294 euros </td>"+
                    "<td>   400 euros  </td>"+
                    "<td>   20 euros </td>"+
                    "</tr>" +
                     "<tr>  " +
                      "<td> Type 3 </td>" +
                    "<td>   400 euros </td>"+
                    "<td> 500 euros </td>"+
                    "<td>   50 euros </td>"+
                    "</tr>" +
                    "</table>"
                },
                  new TravelHelp()
                {
                    Key = "Quels sont les avantages dont je bénéficie en achetant sur eShop ?",
                    Value = "<ul>" +
                    "<li>" +
                    "Vous pouvez acheter votre titre de transport au tarif de prévente, sur votre ordinateur. C'est extrêmement simple et vous gagnez du temps : passer une commande ne dure que quelques minutes et les articles peuvent être livrés dès le lendemain (voir 'Quel est le délai de livraison ?')" +
                    "</li>" +
                    "<li>" +
                    "Les titres de transport sont vendus au tarif ‘prévente’. Ce tarif est nettement plus avantageux que lorsque vous acheter un titre de transport identique au chauffeur." +
                    "</li>" +
                    "<li>" +
                    "Vous pouvez acheter votre titre de transport 24 heures sur 24, quand vous voulez. " +
                    "</li>" +
                    "<li>" +
                    "La vente en ligne sur eShop est le canal idéal pour les commandes en grandes quantités. " +
                    "</li>" +
                     "<li>" +
                    "Vous avez le choix parmi un assortiment complet de billets, de Lijnkaarts, de billets à la journée et de billets pour plusieurs journées." +
                    "</li>" +
                     "<li>" +
                    "Vous avez un large choix de moyens de paiement : cartes de crédit, Bancontact, pc-banking, PayPal ou virement. " +
                    "</li>"
                    +"<li>" +
                    "Votre commande et votre paiement s'effectuent en toute sécurité et en toute fiabilité : De Lijn travaille pour cela avec bpost, qui a développé depuis plusieurs années un canal de vente en ligne performant." +
                    "</li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Qu'est-ce qu'un envoi sécurisé (Secured Mail) ? Quelle est la différence avec un envoi recommandé ?",
                    Value = "Un envoi sécurisé porte un code-barre unique qui permet le suivi de l'envoi dans le circuit postal jusqu'à sa livraison. A la livraison de la commande, un dernier scannage est effectué pour confirmer que la commande a été effectivement livrée. "
                },
                  new TravelHelp()
                {
                    Key = "Dans quelle mesure les ventes en ligne sur eShop sont-elles sûres et fiables ?",
                    Value = "bpost a une grande expérience de son application de commerce électronique et celle-ci a déjà fait la preuve de sa sécurité et de sa fiabilité. <br>" +
                    "En ce qui concerne les paiements en ligne, bpost travaille avec Ingenico, le leader du marché belge en matière de paiements sur Internet. Cette forme de paiement sécurisée est utilisée e.a. par la SNCB et elle est également appliquée à la vente, par exemple, de billets d'avion et de réservations d'hôtel. De Lijn utilise également une application de paiement similaire pour la vente en ligne d'abonnements. "
                },
                  new TravelHelp()
                {
                    Key = "Est-il possible de recevoir une facture pour une commande passée sur eShop ?",
                    Value = "En vertu de la décision de l'administration de la TVA E.T. 16172 du 2 août 1974, De Lijn n'est pas tenue de fournir une facture de votre achat."
                },
                new TravelHelp()
                {
                    Key = "Puis-je payer après la livraison ?",
                    Value = "Non. Les produits sur eShop doivent toujours être payés avant la livraison."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je commander la Gemeentekaart sur eShop ?",
                    Value = "Non. Tout le monde pourrait alors commander la Gemeentekaart alors qu'elle n'est valable que dans les communes disposant d'un contrat de tiers-payant. Le risque d'erreur est important."
                },
                  new TravelHelp()
                {
                    Key = "Est-ce que je paie un supplément en passant par eShop ?",
                    Value = "Non. Les titres de transport sont vendus sur eShop au tarif des préventes. Ce sont donc les mêmes prix que lorsque vous achetez un titre de transport dans un point de prévente externe (par ex. un magasin de journaux)."
                },
                  new TravelHelp()
                {
                    Key = "Quelles sont les possibilités de paiement sur eShop ?",
                    Value = "<ul>" +
                    "<li> carte de crédit : Visa, Mastercard </li>" +
                    "<li> PC-banking par ING, Dexia, KBC/CBC </li>" +
                    "<li> Bancontact </li>" +
                    "<li> Paypal </li>" +
                    "<li> virement Attention : si vous optez pour ce mode de paiement, le délai de livraison sera plus long. </li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Y a-t-il une quantité minimale ou un montant minimal pour pouvoir passer une commande ?",
                    Value = "Non. Par exemple, vous pouvez parfaitement commander un seul billet zones 1 et 2."
                },
                  new TravelHelp()
                {
                    Key = "Combien de titres de transport puis-je commande au maximum ?",
                    Value = "Pour chaque type de titre de transport, vous pouvez commander au maximum 100 unités. Par exemple, vous pouvez donc commander 40 billets à la journée et 100 Lijnkaarts."
                },
                  new TravelHelp()
                {
                    Key = "Quels titres de transport puis-je acheter sur eShop ?",
                    Value =
                    "billet <br>"+
                    "Lijnkaart <br>"+
                    "billet à la journée <br>"+
                    "billet à la journée enfant <br>"+
                    "billet trois jours <br>"+
                    "billet cinq jours <br>"
                },
                  new TravelHelp()
                {
                    Key = "Puis-je recevoir ma commande à l'étranger ?",
                    Value = "Non. Les produits achetés sur eShop ne peuvent actuellement être livrés qu'à une adresse valide en Belgique."
                },
                  new TravelHelp()
                {
                    Key = "Quel est le délai de livraison ?",
                    Value = "commande avant 15 heures (les jours ouvrables) et paiement en ligne : livraison le jour ouvrable suivant <br>" +
                    "commande après 15 heures : deux jours ouvrables <br/>" +
                    "Les délais de livraison sont des indications moyennes et sont communiqués uniquement à titre d'information. <br>" +
                    "Si vous payez par virement, votre commande ne sera traitée qu'à réception du paiement."
                },
                   new TravelHelp()
                {
                    Key = "Comment placer une commande par le biais d'eShop ?",
                    Value = "<ul>" +
                    "<li>" +
                    "Sélectionnez les titres de transport souhaités et ajoutez-les au panier" +
                    "</li>"+
                    "<li>" +
                    "Introduisez l'adresse de livraison" +
                    "</li>"+
                     "<li>" +
                    "Choisissez votre mode de paiement " +
                    "</li>"+
                     "<li>" +
                    "Payez sur une page sécurisée" +
                    "</li>" +
                    "</ul>"
                },
                  new TravelHelp()
                {
                    Key = "Où trouver l'eShop ?",
                    Value = "eShop fait partie du site Web de bpost."
                },
                  new TravelHelp()
                {
                    Key = "De Lijn vend-elle également des billets Jump ?",
                    Value = "Les titres de transport Jump ne peuvent être achetés que par le biais de la STIB <br>" +
                    "Ces billets sont valables dans diverses sociétés de transports publics : De Lijn, STIB, TEC et SNCB"
                },
                  new TravelHelp()
                {
                    Key = "Pourquoi la Gemeentekaart est-elle vendue dans certaines communes ?",
                    Value = "La Gemeentekaart est un exemple de contrat de tiers-payant. <br>" +
                    " Afin de stimuler l'utilisation des transports publics, les communes peuvent conclure un contrat de tiers-payant avec De Lijn. Cela signifie que la commune intervient en tout ou en partie dans le coût des transports publics. Par conséquent, le voyageur se déplace pour moins cher, voire gratuitement en bus ou en tram."
                },
                  new TravelHelp()
                {
                    Key = "Je prévois un déplacement en groupe de 5 personnes au moins. Puis-je acheter mon titre de transport en prévente ?",
                    Value = "Oui. Les groupes d'au moins 5 personnes peuvent utiliser un billet de groupe. Cependant, les membres du groupe doivent alors voyager ensemble pendant tout le trajet."
                },
                  new TravelHelp()
                {
                    Key = "Que puis-je faire si le distributeur automatique est défectueux ?",
                    Value = "Si le distributeur automatique est défectueux, vous pouvez vous adresser au chauffeur pour obtenir un titre de transport au tarif normal dans le bus. Ensuite, vous pouvez obtenir une compensation. <br>"+
                            "Complétez le formulaire de contact en ligne ou appelez De LijnInfo au 070 220 200 (0,30 euro/min)."
                },
                  new TravelHelp()
                {
                    Key = "Que dois-je faire si le solde de ma carte De Lijn est insuffisant pour payer le trajet ?",
                    Value = "Si le solde de votre carte De Lijn n'est pas suffisant pour payer le trajet, le composteur le signalera. Vous paierez alors la différence avec une nouvelle Lijnkaart ou au comptant auprès du conducteur."
                },
                  new TravelHelp()
                {
                    Key = "Pourquoi les titres de transport coûtent-ils plus cher dans le bus ou le tram ?",
                    Value = "Pour encourager nos clients au maximum à acheter leur titre de transport en prévente, ce dernier coûte plus cher dans le bus ou le tram. <br/>" +
                    "En effet, la vente de titres de transport dans les véhicules demande beaucoup de temps à nos voyageurs et à nos chauffeurs. Pour récupérer ce temps perdu, vous voulons autant que possible vendre les cartes et billets en dehors des véhicules. C'est pourquoi il y a aujourd'hui des points de vente dans toute la Flandre et à Bruxelles."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter un titre de transport dans le bus ou le tram ?",
                    Value = "Oui. Vous pouvez acheter des billets ou des billets à la journée dans tous les bus et trams. Cependant, ils coûtent jusqu'à 50 % plus cher que dans les points de prévente."
                },
                  new TravelHelp()
                {
                    Key = "Où puis-je trouver un point de prévente ?",
Value = "Il existe plus de 3 400 points de vente en Flandre et à Bruxelles qui vendent nos titres de transport : Vous pouvez rechercher un point de prévente De Lijn par commune."
                },
                  new TravelHelp()
                {
                    Key = "Qu'en est-il des offres pour de soi-disants abonnements 'virtuels' ?",
                    Value = "La billetterie par SMS fonctionne également pour les marques KPN GB et MVNO (Mobile Virtual Network Operator) de BASE, tout comme pour les opérateurs MVNO de Orange. "
                },
                  new TravelHelp()
                {
                    Key = "J'ai reçu un message selon lequel M-Pay est bloqué. Que dois-je faire ?",
                    Value = "Vous pouvez lever le blocage en contactant le helpdesk de Proximus (6000) ou par le biais de MyProximus (www.proximus.be). "
                },
                  new TravelHelp()
                {
                    Key = "Que se passe-t-il si la batterie de mon GSM est vide ?",
                    Value = "Si votre gsm ne fonctionne pas, vous n'avez pas de titre de transport valide. Vous devez alors acheter un titre de transport valide au chauffeur ou à un canal de prévente. <br/>" +
                    "Si votre gsm vous lâche après que vous êtes monté dans le véhicule, le contrôleur peut effectuer un contrôle en ligne. Il vérifie qu'un billet valide a été demandé avec votre gsm. Vous devez alors communiquer votre numéro de gsm au contrôleur."
                },
                  new TravelHelp()
                {
                    Key = "Un ticket SMS peut-il être transféré ?",
                    Value = "Il est toujours possible de transférer un SMS, donc un ticket SMS aussi. Cependant, les mesures de sécurité sont telles qu'un ticket sms transféré apparaît immédiatement comme non valide. Voyager avec un ticket SMS transféré est considéré comme une forme de fraude."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter un ticket sms lorsque je suis déjà dans le bus ou le tram ?",
                    Value = "Vous devez toujours avoir un titre de transport valide avant de monter dans le véhicule ou vous devez en acheter un au chauffeur. Cela signifie que vous devez avoir demandé un ticket sms avant de monter à bord. Nous vous recommandons de le faire lorsque vous verrez le bus ou le tram approcher. Ainsi, vous pourrez utiliser la durée de validité le plus longtemps possible. Vous devez montrer le ticket sms au chauffeur en montant dans le véhicule. "
                },
                  new TravelHelp()
                {
                    Key = "Après avoir commandé un ticket sms, j'ai reçu un message d'erreur. Dois-je payer pour cela ?",
                    Value = "Non. Les messages d'erreur ne sont pas facturés aux voyageurs."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je utiliser des sms gratuits pour acheter un ticket sms ?",
                    Value = "Non. Les sms gratuits ne peuvent être utilisés que pour des messages écrits et non pour acheter quelque chose."
                },
                  new TravelHelp()
                {
                    Key = "J'ai un abonnement d'netreprise pour mon gsm. Puis-je acheter un ticket sms ?",
                    Value = "Cela dépend de votre employeur. Si celui-ci vous permet de payer des services de tiers par le biais de votre facture de gsm, vous pourrez acheter des tickets sms. Contactez votre employeur pour plus d'informations."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je acheter des tickets sms sans limitation si j'ai un tarif abonnement ?",
                    Value = "Non, tout dépend du plan tarifaire de votre opérateur. Contactez-le pour plus d'informations."
                },
                  new TravelHelp()
                {
                    Key = "Y a-t-il une différence d'utilisation entre les utilisateurs de gsm prépayés et sur facture ?",
                    Value = "Non. L'achat du ticket sms se passe de la même manière en prépayé que sur facture. <br/>" +
                    "Dans les systèmes prépayés, le prix du ticket sms est déduit du solde d'appel. <br/>" +
                    "Avec un abonnement sur facture, le montant dû est communiqué au client par le biais d'un message qui est joint à sa facture de gsm."
                },
                  new TravelHelp()
                {
                    Key = "Puis-je voyager avec plusieurs personnes en utilisant un seul gsm ?",
                    Value = "Oui. Vous devez alors acheter un ticket sms pour chaque personne. Etant donné que ces tickets ne sont conservés que sur 1 gsm, vous devez rester ensemble pendant tout le voyage."
                },
                  new TravelHelp()
                {
                    Key = "Que se passe-t-il si je n'ai pas suffisamment de crédit pour acheter un ticket sms ?",
                    Value = "Si vous n'avez pas suffisamment de crédit, vous ne pouvez pas acheter de ticket sms. Vous recevrez un message vous indiquant que votre crédit est insuffisant."
                },
                  new TravelHelp()
                {
                    Key = "L'achat de tickets sms fonctionne-t-il via tous les opérateurs de services de gsm ?",
                    Value = "Cliquez ici pour voir <a href=''> une vue d'ensemble complète des opérateurs gsm auprès desquels vous pouvez acheter un ticket sms.</a>"
                },
                  new TravelHelp()
                {
                    Key = "Quel message dois-je envoyer pour acheter un ticket sms ?",
                    Value = "Pour un ticket sms de 60 minutes, envoyez DL au 4884. <br/>" +
                    "L'utilisation de majuscules et minuscules est autorisée. Des espaces peuvent apparaître entre les lettres du message. Le message peut être précédé ou suivi d'un espace." +
                    "<br/>" +
                    "Les messages erronés ne sont pas acceptés. Dans ce cas, vous recevez un message d'erreur. Ce message d'erreur n'est pas un titre de transport valable."
                }
            };
        }

    }
}
