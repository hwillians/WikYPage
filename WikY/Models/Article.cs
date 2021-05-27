﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WikY.Models
{
	public class Article
	{
		public int Id { get; set; }

		[DisplayName("Thème")]
		[Required(ErrorMessage ="Le theme est obligatoire")]
		[StringLength(30, ErrorMessage = "Longueur Max=200")]
		public string Theme { get; set; }

		[DisplayName("Nom d'auteur")]
		[Required(ErrorMessage = "Le nom de l'auteur est obligatoire")]
		[StringLength(30, ErrorMessage = "Longueur Max=200")]
		public string Auteur { get; set; }
	
		[Required]
		public DateTime DateCreation { get; set; } = DateTime.Now;
		
		[Required]
		[DataType(DataType.MultilineText)]
		[DisplayName("Contenu de l'article")]
		public string Contenu { get; set; }
		public virtual List<Commentaire> Commentaires { get; set; }
	}
}