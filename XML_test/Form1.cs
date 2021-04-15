using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Timers;
using System.Threading;

namespace XML_test
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialisation de la fenêtre
        /// </summary>
        public Form1()
        {
            InitializeComponent();           
        }

        ///<summary>Instanciation et initialisation des variables</summary>
        XmlDocument XmlDoc = new XmlDocument();
        List<Annonce> annonceListe = new List<Annonce>();
        Annonce annonce;
        Images image= new Images("");       
        
        string zipcode;
        string city;
        string proximity;
        string category;
        string type;
        string transaction;
        string price;
        string description;
        string image1;        

        System.DateTime StopTime;
        System.Threading.Timer myTimer;



        ///<summary>Chargement du fichier XML au chargement de la fenêtre et recupération des différents éléments à afficher</summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDoc.Load("https://dev.agence-plus.net/file.ashx?mod=advert&code=NTY&filename=_export.xml");

            ///<summary>Description du chemin de noeud à parcourir</summary>
            ///<remarks>Ici on se focalise sur les noeuds de la balise "Bien"</remarks>
            ///<value>On affecte aux variables créées précédemment la valeur des balises nommées</value>
            ///<remarks>Initialisation d'un objet de la classe "Annonce" avec les informations disponibles</remarks>
            ///<remarks>Ajout de l'objet "Annonce", initialisé précedemment, dans la liste du même type</remarks>
            XmlNodeList xmlNodeList = XmlDoc.SelectNodes("/export/Agence/Biens/Bien");
            foreach (XmlNode Node in xmlNodeList)
            {
                proximity = Node["Proximity"].InnerText;
                category = Node["Category"].InnerText;
                type = Node["Type"].InnerText;
                transaction = Node["TransactionType"].InnerText;
                price = Node["SoldPrice"].InnerText;

                //Création d'un nouvelle objet annonce puis insertion dans la liste d'annonce
                annonce = new Annonce("", "", proximity, category, type, transaction, price, "", image );
                annonceListe.Add(annonce);               
            }

            ///<summary>Description du chemin de noeud à parcourir</summary>
            ///<remarks>Ici on se focalise sur les noeuds de la balise "BienAddress"</remarks>
            ///<value>On affecte aux variables la valeur des balises nommées</value>
            ///<remarks>On complète les informations des objets de la liste avec celles que l'on récupère ici</remarks>
            xmlNodeList = XmlDoc.SelectNodes("/export/Agence/Biens/Bien/BienAddress");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                zipcode = xmlNode["Zipcode"].InnerText;
                city = xmlNode["ZipcodeCity"].InnerText;

                //Insertion dans la liste d'annonce
                for (int i = 0; i < annonceListe.Count; i++)
                {
                    annonceListe[i].Zipcode = zipcode;
                    annonceListe[i].City = city;
                }

            }

            ///<summary>Description du chemin de noeud à parcourir</summary>
            ///<remarks>Ici on se focalise sur les noeuds de la balise "Description"</remarks>
            xmlNodeList = XmlDoc.SelectNodes("/export/Agence/Biens/Bien/Descriptions/Description");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                
                string text = XmlDoc.OuterXml.Substring(XmlDoc.OuterXml.IndexOf("<![CDATA[") + "<![CDATA[".Length);
                text = text.Remove(text.IndexOf("]]>"));
                description = text;               

                //Insertion dans la liste d'annonce
                for (int i = 0; i < annonceListe.Count; i++)                {

                    annonceListe[i].Description = description;
                }
            }

            ///<summary>Description du chemin de noeud à parcourir</summary>
            ///<remarks>Ici on se focalise sur les noeuds de la balise "Document afin de récupérer le lien des images"</remarks>
            xmlNodeList = XmlDoc.SelectNodes("/export/Agence/Biens/Bien/Documents/Document");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                for (int i = 0; i < annonceListe.Count; i++)
                {                
                    image1 = xmlNode["Filename"].InnerText;              
                    // Insertion dans la liste d'annonce
                    annonceListe[i].setImage(image1);
                }

               
            }                      
            
            ///<summary>Initialisation des variables du timer</summary>
            StopTime = System.DateTime.Now.AddMinutes(1);
            myTimer = new System.Threading.Timer(TimerCallback, null, 0, 5000);           

        }                      

        /// <summary>
        /// Fonction d'appel du timer
        /// </summary>
        /// <remarks>On execute dans cette fonction l'affichage des différents éléments</remarks>
        /// <param name="state"></param>
        private void TimerCallback(object state)
        {
            if (System.DateTime.Now >= StopTime)
            {
                myTimer.Dispose();
                return;
            }
            while (true)
            {
                for (int i = 0; i < annonceListe.Count(); i++)
                {//Affichage des annonces
                    richTextBox1.Invoke(new MethodInvoker(delegate
                    {
                        richTextBox1.Text = annonceListe[i].ToString();
                    }));

                   //Affichage des images
                    pictureBox1.ImageLocation = annonceListe[i].Afficher();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;               
                      
                    //Attente de 5 seconde avant de lancer la prochaine annonce
                    Thread.Sleep(5000);
                }
            }
        }
    }
}

