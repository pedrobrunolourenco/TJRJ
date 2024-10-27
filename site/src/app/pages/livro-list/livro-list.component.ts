import { Component } from '@angular/core';
import { LivroService } from '../../_services/livro.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ResultModel } from '../../_models/result.model';
import { Livro } from '../../_models/livro.model';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-livro-list',
  templateUrl: './livro-list.component.html',
  styleUrl: './livro-list.component.css'
})

export class LivroListComponent {

  livroParaExcluir: any;
  livros: any;
  modalInstance: any;

  constructor(
    private livroService: LivroService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.livroService.listarLivros().subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.livros = response.data;
      }
    }, () => {
      this.toastr.error("Erro ao listar autores");
    });
  }

  editarLivro(livro: Livro) {
    this.router.navigate(['/livro/editar', { livro: JSON.stringify(livro) }]);
  }

  setLivroParaExcluir(livro: any) {
    this.livroParaExcluir = livro;
    const modalElement = document.getElementById('confirmDeleteModal');

    if (modalElement) {
      this.modalInstance = new bootstrap.Modal(modalElement, { backdrop: 'static' });
      this.modalInstance.show();

      modalElement.addEventListener('hidden.bs.modal', () => {
        this.removeBackdrop();
      });
    } else {
      console.error("Modal element 'confirmDeleteModal' not found.");
    }
  }

  fecharModal() {
    if (this.modalInstance) {
      this.modalInstance.hide();
    }
  }

  confirmarExclusao() {
    this.excluirLivro(this.livroParaExcluir);
    this.fecharModal();
  }

  excluirLivro(livro: any) {
    this.livroService.excluirLivro(livro.codigoLivro).subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.toastr.success("Livro Excluído com sucesso");
        this.ngOnInit();
      }
    }, () => {
      this.toastr.error("Erro ao excluir livro");
    });
    this.fecharModal();
  }

  private removeBackdrop() {
    document.querySelectorAll('.modal-backdrop').forEach(backdrop => backdrop.remove());
  }

}


