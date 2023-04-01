using back_end.Models;

namespace back_end.DTO
{
    public class ActivityDTO
    {

        public DateTime Fecha { get; set; }
    
        public string Detalle { get; set; } = null!;

        public string NombreUsuario { get; set; }
    }
}
