using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ensciens.Models;

namespace Ensciens.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EnsciensContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EnsciensContext>>()))
            {

                if (context.Eleve.Any())
                {
                    return;
                }

                var Eleves = new Eleve[]
                {
                    new Eleve{Id=1, Nom ="Domecq",Prenom="Francois",Email = "fdomecq@ensc.fr", MotDePasse ="fdomecq123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=2, Nom ="Bernard",Prenom="Paul",Email = "pbernard@ensc.fr", MotDePasse ="pbernard123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},

                    //Membres BDE
                    new Eleve{Id=3, Nom ="Bruzat",Prenom="Mélissa",Email = "mbruzat@ensc.fr", MotDePasse ="mbruzat123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=4, Nom ="Gautier",Prenom="Noé",Email = "ngautier@ensc.fr", MotDePasse ="ngautier123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=5, Nom ="Guedon",Prenom="Titouan",Email = "tguedon@ensc.fr", MotDePasse ="tguedon123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=6, Nom ="Rocuet",Prenom="Lottie",Email = "lrocuet@ensc.fr", MotDePasse ="lrocuet123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=7, Nom ="Cayment",Prenom="Lucie",Email = "lcayment@ensc.fr", MotDePasse ="lcaymment123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=8, Nom ="Bedin",Prenom="Romain",Email = "rbedin@ensc.fr", MotDePasse ="rbedin123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=9, Nom ="Serna Hernandez",Prenom="Alexandra",Email = "ashernandez@ensc.fr", MotDePasse ="ashernandez123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=10,Nom ="Laval",Prenom="Morgane",Email = "mlaval@ensc.fr", MotDePasse ="mlaval123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=11, Nom ="Bardisbanian",Prenom="Lucas",Email = "lbardisbanian@ensc.fr", MotDePasse ="lbardisbanian123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=12, Nom ="Deny",Prenom="Audrey",Email = "adeny@ensc.fr", MotDePasse ="adeny123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=13,Nom ="Contardo",Prenom="Hugo",Email = "hcontardo@ensc.fr", MotDePasse ="hcontardo123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5}, //JE
                    new Eleve{Id=14,Nom ="Sofiane",Prenom="Wissam",Email = "wsofiane@ensc.fr", MotDePasse ="wsofiane123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4}, //JE
                    new Eleve{Id=15, Nom ="Mallard",Prenom="Tudual",Email = "tmallard@ensc.fr", MotDePasse ="tmallard123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4}, //BDS
                    new Eleve{Id=16, Nom ="Nguyen Van Ho",Prenom="Yoan",Email = "ynvho@ensc.fr", MotDePasse ="ynvho123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=17, Nom ="Bossis",Prenom="Victor",Email = "vbossis@ensc.fr", MotDePasse ="vbossis123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=53, Nom="Maginet",Prenom="Maïwen",Email="mmaginet@ensc.fr", MotDePasse="mmaginet123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},

                    //Membres BDS
                    new Eleve{Id=19, Nom ="Bourdin",Prenom="Adrien",Email = "abourdin@ensc.fr", MotDePasse ="abourdin123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=20, Nom ="Rouffelaers",Prenom="Marine",Email = "mrouffelaers@ensc.fr", MotDePasse ="mrouffelaers123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=21, Nom ="Lepri",Prenom="Mathilde",Email = "mlepry@ensc.fr", MotDePasse ="mlepry123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=22, Nom ="Thebaut",Prenom="Romy",Email = "rthebaut@ensc.fr", MotDePasse ="rthebaut123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=23, Nom ="Jacob",Prenom="Loïc",Email = "ljacob@ensc.fr", MotDePasse ="ljacob123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=24, Nom ="Neyra Contreras",Prenom="Antoine",Email = "ancontreras@ensc.fr", MotDePasse ="ancontreras123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=25, Nom ="Blanc",Prenom="Hugo",Email = "hblanc@ensc.fr", MotDePasse ="hblanc123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=26, Nom ="Bordenave",Prenom="Léonore",Email = "lbordenave@ensc.fr", MotDePasse ="lbordenave123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=27, Nom ="Le Carour",Prenom="Robin",Email = "rlcarour@ensc.fr", MotDePasse ="rlcarour123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=28, Nom ="Orange",Prenom="Arthur",Email = "aorange@ensc.fr", MotDePasse ="aorange123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=29, Nom ="Weber",Prenom="Cléo",Email = "cweber@ensc.fr", MotDePasse ="cweber123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=30, Nom ="Rondeau",Prenom="Angéline",Email = "arondeau@ensc.fr", MotDePasse ="arondeau123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=31, Nom ="Pimpaud",Prenom="Maxime",Email = "mpimpaud@ensc.fr", MotDePasse ="mpimpaud123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=32, Nom ="Durieux",Prenom="Romain",Email = "rdurieux@ensc.fr", MotDePasse ="rdurieux123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=54, Nom="Delabrière",Prenom="Léonie",Email="ldelabriere@ensc.fr", MotDePasse="ledelabriere123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},

                    //Membres BDA
                    new Eleve{Id=33, Nom ="Métraud",Prenom="Bettina",Email = "bmetraud@ensc.fr", MotDePasse ="bmetraud123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=34, Nom ="Goulier",Prenom="Emilie",Email = "egoulier@ensc.fr", MotDePasse ="egoulier123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=35, Nom ="Devi Lacourte",Prenom="Diane",Email = "ddlacourte@ensc.fr", MotDePasse ="ddlacourte123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=36, Nom ="Barthas",Prenom="Antoine",Email = "abarthas@ensc.fr", MotDePasse ="abarthas123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=37, Nom ="Gendron",Prenom="Mathis",Email = "mgendron@ensc.fr", MotDePasse ="mgendron123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=38, Nom ="Lucas",Prenom="Corentin",Email = "clucas@ensc.fr", MotDePasse ="clucas123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=39, Nom ="Brehault",Prenom="Victor",Email = "vbrehault@ensc.fr", MotDePasse ="vbrehault123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=40, Nom ="Juan",Prenom="Sara",Email = "sjuan@ensc.fr", MotDePasse ="sjuan123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=41, Nom ="Bernault",Prenom="Chloé",Email = "cbernault@ensc.fr", MotDePasse ="cbernault123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4}, //JE
                    new Eleve{Id=42, Nom ="Bellini",Prenom="Julie",Email = "jbellini@ensc.fr", MotDePasse ="jbellini123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=43, Nom ="Francois",Prenom="Maelle",Email = "mfrancois@ensc.fr", MotDePasse ="mfrancois123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=44, Nom ="Brivet",Prenom="Maëlle",Email = "mbrivet@ensc.fr", MotDePasse ="mbrivet123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=45, Nom ="Marqueton",Prenom="Emma",Email = "emarqueton@ensc.fr", MotDePasse ="emarqueton123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=58, Nom ="Weinreich",Prenom="Clément",Email = "cweinreich@ensc.fr", MotDePasse ="cweinreich123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    new Eleve{Id=59, Nom ="Gribal",Prenom="Paul",Email = "pgribal@ensc.fr", MotDePasse ="pgribal123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
                    

                    //Junior entreprise
                    new Eleve{Id=46, Nom ="Couffrant",Prenom="Adrianna",Email = "acouffrant@ensc.fr", MotDePasse ="acouffrant123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=47, Nom ="Cognet",Prenom="Jean Baptiste",Email = "jbcognet@ensc.fr", MotDePasse ="jbcognet123456", PhotoProfil="/images/boy.png",Promotion="2019-2022",FamilleId=4},
                    new Eleve{Id=48, Nom ="Doukkali",Prenom="Ali",Email = "adoukkali@ensc.fr", MotDePasse ="adoukkali123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=2},
                    new Eleve{Id=49, Nom ="Ota Bachian",Prenom="Nanor",Email = "notabachian@ensc.fr", MotDePasse ="notabachian123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=50, Nom ="Pinzi",Prenom="Alexandre",Email = "apinzi@ensc.fr", MotDePasse ="apinzi123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=51, Nom ="Konovalova",Prenom="Elizaveta",Email = "ekonovalova@ensc.fr", MotDePasse ="ekonovalova123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=5},
                    new Eleve{Id=52, Nom ="Ruelle",Prenom="Brandon",Email = "bruelle@ensc.fr", MotDePasse ="bruelle123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=1},
                    new Eleve{Id=55, Nom ="Le Goff",Prenom="Jean-Brice",Email = "jblgoff@ensc.fr", MotDePasse ="jblgoff123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=3},
                    new Eleve{Id=56, Nom ="Dizet",Prenom="Allan",Email = "adizet@ensc.fr", MotDePasse ="adizet123456", PhotoProfil="/images/boy.png",Promotion="2019-2022",FamilleId=4},
                    new Eleve{Id=57, Nom ="Holstein",Prenom="Thomas",Email = "tholstein@ensc.fr", MotDePasse ="tholstein123456", PhotoProfil="/images/boy.png",Promotion="2020-2023",FamilleId=4},
               
                    //Membre BDf 
                    new Eleve{Id=60,Nom="Bascop",Prenom="Arnaud",Email="abascop@ensc.fr",MotDePasse="abascop123456", PhotoProfil="/images/boy.png", Promotion="2020-2023",FamilleId=1}
                };
                context.Eleve.AddRange(Eleves);


                //On compte le nombre d'élèves appartenant à chaque famille
                int nbElevesVert = 0;
                int nbElevesOrange = 0;
                int nbElevesBleu = 0;
                int nbElevesJaune = 0;
                int nbElevesRouge = 0;
                //Pour chaque Eleve dans la variable Eleves définie ci-dessus
                foreach (Eleve e in Eleves)
                {
                    //On différencie les cas en fonction de l'id famille
                    switch (e.FamilleId)
                    {
                        //Id = 1 <=> Famille verte
                        case 1:
                            nbElevesVert++; ;
                            break;
                        //Id = 2 <=> Famille orange
                        case 2:
                            nbElevesOrange++;
                            break;
                        //Id = 3 <=> Famille bleu
                        case 3:
                            nbElevesBleu++;
                            break;
                        //Id = 4 <=> Famille jaune
                        case 4:
                            nbElevesJaune++;
                            break;
                        //Id = 5 <=> Famille rouge
                        case 5:
                            nbElevesRouge++;
                            break;
                    }
                }

                var familles = new Famille[]
                {
                    new Famille{Id=1,NombreEleves=nbElevesVert,Points=0,Couleur=Couleur.Vert},
                    new Famille{Id=2,NombreEleves=nbElevesOrange,Points=0,Couleur=Couleur.Orange},
                    new Famille{Id=3,NombreEleves=nbElevesBleu,Points=0,Couleur=Couleur.Bleu},
                    new Famille{Id=4,NombreEleves=nbElevesJaune,Points=0,Couleur=Couleur.Jaune},
                    new Famille{Id=5,NombreEleves=nbElevesRouge,Points=0,Couleur=Couleur.Rouge},
                };
                context.Famille.AddRange(familles);

                var bureaux = new Bureau[]
                {
                    new Bureau{Id=61, Nom="Bureau des Elèves",Logo="/images/Bureaux/BDE.png",Description="Le Bureau Des Élèves (BDE du coup) est le bureau le plus général de l’école. Cette année le bureau est composé de 16 membres qui seront là pour répondre du mieux possible aux questions que tu te poses sur la vie étudiante au sein de l’Ensc, mais aussi pour organiser tout au long de l’année des events qui correspondent et plaisent à tous et à toutes comme des soirées à l’école, le gala, le week-end d’intégration et la tenue du bar. Le BDE, c’est aussi un moyen pour les élèves de rencontrer du monde et d’apprendre à se connaître via les activités proposées, nous sommes aussi le vecteur entre les étudiants et l’administration, ainsi que la représentation de l’Ecole à l’extérieur."},
                    new Bureau{Id=62, Nom="Bureau des sports",Logo="/images/Bureaux/BDS.jpg",Description="Oh mais ce serait pas au tour du meilleur bureau de l’école ? (On déconne on s’aime tous fort. Normalement). Plus sérieusement, nous c’est le BDS (c’est les initiales pour Bureau Des Sports c’est pas dingue ça?), et on est là pour vous faire kiffer le sport ! Que t’aies jamais couru de ta vie même pour attraper un bus ou que tu sois juste une montagne de muscles, on a tout plein d’activités à vous proposer pour vous partager notre amour du sport. Si en plus, t’as un peu l’esprit de compét’, tu pourras représenter fièrement notre belle école et déglinguer allègrement les autres, que ce soit lors des compétitions annuelles ou lors d’évènements (Krystal, Ol’INPiades, …). Et bah ouais, on organise aussi des super évènements (sportifs du coup, bien vu) tout au long de l’année, pendant les week-ends, inter ou intra école ! Même des giga week-ends entre nous, au ski ou à la plaaage !"},
                    new Bureau{Id=63, Nom="Bureau des arts",Logo="/images/Bureaux/BDA.png",Description="Comment décrire le Bureau Des Arts en quelques mots ? La mission du BDA est avant tout d’embellir et d’enrichir votre vie étudiante. Nous sommes là pour organiser régulièrement des évènements fun et cool, être à l'écoute, soutenir des initiatives culturelles… Nous étudions les idées de chacun avec bienveillance et espérons apporter de la joie et des rires au plus grand nombre. Nous avons la volonté de faire vivre l'art et la culture et de les promouvoir au sein de l'école. Parce que si on aime la fête et le sport, il ne faut pas oublier que d’autres activités sont à votredisposition grâce au BDA. En effet, notre rôle est aussi d’accompagner tout au long de l’année les clubs que vous faîtes vivre à travers votre engagement."},
                    new Bureau{Id=64, Nom="Junior entreprise",Logo="/images/Bureaux/JE.png",Description="L’ENSC a la chance de compter parmi ses associations une Junior Entreprise -aka JErépondant au fabuleux nom de « i2c », à savoir « Ingénierie et Conseil en Cognitique ». Cette association en marge des autres bureaux (BDE, BDA, BDS) a une visée plus concrète et professionnelle. En adhérant à la JE, tu auras l’occasion de participer à des études qui te permettront de mettre en pratique les connaissances acquises à l’école. Ces études, ce sont des clients (entrepreneurs, grands groupes, associations,…) qui en font la demande. Elles sont significatives d’un projet particulier tel que la réalisation d’un site internet ou de la conception d’une interface par exemple. Intermédiaire entre étudiants et professionnels, la JE offre l’opportunité aux élèves de gagner de nouvelles expériences  professionnelles, et d’accéder à une indemnisation contre le travail effectué. Elle organise aussi des formations et conférences sur des sujets aussi variés que l'écologie ou le monde du travail. Ainsi, elle s’inscrit dans un objectif pédagogique, économique et social ! N’est-ce pas là un incroyable concept ?"},
                    new Bureau{Id=65, Nom="Bureau des familles",Logo="/images/Bureaux/BDF.jpg",Description="Le BDF (ou Bureau des Familles) est au cœur de la vie étudiante de l’ENSC. Chaque étudiant.e est réparti.e dans une famille (comme dans Harry Potter t’as la réf) par le Choipoulpe. Une fois l’attribution terminée, les familles s’affrontent toute l’année au cours de nombreuses épreuves pour remporter la coupe des familles et ainsi être reconnue comme meilleure famille de l’année"}
                };
                context.Bureau.AddRange(bureaux);

                var clubs = new Club[]
                {
                    //Clubs BDA
                    new Club{Id=66,Nom="Musique",Description="Grand rescapé du COVID, le club musique de l’ENSC est un groupe de musiciens amateurs qui partagent le goût de la musique. Ouvert à tous les niveaux, experts comme débutants, sont but  est surtout de donner l’opportunité aux musiciens de l’école de pouvoir jouer ensemble, de mener des projets personnels et de partager leur connaissance sur le sujet à l’aidede notre arsenal d’instruments de musique (piano, piano MIDI, batterie électrique, ampli, micro…)",Logo="/images/Clubs/Musique.png",BureauId=63},
                    new Club{Id=67,Nom="Gazette du Cogniticien",Description="Le club journal est le club qui gère la Gazette du Cogniticien, le journal desétudiants de l’ENSC. Les membres s’occupent de la mise en page, de la ligne éditoriale, de la réception des articles, de la rédaction d'articles et d’autres activités. L'objectif est de partager aux élèves les créations d’autres élèves, de les informer sur la vie de l’école, la vie de Bordeaux et d’autres sujets. Tous les élèves peuvent proposer du contenu sur le sujet qu’ils souhaitent.",Logo="/images/Clubs/Gazette.png",BureauId=63},
                    new Club{Id=68,Nom="Femin'unes",Description="Les discriminations et injustices te laissent un goût de cendre dans la bouche ? Les conséquences du patriarcat et du sexisme ordinaire te donne la nausée ? Ok, n’hésite pas une minute et rejoins Femin’unes ! Ce nouveau club féministe de l’école te permet de t’engager à ton échelle et d’agir en faveur d’un avenir meilleur pour toustes. Au programme : mise en place d’actions dans l’école (les petites boites menstruelles des toilettes c’est nous hehe), gestion du militantisme en ligne via les réseaux pour sensibiliser aux thématiques féministes, discussions et rencontres... Tout reste encore à créer et à expérimenter. Et ton avis compte, nous fonctionnons sans hiérarchie ni obligations !",Logo="/images/Clubs/Feminunes.png",BureauId=63},
                    new Club{Id=69,Nom="Octowood",Description="L’objectif de ce club est de réaliser des courts et/ou longs métrages, à l’intérieur ou à l’extérieur de l’école ! Que tu sois monteur.euse, acteur.rice (en carton ou non) ou si tu as simplement la capacité de tenir une caméra, tu nous intéresses ! Si tu as la moindre idée de vidéo, même si elle n’est pas aboutie, viens la partager avec nous !",Logo="",BureauId=63},
                    new Club{Id=70,Nom="Jeux",Description="Animé par une passion pour tout type de jeux, le club jeux de l’ENSC propose diverses activités ludiques telles que des afterworks jeux de société, des soirées jeu de rôle ou encore des sorties dans des bars à jeux toujours dans une ambiance fun et légère. Nous sommes toujours à la recherche de nouveaux membres pour nous aider à organiser des moments entre amateurs de ludicité donc n’hésite pas à venir tester nos jeux avec nous ! ",Logo="/images/Clubs/Jeux.png",BureauId=63},
                    new Club{Id=71,Nom="Ecriture",Description="Un endroit de partage, d’entraide et de motivation concernant l’écriture, où les membres peuvent parler de leurs projets personnels, faire des retours constructifs sur ceux des autres ou encore participer à des défis tous ensemble. ",Logo="",BureauId=63},
                    new Club{Id=72,Nom="Animes",Description="Le club Anime, c’est un rassemblement de personnalités électriques ne vivant que pour une chose : la sainte culture japonaise et ses mangas ! La légende raconte que tout le monde y a sa place, des novices aux plus fins connaisseurs : on y discute, on organise des marathon et on se retrouve autour de cette passion qui nous unit. Après tout, n’est ce pas ça, l’essence même du partage ?",Logo="/images/Clubs/Anime.png",BureauId=63},
                    new Club{Id=73,Nom="Théâtre",Description="Tu as toujours aimé jouer la comédie ou bien tu es timide et aimerais te challenger ? Qui que tu sois, le club Théâtre t’ouvre grand son rideau. Pendant les deux premiers mois, on fait des petits jeux pour s’initier à l’art théâtral : jeu de cohésion de groupe, d’articulation, d’impro… Ensuite, on commence à répéter une petite pièce choisie tous ensemble qu’on pourra représenter devant le reste de l’école, parce que c’est quand même chouette de mettre des paillettes dans les yeux du public aka les copains",Logo="/images/Clubs/Theatre.png",BureauId=63},
                    new Club{Id=74,Nom="Philo",Description="“Que nul n’entre ici s’il n’est géomètre”. Tu croyais que l'ingénierie et philo étaient antinomiques ? Et bien justement, c’était une croyance. Le club Philo c’est ça, on parle, on échange, on déconstruit, on reconstruit, on déterritorialise, on dialectise même. On raisonne aussi : la philosophie est amour de la sagesse, or un amour n’est jamais possible seul, donc venez nombreux au club philo. Logique. Pour la suite(IA, épistémo,...) on n’attend que toi.",Logo="/images/Clubs/Philo.png",BureauId=63},
                    new Club{Id=75,Nom="Intelligence Collective et Innovation ",Description="Tu as des idées de projets plein la tête et envie de t’éclater à les concrétiser ? Ou tu as envie de rejoindre les autres pour le faire ? Et bah top car on est ici pour vous encourager ! Et le plus beau, c'est que c’est ouvert à tous ! Concrètement on essaie de créer un réseau interne à l’école pour que tout le monde s’entraide et kiff à créer des trucs ensemble ! Et bien sûr externe en organisant des events genre conférences… Bref ça va être génial, et ça commence ici ! :D",Logo="/images/Clubs/ICI.png",BureauId=63},
                    new Club{Id=76,Nom="Partage d'expérience et passiosn",Description="Le club “PExp : partage d’expérience et passions” a pour but de proposer et centraliser des prestations dispensées principalement par des étudiants de l’ENSC, mais également tout intervenant extérieur en lien soit avec la cognitique, soit avec l’ENSC). Le but est de créer des liens entre les connaissances individuelles et de former une connaissance partagée.",Logo="",BureauId=63},
                    new Club{Id=77,Nom="cogni'pic",Description="On prend des photos que t'assumes pas le lendemain :^) Cogni’pic comme tout mot à base de “COgni” on ne sait pas vraiment ce que ça signifie et ce qui se cache derrière ! Pour faire simple, c’est le club où se réfugient ceux qui ont l 'œil le plus aiguisé de l’école. Toujours à l’affût, cette population de personnes hors normes capture la faune cogniticienne dans son état naturel (c’est-à-dire en état d’ébriété). Trève de plaisanterie, le rôle de ce club est Ô combien important. Il permet de graver les souvenirs de toute personne entrant à l’école de son intégration à sa remise de diplôme.",Logo="/images/Clubs/Cognipic.png",BureauId=63},
                    new Club{Id=78,Nom="Jeux vidéos",Description="Le club permet aux joueurs.euses de se retrouver pour jouer, tous les niveaux sont les bienvenus ! On organise des évènements (LANs, compétitions, etc…)toute l’année, sur n’importe quel type de jeux, accessibles ou non. Les jeux tels que League of Legends ou Smash sont très actifs mais ce n’est pas tout. Si tu as envie de jouer à un truc, on trouve quelques compagnon.ne.s et c'est parti ! En plus, on a installé pas mal de jeux sur les PC aussi, pour votre plaisir. ",Logo="/images/Clubs/JeuxVideos.png",BureauId=63},
                    new Club{Id=79,Nom="Débatthé",Description="Quoi de mieux que de débattre, boire du thé, partager un goûter et discuter de la vie entre amis ? Un club habite dans la cuisine, et se réunit sans horaires fixes dans la semaine, dès qu’il fait faim de parler et manger. ",Logo="Debatthe.png",BureauId=63},
                    new Club{Id=80,Nom="Cuisine",Description="Tu es fan de cuisine ? T’en as déjà assez des Blague : pâtes tous les soirs ? Tu aimes manger ? Quelle que soit la réponse, ne passe pas à côté du plus appétissant des clubs, le club Cuisine ! On partage de la bonne humeur autour de repas et d’ateliers organisés à l’école, des recettes dignes de Jean-Pierre Coffe pour égayer tes repas et des petits tips pour te faciliter la vie en cuisine, rejoins-nous !",Logo="/images/Clubs/Cuisine.png",BureauId=63},
                    new Club{Id=81,Nom="Blague",Description="Savez-vous comment les abeilles communiquent entre elles ? Par e-mail Vous aussi vous aimez rigoler ? Si vous nous trouvez, rejoignez nous.",Logo="",BureauId=63},
                    new Club{Id=82,Nom="Cinéma",Description="Envie d’étendre votre culture cinématographique ? Le club Ciné de l’ENSC est là pour ça. Au rythme de deux séances par mois, le club ciné propose aux étudiants de l'école de visionner dans une ambiance chaleureuse des films en tous genres, toutes les époques, et de toutes origines. Que ce soit pour voir pour la 100e fois un classique ou pour découvrir un petit film indépendant, nous sommes présents ! ",Logo="/images/Clubs/Cinema.png",BureauId=63},
                    new Club{Id=83,Nom="Dessin",Description="Envie de dessiner en groupe ? Besoin d’une affiche ? Envie d’un conseil ? Envie de participer à la prochaine couverture du journal ? N’hésitez pas à nous contacter ! \n TOUS LES NIVEAUX SONT ACCEPTES \n Adresse mail : clubdessin@ensc.fr \n Compte Instagram : club_ddessin_ensc \n Page Facebook : clubDessinENSC",Logo="/images/Clubs/Dessin.png",BureauId=63},

                    //Clubs BDE 
                    new Club{Id=84,Nom="Terra Terre",Description="Terra Terre est le club humanitaire et environnemental de l’ENSC. Le club a été créé il y a deux ans (2019) par un groupe d'élèves de différentes promotions, et il est rattaché au Bureau Des Elèves. il n’y a pas d’adhésion, donc tout le monde peut participer quand il le souhaite. Les réunions se déroulent sous forme d'Assemblées Générales où sont conviés étudiants, professeurs et personnels de l'administration. Le but est d'intégrer les problématiques humanitaires et environnementales dans la vie que nous partageons à l’école. A titre d'exemple, Terra Terre a mis en place la distribution des Petits Paniers Campus une fois par semaine dans l’école. Le club faire aussi partie de l'association étudiante Together For Earth, et organise fréquemment des événements avec les autres associations environnementales du campu (cleanwalk sur le campus) ",Logo="/images/Clubs/TerraTerre.png",BureauId=61},
                    new Club{Id=85,Nom="Oenologie",Description="Située dans la plus belle région viticole de France, d’Europe et même du monde, au sein des anciens locaux de l’institut d'oenologie de Bordeaux, l’ENSC se devait d’avoir un club oenologie ! Que tu sois amateur de vin ou que tu n’y connaisses pas grand chose voire même rien du tout, ce club sera l’occasion pour toi d’améliorer tes connaissances du monde viticole ! Au programme, des visites de châteaux, des cours d’oenologie, des afterwork Bar à Vin à l'école et plein d’autres choses.",Logo="/images/Clubs/Oenologie.png",BureauId=61},

                    //Clubs BDS
                    new Club{Id=86,Nom="Pompoms",Description="Tu as le rythme dans la peau ? Tu maîtrises les flips et les saltos ? Pas moi et pourtant je suis pom-pom ! A l’ENSC, c’est ouvert à tous. Etre pom-pom c’est contribuer à soulever les équipes adverses en encourageant à fond les sportifs de l’école. Alors si tu as toujours rêvé d’agiter les pom-poms rejoins notre équipe mixte !",Logo="",BureauId=62},
                    new Club{Id=87,Nom="Voile",Description="Le club a pour but de faire découvrir la voile à tous les intéressés avec quelques sorties en bateau dans l’année. Encore en état de développement, l’objectif du club est de participer aux divers évènements étudiants (comme la course de l’EDHEC, un des plus grands rassemblements étudiants de France).",Logo="",BureauId=62},
                    new Club{Id=88,Nom="Montagne",Description="A la croisée de Kilian Jornet et de Paul Bocuse, se trouve le club Montagne. Tout le monde y est bienvenu, quelle que soit ta capacité physique. Les activités y sont variées : le but étant simplement de partir en montagne entre copains ! Une seule règle : être un bon vivant et aimer la montagne !",Logo="",BureauId=62},
                    new Club{Id=89,Nom="Course",Description="Bon on va pas y aller par 4 chemins enfin si. Que tu sois runner du dimanche ou athlète accompli ou ni l'un ni l'autre tu seras le bienvenu au club Course pour te défouler, te remettre la tête à l'endroit de la soirée de la veille ou retrouver tes poumons de jeunesse. Pour les plus acharnés pourquoi ne pas s'inscrire sur certaines courses du dimanche et courir pour une bonne cause. ",Logo="",BureauId=62},
                    new Club{Id=90,Nom="Tennis",Description="Au club Tennis, on va taper la balle régulièrement (=dès que quelqu’un propose un créneau) sur les terrains derrière Montaigne (à 4 arrêts de tram). ON a un peu de tout, des grand.e.s débutant.e.s à qui on apprend, des vétérans un peu rouillé.e.s et on accueille tou.s.tes les volontaires !",Logo="/images/Clubs/Tennis.png",BureauId=62},

                };
                context.Club.AddRange(clubs);

                var liensBureauEleve = new LienBureauEleve[]
                {
                    //Membres BDE
                    new LienBureauEleve{Id=1,Role = "Présidente", EleveId=3,BureauId=61},
                    new LienBureauEleve{Id=2,Role = "Vice-Présidente", EleveId=54,BureauId=61},
                    new LienBureauEleve{Id=3,Role = "Secrétaire", EleveId=4,BureauId=61},
                    new LienBureauEleve{Id=4,Role = "Trésorier", EleveId=16,BureauId=61},
                    new LienBureauEleve{Id=5,Role = "Trésorier", EleveId=17,BureauId=61},
                    new LienBureauEleve{Id=6,Role = "Respo Communication Externe" , EleveId=13,BureauId=61},
                    new LienBureauEleve{Id=7,Role = "Coordinateur", EleveId=8,BureauId=61},
                    new LienBureauEleve{Id=8,Role = "Respo Partenariats", EleveId=5,BureauId=61},
                    new LienBureauEleve{Id=9,Role = "Respo Event", EleveId=11,BureauId=61},
                    new LienBureauEleve{Id=10,Role = "Respo Event", EleveId=12,BureauId=61},
                    new LienBureauEleve{Id=11,Role = "Respo Bar", EleveId=15,BureauId=61},
                    new LienBureauEleve{Id=12,Role = "Respo Foyer", EleveId=14,BureauId=61},
                    new LienBureauEleve{Id=13,Role = "Respo Communication", EleveId=9,BureauId=61},
                    new LienBureauEleve{Id=14,Role = "Respo Communication", EleveId=10,BureauId=61},
                    new LienBureauEleve{Id=15,Role = "Respo Logistique", EleveId=7,BureauId=61},
                    new LienBureauEleve{Id=16,Role = "Respo Logistique", EleveId=6,BureauId=61},

                    //BDS
                    new LienBureauEleve{Id=17,Role = "Respo Clubs", EleveId=31,BureauId=62},
                    new LienBureauEleve{Id=18,Role = "Président", EleveId=32,BureauId=62},
                    new LienBureauEleve{Id=19,Role = "Vice-Présidente", EleveId=20,BureauId=62},
                    new LienBureauEleve{Id=20,Role = "Secrétaire", EleveId=26,BureauId=62},
                    new LienBureauEleve{Id=21,Role = "Respo Event", EleveId=55,BureauId=62},
                    new LienBureauEleve{Id=22,Role = "Respo Event", EleveId=23,BureauId=62},
                    new LienBureauEleve{Id=23,Role = "Respo Equipes", EleveId=29,BureauId=62},
                    new LienBureauEleve{Id=24,Role = "Respo Pompom", EleveId=30,BureauId=62},
                    new LienBureauEleve{Id=25,Role = "Respo Fun", EleveId=22,BureauId=62},
                    new LienBureauEleve{Id=26,Role = "Vice Trésorier", EleveId=15,BureauId=62},
                    new LienBureauEleve{Id=27,Role = "Trésorier", EleveId=27,BureauId=62},
                    new LienBureauEleve{Id=28,Role = "Respo WES", EleveId=25,BureauId=62},
                    new LienBureauEleve{Id=29,Role = "Respo Matos", EleveId=29,BureauId=62},
                    new LienBureauEleve{Id=30,Role = "Respo Communication", EleveId=24,BureauId=62},
                    new LienBureauEleve{Id=31,Role = "Respo Partenariat", EleveId=21,BureauId=62},
                    new LienBureauEleve{Id=32,Role = "Respo Krystal", EleveId=19,BureauId=62},
                    
                    //JE
                    new LienBureauEleve{Id=33,Role = "Présidente", EleveId=51,BureauId=64},
                    new LienBureauEleve{Id=34,Role = "Vice Président", EleveId=13,BureauId=64},
                    new LienBureauEleve{Id=35,Role = "Secrétaire Générale", EleveId=49,BureauId=64},
                    new LienBureauEleve{Id=36,Role = "Trésorier", EleveId=55,BureauId=64},
                    new LienBureauEleve{Id=37,Role = "Responsable SI", EleveId=14,BureauId=64},
                    new LienBureauEleve{Id=38,Role = "Communication", EleveId=30,BureauId=64},
                    new LienBureauEleve{Id=39,Role = "Développement Commercial", EleveId=52,BureauId=64},
                    new LienBureauEleve{Id=40,Role = "Vice Trésorière", EleveId=39,BureauId=64},
                    new LienBureauEleve{Id=41,Role = "RSE", EleveId=56,BureauId=64},
                    new LienBureauEleve{Id=42,Role = "RQO", EleveId=47,BureauId=64},
                    new LienBureauEleve{Id=43,Role = "RQT", EleveId=46,BureauId=64},
                    new LienBureauEleve{Id=44,Role = "Chargé RSE", EleveId=57,BureauId=64},
                    new LienBureauEleve{Id=45,Role = "Commercial", EleveId=50,BureauId=64},
                    new LienBureauEleve{Id=46,Role = "Chargé d'études", EleveId=48,BureauId=64},

                    //BDA
                    new LienBureauEleve{Id=47,Role = "Président", EleveId=36,BureauId=63},
                    new LienBureauEleve{Id=48,Role = "Vice Présidente", EleveId=45,BureauId=63},
                    new LienBureauEleve{Id=49,Role = "Secrétaire", EleveId=34,BureauId=63},
                    new LienBureauEleve{Id=50,Role = "Trésorier", EleveId=37,BureauId=63},
                    new LienBureauEleve{Id=51,Role = "Vice Trésorière", EleveId=35,BureauId=63},
                    new LienBureauEleve{Id=52,Role = "Coordinateur", EleveId=38,BureauId=63},
                    new LienBureauEleve{Id=53,Role = "Respo Event", EleveId=39,BureauId=63},
                    new LienBureauEleve{Id=54,Role = "Respo Event", EleveId=40,BureauId=63},
                    new LienBureauEleve{Id=55,Role = "Respo Clubs", EleveId=59,BureauId=63},
                    new LienBureauEleve{Id=56,Role = "Respo Clubs", EleveId=58,BureauId=63},
                    new LienBureauEleve{Id=57,Role = "Respo Communication", EleveId=42,BureauId=63},
                    new LienBureauEleve{Id=58,Role = "Respo Communication", EleveId=33,BureauId=63},
                    new LienBureauEleve{Id=59,Role = "Respo Culture & Partenariats", EleveId=41,BureauId=63},
                    new LienBureauEleve{Id=60,Role = "Respo Culture & Partenariats", EleveId=43,BureauId=63},

                    //BDF
                     
                    new LienBureauEleve{Id=61, Role = "Respo Famille Verte", EleveId=60,BureauId=65},
                    new LienBureauEleve{Id=62, Role = "Respo Famille Jaune", EleveId=14,BureauId=65},
                    new LienBureauEleve{Id=63, Role = "Respo Famille Jaune", EleveId=20,BureauId=65},
                    new LienBureauEleve{Id=64, Role = "Respo Famille Bleue", EleveId=5,BureauId=65},
                    new LienBureauEleve{Id=65, Role = "Respo Famille Bleue", EleveId=8,BureauId=65},
                    new LienBureauEleve{Id=66, Role = "Respo Famille Orange", EleveId=24,BureauId=65},
                    new LienBureauEleve{Id=67, Role = "Respo Famille Orange", EleveId=12,BureauId=65},
                    new LienBureauEleve{Id=68, Role = "Respo Famille Rouge", EleveId=11,BureauId=65},
                    new LienBureauEleve{Id=69, Role = "Respo Famille Rouge", EleveId=7,BureauId=65},
                    new LienBureauEleve{Id=70, Role = "Respo Famille Verte", EleveId=31,BureauId=65},
                };
                context.LienBureauEleve.AddRange(liensBureauEleve);

                var liensClubEleve = new LienClubEleve[]
                {
                    new LienClubEleve{Id=1,Role="Président",EleveId=4,ClubId=66},
                    new LienClubEleve{Id=2,Role="Membre",EleveId=8,ClubId=67},
                    new LienClubEleve{Id=3,Role="Membre",EleveId=6,ClubId=68},
                    new LienClubEleve{Id=4,Role="Membre",EleveId=10,ClubId=69},
                    new LienClubEleve{Id=5,Role="Président",EleveId=22,ClubId=70},
                    new LienClubEleve{Id=6,Role="Président",EleveId=23,ClubId=71},
                    new LienClubEleve{Id=7,Role="Membre",EleveId=20,ClubId=72},
                    new LienClubEleve{Id=8,Role="Membre",EleveId=24,ClubId=73},
                    new LienClubEleve{Id=9,Role="Membre",EleveId=13,ClubId=74},
                    new LienClubEleve{Id=10,Role="Membre",EleveId=40,ClubId=75},
                    new LienClubEleve{Id=11,Role="Président",EleveId=43,ClubId=76},
                    new LienClubEleve{Id=12,Role="Membre",EleveId=42,ClubId=77},
                    new LienClubEleve{Id=13,Role="Membre",EleveId=12,ClubId=78},
                    new LienClubEleve{Id=14,Role="Membre",EleveId=10,ClubId=79},
                    new LienClubEleve{Id=15,Role="Membre",EleveId=56,ClubId=80},
                    new LienClubEleve{Id=16,Role="Membre",EleveId=54,ClubId=81},
                    new LienClubEleve{Id=17,Role="Président",EleveId=33,ClubId=82},
                    new LienClubEleve{Id=18,Role="Membre",EleveId=39,ClubId=83},
                    new LienClubEleve{Id=19,Role="Membre",EleveId=2,ClubId=84},
                    new LienClubEleve{Id=20,Role="Membre",EleveId=17,ClubId=85},
                    new LienClubEleve{Id=21,Role="Membre",EleveId=16,ClubId=86},
                    new LienClubEleve{Id=22,Role="Membre",EleveId=28,ClubId=87},
                    new LienClubEleve{Id=23,Role="Membre",EleveId=23,ClubId=88},
                    new LienClubEleve{Id=24,Role="Membre",EleveId=37,ClubId=89},
                    new LienClubEleve{Id=25,Role="Membre",EleveId=39,ClubId=90},
                    new LienClubEleve{Id=26,Role="Membre",EleveId=46,ClubId=71},
                    new LienClubEleve{Id=27,Role="Membre",EleveId=49,ClubId=67},
                    new LienClubEleve{Id=28,Role="Membre",EleveId=53,ClubId=66},
                    new LienClubEleve{Id=29,Role="Membre",EleveId=50,ClubId=77},
                    new LienClubEleve{Id=30,Role="Membre",EleveId=52,ClubId=80},
                };
                context.LienClubEleve.AddRange(liensClubEleve);

                var evenements = new Evenement[]
                {
                    new Evenement{Id=1,Titre="Gala 2021",Lieu="Chateau Larrivet Haut-Brion", Description="Le chateau Larrivet Haut-Brion et le BDE sont très fiers de vous proposer de célébrer le gala dans ce qui est certainement l'un des plus beaux châteaux de l'appelation Pessac-Léognan.", Date=new DateTime(2021,12,6),OrganisateurId=61},
                    new Evenement{Id=2,Titre="Dégustation vin", Lieu="ENSC",Description="Salut à toutes et tous, c'est encore nous !! On se retrouve demain à 17h30 pour un bar à vins. Comme la dernière fois, toutes sortes de bouteilles (blanc, rouge et rosé) mais en plus de ça, de la charcuterie et du fromage à acheter.  PS : les bouteilles du domaine Blanpim ont été écoulées et ne seront plus disponibles pour ce bar à vins.  PPS : j'espère que vous savez lire entre les lignes. PPPS : mangez 5 fruits et légumes par jour. À vos verres ",Date=new DateTime(2021,10,8),OrganisateurId=85},
                    new Evenement{Id=3,Titre="Interpromo", Lieu="Salle omnisport",Description="Salut les p'tits potes, vu comment vous étiez nombreux et motivés pour le relais, on s'est dit qu'on allait encore refaire du sport. Alors si t'es chaud de représenter ta promo au volley, au basket, au foot ou au hand (tournoi mixte), inscris-toi ici : https://docs.google.com/.../1HP1eEyiSaPOorP16kShv.../edit... (attention vous pouvez vous inscrire pour 4 sports (vœux) mais on répartira du mieux qu'on peut. Rendez-vous 9h00 le dimanche 21 novembre à la salle Omnisport (Rocquencourt)",Date=new DateTime(2021-11-15),OrganisateurId=62},
                };
                context.Evenement.AddRange(evenements);

                var commentaires = new Commentaire[]
                {
                    new Commentaire{Id=2, Contenu="Il me tarde déjà d'y être !", DateEnvoi=new DateTime(2021,10,19), PublicateurId=45},
                    new Commentaire{Id=1,Contenu="Venez sur le groupe suivant pour être tenu au courant : https://www.facebook.com/groups/413137430264145/",DateEnvoi=new DateTime(2021,10,18),PublicateurId=61},
                    new Commentaire{Id=3,Contenu="Les Sports ça ne sera pas forcément mixte ça dépendra du nombre d'inscrits dans chaque promo", DateEnvoi=new DateTime(2021,11,8),PublicateurId=38},
                    new Commentaire{Id=4,Contenu="C'est du futsal du coup ?", DateEnvoi=new DateTime(2021,11,9),PublicateurId=1}
                };
                context.Commentaire.AddRange(commentaires);

                var publications = new Publication[]
                 {
                    new Publication{Id=1,Titre="Gala ENSC",Contenu="",DatePublication=new DateTime(2021,10,18),Medias="FaceBook",EvenementId=1,Commentaires=new List<Commentaire>{commentaires[0],commentaires[1]},PublicateurId=61},
                    new Publication{Id=2,Titre="Dégusation vin",Contenu="",DatePublication=new DateTime(2021,10,7),Medias="FaceBook",EvenementId=2,PublicateurId=85},
                    new Publication{Id=3,Titre="Tournoi interpromo", Contenu="",DatePublication=new DateTime(2021,10,8),Medias="Facebook",EvenementId=3,Commentaires =new List<Commentaire>{commentaires[2],commentaires[3]},PublicateurId=62},
                    new Publication{Id=4,Titre="Stand Partenariat BNP",Contenu="Comme l'a annoncé le BDE , 2 conseillers de la BNP seront présents dans le Hall aujourd'hui pour vous faire profiter du partenariat. Les infos importantes: -12h a 13h45 -dans le hall sud  -vous pourrez ouvrir un compte directement ( avec les 80€ offerts )  -si vous souhaitez bénéficier de cet avantage vous pouvez préparer vos documents , sous format numérique c'est suffisant ( vous pourrez les envoyer par mail ). Il faut -un justificatif d'identité -un justificatif de domicile -un certificat de scolarité",DatePublication=new DateTime(2021,12,16),Medias="Facebook",PublicateurId=65},
                    new Publication{Id=5,Titre="Soutien", Contenu="Salut à tous, j'envoie un message sur ce groupe pour savoir si des personnes fortes en génie logiciel pourraient me donner des cours de soutien ? Envoyez moi un message ou répondez dans les commentaires si ça vous tente, merci ! ",DatePublication=new DateTime(2022,01,05),Medias="Facebook",PublicateurId=40},
                 };
                context.Publication.AddRange(publications);

                context.SaveChanges();
            }
        }
    }
}