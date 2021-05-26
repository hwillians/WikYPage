using System;
using System.ComponentModel.DataAnnotations;

namespace WikY.Models
{
	public class Commentaire
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Auteur { get; set; }
		public DateTime DateCreation { get; set; } = DateTime.Now;

		[Required]
		[MaxLength(300)]
		public string Contenu { get; set; }
		public virtual Article Article { get; set; }
	}
}