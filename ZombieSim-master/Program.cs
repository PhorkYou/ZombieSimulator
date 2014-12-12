using System;
using System.Collections.Generic;
using System.Windows.Forms;
//2014/12/12: Made by Wr3cktangle, modified by Mathieu Bérubé on 2014/12/12
//Créé par Wr3cktangle, modifié par Mathieu Bérubé le 2014/12/12
namespace Zombie_Sim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //2014/12/12: Instead of running a form, I run my ApplicationContext instance.
            //Au lieu de run mon form, je run l'instance de mon ApplicationContext.
            Application.Run(ApplicationContext.Instance);
        }
    }
}