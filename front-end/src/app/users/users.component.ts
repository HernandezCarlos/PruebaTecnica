import { Component } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Usuario } from './dto/user-dto';
import { UsersService } from './service/users.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  userList: Usuario[] = [];
  loading = false;
  msgError : string = '';

  constructor(private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
    this.loading = true;
    const _subscription: Subscription = this.userService.getUsers().subscribe({
      next: data => {
          this.userList = data as Usuario[];
          this.loading = false;
      },
      error: err => {
        this.msgError = 'Hubo un error obteniendo la información. Por favor intentelo nuevamente.'
        this.loading = false;
      },
      complete: () => {
        _subscription.unsubscribe()
      }
    })
  }

  deleteUser(user: Usuario): void {

    Swal.fire({
      title: 'Esta seguro?',
      text: `Esta seguro que desea borrar a ${user.nombre}`,
      showConfirmButton: true,
      showCancelButton: true,
    }).then(res => {
      if (res.value) {
        const _subscription: Subscription = this.userService.deleteUser(user.idUsuario!).subscribe({
          next: data => {
              this.ngOnInit()
          },
          error: err => {
            console.log(err)
          },
          complete: () => {
            _subscription.unsubscribe();
          }
        });
      }
    });
  }

  editUser(user: Usuario): void {
    this.router.navigate(['usuarios/editar'], {state: { user }});
  }

}
