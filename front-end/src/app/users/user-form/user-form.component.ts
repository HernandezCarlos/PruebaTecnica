import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import countries from 'src/app/data/countries';
import Swal from 'sweetalert2';
import { Usuario } from '../dto/user-dto';
import { UsersService } from '../service/users.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent {
  userForm!: FormGroup;
  countries = countries;
  maxDate: Date;
  minDate: Date;
  params: any;


  constructor( private fb: FormBuilder, private localeService: BsLocaleService,
    private router: Router, private userService: UsersService, private route: ActivatedRoute ) {
      this.params = this.router.getCurrentNavigation()?.extras?.state;
      this.localeService.use('es');
      this.minDate = new Date();
      this.maxDate = new Date();
      this.minDate.setDate(this.minDate.getDate() - 36500);
      this.maxDate.setDate(this.maxDate.getDate());
  }


  ngOnInit(): void {
    this.initForm()
  }

  initForm(): void {
    this.userForm = this.fb.group({
      nombre: ['', [Validators.required, Validators.pattern(/^[a-zA-Z\s]*$/)]],
      apellido: ['', [Validators.required, Validators.pattern(/^[a-zA-Z\s]*$/)]],
      correo: ['', [Validators.required, Validators.email]],
      telefono: ['', [Validators.pattern(/^[0-9]*$/)]],
      fechaNacimiento: ['', Validators.required],
      paisResidencia: ['', Validators.required],
      recibirInformacion: [ '' , [Validators.required]]
    });

    if(this.params) {
      this.userForm.patchValue({
        nombre: this.params.user['nombre'],
        apellido: this.params.user['apellido'],
        correo: this.params.user['correo'],
        telefono: this.params.user['telefono'],
        fechaNacimiento: this.params.user['fechaNacimiento'],
        paisResidencia: this.params.user['paisResidencia'],
        recibirInformacion: this.params.user['recibirInformacion'] ? 'si' : 'no',
      });
    }

  }

  onSubmit(): void {

    Swal.fire({
      title: 'Espere',
      text: 'Guardando la información',
      allowOutsideClick: false
    });
    Swal.showLoading();

      const user: Usuario = {
        nombre: this.userForm.value.nombre,
        apellido: this.userForm.value.apellido,
        correo: this.userForm.value.correo,
        telefono: this.userForm.value.telefono ? this.userForm.value.telefono : null,
        fechaNacimiento: this.userForm.value.fechaNacimiento,
        paisResidencia: this.userForm.value.paisResidencia,
        recibirInformacion: this.userForm.value.recibirInformacion === 'si' ? true : false
      }

    if (this.params) {

      user.idUsuario = this.params.user['idUsuario'];

      const _subscription: Subscription = this.userService.editUser(user).subscribe({
        next: data => {
            Swal.fire({
              title: this.userForm.value.nombre,
              text: 'Se actualizó correctamente',
              allowOutsideClick: false
            }).then(() => {
              this.router.navigate(['/usuarios']);
            })
        },
        error: err => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No se pudo actualizar el usuario. Por favor intentalo nuevamente!',
          })
        },
        complete: () => {
          _subscription.unsubscribe();
        }
      });
    } else {

      const _subscription: Subscription = this.userService.createUser(user).subscribe({
        next: data => {
            Swal.fire({
              title: this.userForm.value.nombre,
              text: 'Se creó correctamente',
              allowOutsideClick: false
            }).then(() => {
              this.router.navigate(['/usuarios']);
            })
        },
        error: err => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No se pudo crear el usuario. Por favor intentalo nuevamente!',
          })
        },
        complete: () => {
          _subscription.unsubscribe()
        }
      });
    }

  }

}
