import { Component } from '@angular/core';
import { AutorService } from '../../_services/autor.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ResultModel } from '../../_models/result.model';
import { Autor } from '../../_models/autor.model';

@Component({
  selector: 'app-autor-form-inclusao',
  templateUrl: './autor-form-inclusao.component.html',
  styleUrl: './autor-form-inclusao.component.css'
})
export class AutorFormInclusaoComponent {

  constructor(private autorService: AutorService,
    private toastr: ToastrService,
    private router: Router
    )
    {
    }

    autor: Autor = {
      CodigoAutor: 0,
      Nome: ''
    };

    gravarAutor() {
      this.autorService.incluirAutor(this.autor).subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.toastr.success("Autor gravado com sucesso!" );
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
