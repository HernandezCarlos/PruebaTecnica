export interface Usuario {
  idUsuario?: number;
  nombre: string;
  apellido: string;
  correo: string;
  fechaNacimiento: string;
  telefono?: number;
  paisResidencia: string;
  recibirInformacion: boolean;
}


// export interface UsuarioDTO {
//   idUsuario: number;
//   nombre: string;
//   apellido: string;
//   correo: string;
//   fechaNacimiento: string;
//   telefono: number;
//   paisResidencia: string;
//   recibirInformacion: boolean;
// }
