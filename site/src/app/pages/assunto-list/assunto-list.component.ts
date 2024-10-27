import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AssuntoService } from '../../_services/assunto.service';
import { ResultModel } from '../../_models/result.model';
import { Router } from '@angular/router';
import { Assunto } from '../../_models/assunto.model';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-assunto-list',
  templateUrl: './assunto-list.component.html',
  styleUrl: './assunto-list.component.css'
})
export class AssuntoListComponent implements OnInit {

  constructor(private assuntoService: AssuntoService,
    private router: Router,
    private toastr: ToastrService) {}

  assuntoParaExcluir: any;
  assuntos : any;

  ngOnInit(): void {

    this.assuntoService.listarAssuntos().subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.assuntos = response.data;
      }
     }, () => {
        this.toastr.error("Erro ao listar Perfis");
     });

  }

  editarAssunto(assunto: Assunto){
    this.assuntoService.assunto = assunto;
    this.router.navigate(['/assunto/editar', { assunto: JSON.stringify(assunto) }]);
  }


  setAssuntoParaExcluir(assunto: any) {
    this.assuntoParaExcluir = assunto;
    const modalElement = document.getElementById('confirmDeleteModal');
    const modalInstance = new bootstrap.Modal(modalElement); // Usando a importação
    modalInstance.show();
    const backdrop = document.querySelector('.modal-backdrop');
    if (backdrop) {
      backdrop.remove();
    }
  }

  confirmarExclusao() {
    this.excluirAssunto(this.assuntoParaExcluir);
  }

  excluirAssunto(assunto: any) {

    console.log(assunto)

    this.assuntoService.excluirAssunto(assunto.assunto.codigoAssunto).subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.toastr.error("Assunto Excluído com sucesso");
        this.ngOnInit();
      }
     }, () => {
        this.toastr.error("Erro ao excluir assunto");
     });

     const modalElement = document.getElementById('confirmDeleteModal');
     const modalInstance = bootstrap.Modal.getInstance(modalElement);
     modalInstance.hide();
     const backdrop = document.querySelector('.modal-backdrop');
     if (backdrop) {
       backdrop.remove();
     }

  }
}



