using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Models;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    [Required(ErrorMessage = "La propiedad Nombre es requerida.")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "La propiedad Nombre solo debe contener letras y espacios.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "La propiedad Apellido es requerida.")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "La propiedad Apellido solo debe contener letras y espacios.")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "La propiedad Correo es requerida.")]
    [EmailAddress(ErrorMessage = "La propiedad Correo debe ser una dirección de correo electrónico válida.")]
    public string Correo { get; set; } = null!;

    [Required(ErrorMessage = "La propiedad FechaNacimiento es requerida.")]
    public DateTime FechaNacimiento { get; set; }

    public int? Telefono { get; set; }

    [Required(ErrorMessage = "La propiedad PaisResidencia es requerida.")]
    public string PaisResidencia { get; set; }

    [Required(ErrorMessage = "La propiedad RecibirInformacion es requerida.")]
    public bool RecibirInformacion { get; set; }
}
