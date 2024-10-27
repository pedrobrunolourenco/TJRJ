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

  constructor(private http: HttpClient) { }

  baseUrl: string = environment.apiUrl;


  private _assunto: Assunto | null = null;

  set assunto(value: Assunto) {
    this._assunto = value;
  }

  get assunto(): Assunto | null {
    return this._assunto;
  }



  listarAssuntos(){
    return this.http.get<ResultModel>(this.baseUrl + 'Assunto/ObterAssuntos').pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }


  obterAssuntoPorId(id: number) {
    return this.http.get<ResultModel>(`${this.baseUrl}Assunto/ObterAssuntoPorId?id=${id}`).pipe(
      map((response: ResultModel) => {
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

  alterarAssunto(assunto: Assunto){
    return this.http.put<ResultModel>(this.baseUrl + 'Assunto/AlterarAssunto', assunto ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  excluirAssunto(id: number) {
    console.log("IDDDDDDD",id)
    return this.http.delete<ResultModel>(`${this.baseUrl}Assunto/ExcluirAssunto?codAs=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }


}
