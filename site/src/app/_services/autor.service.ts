import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from '../environments/environment';
import { ResultModel } from '../_models/result.model';
import { Autor } from '../_models/autor.model';

@Injectable({
  providedIn: 'root'
})
export class AutorService {

  constructor(private http: HttpClient) { }

  baseUrl: string = environment.apiUrl;


  listarAutores(){
    return this.http.get<ResultModel>(this.baseUrl + 'Autor/ObterAutores').pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }


  obterAutorPorId(id: number) {
    return this.http.get<ResultModel>(`${this.baseUrl}Autor/ObterAutorPorId?id=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }

  incluirAutor(autor: Autor){
    return this.http.post<ResultModel>(this.baseUrl + 'Autor/IncluirAutor', autor ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  alterarAutor(autor: Autor){
    return this.http.put<ResultModel>(this.baseUrl + 'Autor/AlterarAutor', autor ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  excluirAutor(id: number) {
    return this.http.delete<ResultModel>(`${this.baseUrl}Autor/ExcluirAutor?codAu=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }


}
