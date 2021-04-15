using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_test
{
    /// <summary>
    /// Classe Annonce comportant les informations d'une annonce
    /// </summary>
    /// <remarks>Les informations de chaque annonces seront contenu dans un objet de la classe Annonce</remarks>
    class Annonce
    {
        /// <summary>
        /// Instantiation des variables
        /// </summary>
        /// <remarks>Les variables sont des "private string"</remarks>             
        private string zipcode;
        private string city;
        private string proximity;
        private string category;
        private string type;
        private string transaction;
        private string price;
        private string description;
        List<Images> ListeImage= new List<Images>();
        
        

        /// <summary>
        /// Getter et setter de la variable zipcode
        /// </summary>
        public string Zipcode { get => zipcode; set => zipcode = value; }

        /// <summary>
        /// Getter et setter de la variable city
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Getter et setter de la variable prox
        /// </summary>
        public string Prox { get => proximity; set => proximity = value; }

        /// <summary>
        /// Getter et setter de la variable category
        /// </summary>
        public string Category { get => category; set => category = value; }

        /// <summary>
        /// Getter et setter de la variable type
        /// </summary>
        public string Type { get => type; set => type = value; }

        /// <summary>
        /// Getter et setter de la variable transaction
        /// </summary>
        public string Transaction { get => transaction; set => transaction = value; }

        /// <summary>
        /// Getter et setter de la variable price
        /// </summary>
        public string Price { get => price; set => price = value; }

        /// <summary>
        /// Getter et setter de la variable description
        /// </summary>
        public string Description { get => description; set => description = value; }
       

       

        


        /// <summary>
        /// Constructeur de la classe Annonce
        /// </summary>       
        /// <param name="zipcode"></param>
        /// <param name="city"></param>
        /// <param name="prox"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="transaction"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>       
        /// <param name="image"></param>
        public Annonce(string zipcode, string city, string prox, string category, string type, string transaction, string price,
                       string description,Images image)
        {            
            this.zipcode = zipcode;
            this.city = city;
            this.proximity = prox;
            this.category = category;
            this.type = type;
            this.transaction = transaction;
            this.price = price;
            this.description = description;
            this.ListeImage.Add(image);
            
        }

        /// <summary>
        /// Méthode ToString() qui permet d'afficher tous les éléments d'un objet
        /// </summary>
        /// <returns>retourne les informations d'une annonce</returns>
        public string ToString()
        {            
                return category + " " + type + " " + transaction + " " + '\n' + zipcode + " " + city + '\n' + " A proximité : " + proximity + '\n' + "prix : " + price + '\n' + description + '\n' + '\n';
            
        }

        /// <summary>
        /// Méthode get de ListeImage
        /// </summary>
        /// <returns>La valeur des Images dans la liste</returns>
        public string getImage()
        {
            for (int i = 0; i<ListeImage.Count(); i++)
            {
                return ListeImage[i].Filename;
            }
            return "";
        }

        /// <summary>
        /// Initialise la valeur des images
        /// </summary>
        /// <param name="filename"></param>
        public void setImage(string filename)
        {
            for(int i=0;i<ListeImage.Count();i++)
            {
                this.ListeImage[i].Filename = filename;
            }
        }

        /// <summary>
        /// Méthode qui affiche les valeurs des objets contenus dans la liste ListeImage
        /// </summary>
        /// <returns>la valeur de chaque objet Images</returns>
        public string Afficher()
        {
            for (int i = 0; i < ListeImage.Count(); i++)
            {
                return this.ListeImage[i].Afficher();
            }
            return "";
           


        }
    }


}
