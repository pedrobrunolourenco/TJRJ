import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AssuntoListComponent } from './pages/assunto-list/assunto-list.component';
import { AssuntoFormInclusaoComponent } from './pages/assunto-form-inclusao/assunto-form-inclusao.component';
import { AssuntoFormAlteracaoComponent } from './pages/assunto-form-alteracao/assunto-form-alteracao.component';
import { AutorListComponent } from './pages/autor-list/autor-list.component';
import { AutorFormInclusaoComponent } from './pages/autor-form-inclusao/autor-form-inclusao.component';
import { AutorFormAlteracaoComponent } from './pages/autor-form-alteracao/autor-form-alteracao.component';
import { LivroListComponent } from './pages/livro-list/livro-list.component';
import { LivroFormInclusaoComponent } from './pages/livro-form-inclusao/livro-form-inclusao.component';
import { LivroFormAlteracaoComponent } from './pages/livro-form-alteracao/livro-form-alteracao.component';


const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'home', component: HomeComponent },
  {path: 'assunto/list', component: AssuntoListComponent },
  {path: 'assunto/novo', component: AssuntoFormInclusaoComponent },
  {path: 'assunto/editar', component: AssuntoFormAlteracaoComponent },
  {path: 'autor/list', component: AutorListComponent },
  {path: 'autor/novo', component: AutorFormInclusaoComponent },
  {path: 'autor/editar', component: AutorFormAlteracaoComponent },
  {path: 'livro/list', component: LivroListComponent },
  {path: 'livro/novo', component: LivroFormInclusaoComponent },
  {path: 'livro/editar', component: LivroFormAlteracaoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
