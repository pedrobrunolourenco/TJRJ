import { Component } from '@angular/core';
import { Autor } from '../../_models/autor.model';
import { AutorService } from '../../_services/autor.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-autor-form-alteracao',
  templateUrl: './autor-form-alteracao.component.html',
  styleUrl: './autor-form-alteracao.component.css'
})
export class AutorFormAlteracaoComponent {

  constructor(private autorService: AutorService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  )
  {
  }

  autor: Autor = {
    CodigoAutor: 0,
    Nome: ''
  };

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const autorParam = params.get('autor');
      if (autorParam) {
        var json = JSON.parse(autorParam);
        console.log(json);
        this.autor.CodigoAutor = json.autor.codigoAutor;
        this.autor.Nome = json.autor.nome;
      }
    });
  }

  gravarAutor() {
    this.autorService.alterarAutor(this.autor).subscribe((response: ResultModel) => {
    if(response.sucesso == true){
      this.toastr.success("Autor alterado com sucesso!" );
      this.router.navigate(['/autor/list']);
    }
    if(response.sucesso == false){
      response.mensagens.forEach(mensagem => {
        this.toastr.error(mensagem);
      });
    }
    }, (erro) => {
      this.toastr.error("Erro ao gravar autor");
    });
  }


}
