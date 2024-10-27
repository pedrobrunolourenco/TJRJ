import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './_components/footer/footer.component';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BaseUiComponent } from './_components/base-ui/base-ui.component';
import { LoadInterceptor } from './_interceptors/loading.interceptor';
import { AssuntoListComponent } from './pages/assunto-list/assunto-list.component';
import { AssuntoFormInclusaoComponent } from './pages/assunto-form-inclusao/assunto-form-inclusao.component';
import { AssuntoFormAlteracaoComponent } from './pages/assunto-form-alteracao/assunto-form-alteracao.component';
import { AutorFormAlteracaoComponent } from './pages/autor-form-alteracao/autor-form-alteracao.component';
import { AutorFormInclusaoComponent } from './pages/autor-form-inclusao/autor-form-inclusao.component';
import { AutorListComponent } from './pages/autor-list/autor-list.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    NavbarComponent,
    BaseUiComponent,
    AssuntoListComponent,
    AssuntoFormInclusaoComponent,
    AssuntoFormAlteracaoComponent,
    AutorFormAlteracaoComponent,
    AutorFormInclusaoComponent,
    AutorListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
