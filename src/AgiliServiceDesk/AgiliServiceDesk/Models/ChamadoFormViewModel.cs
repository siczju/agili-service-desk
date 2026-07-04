using System.Collections.Generic;

namespace AgiliServiceDesk.Models
{
    public class ChamadoFormViewModel
    {
        public Chamado Chamado { get; set; } = new Chamado();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}