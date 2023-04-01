import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ActivitiesComponent } from './activities.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

export const activitiesRoutes: Routes = [
  { path: '', component: ActivitiesComponent },
];

@NgModule({
  declarations: [
    ActivitiesComponent
  ],
  exports: [
    ActivitiesComponent
  ],
  imports: [
    RouterModule.forChild(activitiesRoutes),
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ActivitiesModule { }
