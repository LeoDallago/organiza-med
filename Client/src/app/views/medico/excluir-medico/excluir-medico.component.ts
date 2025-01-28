import { Component, OnInit } from '@angular/core';
import { VisualizarMedicoViewModel } from '../models/medico.model';
import { ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
import { MedicoService } from '../services/medico.service';
import { ToastrService } from 'ngx-toastr';
import { NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-excluir-medico',
  standalone: true,
  imports: [RouterLink, NgxMaskPipe],
  providers: [provideNgxMask()],
  templateUrl: './excluir-medico.component.html',
})
export class ExcluirMedicoComponent implements OnInit {
  detalhesMedico!: VisualizarMedicoViewModel;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private medicoService: MedicoService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.detalhesMedico = this.route.snapshot.data['medico'];
  }

  public excluir() {
    this.medicoService.excluir(this.detalhesMedico!.id).subscribe({
      next: () => this.processarSucesso(),
      error: (erro) => this.processarFalha(erro),
    })
  }

  private processarSucesso(): void {
    this.toastr.success('Medico excluido com sucesso!!')

    this.router.navigate(['/medico', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }

}
