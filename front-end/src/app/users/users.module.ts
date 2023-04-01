import { UsersComponent } from './users.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserFormComponent } from './user-form/user-form.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { esLocale } from 'ngx-bootstrap/locale';
defineLocale('es', esLocale);


export const usersRoutes: Routes = [
  { path: '', component: UsersComponent },
  { path: 'crear', component: UserFormComponent },
  { path: 'editar', component: UserFormComponent },
];


@NgModule({
  declarations: [
    UsersComponent,
    UserFormComponent
  ],
  exports: [
    UsersComponent,
    UserFormComponent
  ],
  imports: [
    RouterModule.forChild(usersRoutes),
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ]
})
export class UsersModule { }
