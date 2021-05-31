using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WikY.Models
{
	public class Article
	{
		public int Id { get; set; }

		[Index(IsUnique = true)]
		[DisplayName("Thème")]
		[Required(ErrorMessage = "Le theme est obligatoire")]
		[StringLength(30, ErrorMessage = "La longueur du thème ne doit pas dépasser les 30 caractères")]
		[Remote("ThemeIsUnique", "Article", ErrorMessage = "Ce thème existe déjà")]
		public string Theme { get; set; }

		[DisplayName("Nom d'auteur")]
		[Required(ErrorMessage = "Le nom de l'auteur est obligatoire")]
		[StringLength(30, ErrorMessage = "La longueur du nom d'auteur ne doit pas dépasser les 30 caractères")]
		public string Auteur { get; set; }

		[Required]
		public DateTime DateCreation { get; set; } = DateTime.Now;

		[Required]
		[DataType(DataType.MultilineText)]
		[DisplayName("Contenu de l'article")]
		public string Contenu { get; set; }
		public virtual List<Commentaire> Commentaires { get; set; }

		public override string ToString()
		{
			return $" {Id} - {Theme} - {Auteur} ";
		}
	}
}