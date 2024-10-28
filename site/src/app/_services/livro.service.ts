import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from '../environments/environment';
import { ResultModel } from '../_models/result.model';
import { Livro } from '../_models/livro.model';

@Injectable({
  providedIn: 'root'
})
export class LivroService {

  constructor(private http: HttpClient) { }

  baseUrl: string = environment.apiUrl;


  listarLivros(){
    return this.http.get<ResultModel>(this.baseUrl + 'Livro/ObterLivros').pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  listarAssuntos(id: number){
    return this.http.get<ResultModel>(`${this.baseUrl}Livro/ObterAssuntosDoLivro?codLivro=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }

  listarAutores(id: number){
    return this.http.get<ResultModel>(`${this.baseUrl}Livro/ObterAutoresDoLivro?codLivro=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }


  obterLivroPorId(id: number) {
    return this.http.get<ResultModel>(`${this.baseUrl}Livro/ObterLivrosPorId?codLivro=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }

  incluirLivro(livro: Livro){
    return this.http.post<ResultModel>(this.baseUrl + 'Livro/IncluirLivro', livro ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  incluirAutor(autor: any){
    return this.http.post<ResultModel>(this.baseUrl + 'Livro/IncluirAutor', autor ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  excluirAutor(autor: any){
    return this.http.post<ResultModel>(this.baseUrl + 'Livro/ExcluirAutor', autor ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  incluirAssunto(assunto: any){
    return this.http.post<ResultModel>(this.baseUrl + 'Livro/IncluirAssunto', assunto ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  excluirAssunto(assunto: any){
    return this.http.post<ResultModel>(this.baseUrl + 'Livro/ExcluirAssunto', assunto ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }


  alterarLivro(livro: Livro){
    return this.http.put<ResultModel>(this.baseUrl + 'Livro/AlterarLivro', livro ).pipe(
      map( (response: ResultModel) => {
        return response;
      })
    );
  }

  excluirLivro(id: number) {
    return this.http.delete<ResultModel>(`${this.baseUrl}Livro/ExcluirLivro?codLivro=${id}`).pipe(
      map((response: ResultModel) => {
        return response;
      })
    );
  }


}
