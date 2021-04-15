using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_test
{
    class Images
    {
        private string filename;

        /// <summary>
        /// Constructeur de la classe Image
        /// </summary>
        /// <remarks>Initialise la variable "filename"</remarks>
        /// <param name="filename"></param>
        public Images(string filename)
        {
            this.filename = filename;
        }

        public string Filename { get => filename; set => filename = value; }

        /// <summary>
        /// Méthode Afficher de la classe Images
        /// </summary>
        /// <returns>la valeur du filename</returns>
        public string Afficher()
        {
            return this.filename;
        }
    }
}
