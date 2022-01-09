using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Sujet:        Projet Inventaire
//Étudiante:    Lamia Ouassaa (2678752)
//Source1:      Notes de cours "Développement en couche logicielle" de Danny Lapointe
//Source2:      Notes de cours "csharp2008V2" de Danny Lapointe
//Source3:      https://www.c-sharpcorner.com/UploadFile/mahesh/understanding-message-box-in-windows-forms-using-C-Sharp/

namespace ProjetInventaire
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AccueilForm());
        }
    }
}
