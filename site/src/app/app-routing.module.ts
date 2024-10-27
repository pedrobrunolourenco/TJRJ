import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'home', component: HomeComponent },
  // {path: 'perfil/list', component: PerfilListComponent, canActivate: [AuthGuard] },
  // {path: 'perfil/novo', component: PerfilFormComponent, canActivate: [AuthGuard] },
  // {path: 'usuario/list', component: UsuarioListComponent, canActivate: [AuthGuard] },
  // {path: 'usuario/novo', component: UsuarioFormComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
