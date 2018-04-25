using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace prbd_msn_tuto
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Donner une valeur à la propriété "DataProperty" qui est utilisée comme dossier de base
            // dans App.config pour la connection string vers la DB.
            var dbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

            // Création du modèle.
            var model = new Entities();
            model.Database.Log = Console.Write;

            // Affichage du nombre d'instances de l'entité 'Member'
            Console.WriteLine(model.Members.Count());

            // Affichage du pseudo de tous les membres.
            foreach (var m in model.Members)
                Console.WriteLine(m.Pseudo);

            // Affichage du pseudo de tous les membres triés de manière décroissante
            foreach (var m in model.Members.OrderByDescending(m => m.Pseudo)) ;
        }

    }
}
