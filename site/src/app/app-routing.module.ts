import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssuntoListComponent } from './pages/assunto-list/assunto-list.component';
import { AssuntoFormInclusaoComponent } from './pages/assunto-form-inclusao/assunto-form-inclusao.component';
import { AssuntoFormAlteracaoComponent } from './pages/assunto-form-alteracao/assunto-form-alteracao.component';


const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'home', component: HomeComponent },
  {path: 'assunto/list', component: AssuntoListComponent },
  {path: 'assunto/novo', component: AssuntoFormInclusaoComponent },
  {path: 'assunto/editar', component: AssuntoFormAlteracaoComponent },
  // {path: 'usuario/novo', component: UsuarioFormComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
