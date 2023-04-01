using System;
using System.Collections.Generic;

namespace back_end.Models;

public partial class Actividad
{
    public long IdActividad { get; set; }

    public DateTime CreateDate { get; set; }

    public long IdUsuario { get; set; }

    public string ActividadInfo { get; set; } = null!;
}
