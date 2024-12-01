import { Component, OnInit } from '@angular/core';
import { VisualizarAtendimentoViewModel } from '../models/atendimento.model';
import { AtendimentoService } from '../services/atendimento.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { ListarMedicoViewModel, VisualizarMedicoViewModel } from '../../medico/models/medico.model';
import { MedicoService } from '../../medico/services/medico.service';

@Component({
  selector: 'app-excluir',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './excluir.component.html',
})
export class ExcluirComponent implements OnInit {
  detalhesAtendimento?: VisualizarAtendimentoViewModel;
  //medico?: Observable<ListarMedicoViewModel> ver como pergar o nome do medico

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private atendimentoService: AtendimentoService,
    private medicoService: MedicoService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.detalhesAtendimento = this.route.snapshot.data['atendimento'];
  }

  public excluir() {
    this.atendimentoService.excluir(this.detalhesAtendimento!.id).subscribe({
      next: () => this.processarSucesso(),
      error: (erro) => this.processarFalha(erro),
    })
  }

  private processarSucesso(): void {
    this.toastr.success('Atendimento excluido com sucesso!!')

    this.router.navigate(['/atendimento', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }

}
