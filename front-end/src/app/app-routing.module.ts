import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'usuarios', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
  { path: 'actividades', loadChildren: () => import('./activities/activities.module').then(m => m.ActivitiesModule) },
  { path: '**', pathMatch: 'full', redirectTo: 'usuarios' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
