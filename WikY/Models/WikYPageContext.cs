using System;
using System.Data.Entity;
using System.Linq;

namespace WikY.Models
{
	public class WikYPageContext : DbContext
	{
		// Votre contexte a été configuré pour utiliser une chaîne de connexion « Model1 » du fichier 
		// de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
		// la base de données « WikY.Models.Model1 » sur votre instance LocalDb. 
		// 
		// Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
		// la chaîne de connexion « Model1 » dans le fichier de configuration de l'application.
		public WikYPageContext()
			: base("name=WikYPageBDD")
		{
		}

		// Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
		// sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

		 public virtual DbSet<Article> Articles { get; set; }
		 public virtual DbSet<Commentaire> Commentaires { get; set; }
	}

}