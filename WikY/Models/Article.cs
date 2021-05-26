using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WikY.Models
{
	public class Article
	{
		public int Id { get; set; }
		
		[Required]
		[MaxLength(30)]
		public string Theme { get; set; }
	
		[Required]
		[MaxLength(30)]
		public string Auteur { get; set; }
	
		[Required]
		public DateTime DateCreation { get; set; } = DateTime.Now;
		
		[Required]
		[MaxLength(3000)]
		public string Contenu { get; set; }
		public virtual List<Commentaire> Commentaires { get; set; }
	}
}