using System;
using System.ComponentModel.DataAnnotations;

namespace WikY.Models
{
	public class Commentaire
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Le nom de l'auteur est obligatoire")]
		[MaxLength(30)]
		public string Auteur { get; set; }
		public DateTime DateCreation { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Le contenu du commentaire est obligatoire")]
		[DataType(DataType.MultilineText)]
		[MaxLength(300)]
		public string Contenu { get; set; }

		public virtual int ArticleId { get; set; }

		public virtual Article Article { get; set; }
	}
}