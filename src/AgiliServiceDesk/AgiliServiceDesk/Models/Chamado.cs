using AgiliServiceDesk.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AgiliServiceDesk.Models
{
    public class Chamado
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;

        public Prioridade Prioridade { get; set; }

        public DateTime DataAbertura { get; set; }

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
