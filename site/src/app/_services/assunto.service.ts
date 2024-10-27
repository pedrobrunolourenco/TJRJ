import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from '../environments/environment';
import { ResultModel } from '../_models/result.model';
import { Assunto } from '../_models/assunto.model';

@Injectable({
  providedIn: 'root'
})
export class AssuntoService {

  baseUrl: string = environment.apiUrl;


  constructor(private http: HttpClient) { }

  listarAssuntos(){
    return this.http.get<ResultModel>(this.baseUrl + 'Assunto/ObterAssuntos').pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  incluirAssunto(assunto: Assunto){
    return this.http.post<ResultModel>(this.baseUrl + 'Assunto/IncluirAssunto', assunto ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }



}
