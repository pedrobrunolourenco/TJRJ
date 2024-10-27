import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AssuntoService } from '../../_services/assunto.service';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-assunto-list',
  templateUrl: './assunto-list.component.html',
  styleUrl: './assunto-list.component.css'
})
export class AssuntoListComponent implements OnInit {

  constructor(private assuntoService: AssuntoService,
    private toastr: ToastrService) {}

  assuntos : any;

  ngOnInit(): void {

    this.assuntoService.listarAssuntos().subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.assuntos = response.data;
        console.log(this.assuntos);
      }
     }, () => {
        this.toastr.error("Erro ao listar Perfis");
     });

  }

  excluirAssunto(assunto: any){
     console.log(assunto);
  }

  editarAssunto(assunto: any){
    console.log(assunto);
  }


}



