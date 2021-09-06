using System;
using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Data
{
    public class ReadMovieDTO
    {
        [Key] [Required] public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório.")]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "O gênero deve possuir no máximo 30 caracteres.")]
        public string Genre { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600 minutos.")]
        public int Duration { get; set; }

        public string ConsultedAt { get; set; }
    }
}