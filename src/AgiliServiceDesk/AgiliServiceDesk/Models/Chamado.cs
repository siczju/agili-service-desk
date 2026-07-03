using AgiliServiceDesk.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AgiliServiceDesk.Models
{
    public class Chamado
    {
        public int Id;

        [Required]
        [MaxLength(150)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;
        public Prioridade prioridade;
        public DateTime DataAbertura;
        public int CategoriaId;
        public Categoria Categoria { get; set; } = null

    }
}
