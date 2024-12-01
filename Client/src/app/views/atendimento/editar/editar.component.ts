import { AsyncPipe, NgForOf, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MedicoService } from '../../medico/services/medico.service';
import { ToastrService } from 'ngx-toastr';
import { AtendimentoService } from '../services/atendimento.service';
import { AtendimentoEditadoViewModel, EditarAtendimentoViewModel } from '../models/atendimento.model';
import { Observable, PartialObserver } from 'rxjs';
import { ListarMedicoViewModel } from '../../medico/models/medico.model';

@Component({
  selector: 'app-editar',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, RouterLink, AsyncPipe, NgForOf],
  templateUrl: './editar.component.html',
})
export class EditarComponent implements OnInit {
  form: FormGroup;
  medicos?: Observable<ListarMedicoViewModel[]>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private atendimentoService: AtendimentoService,
    private medicoService: MedicoService,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      tipo: ['', [Validators.required]],
      horaInicio: ['', [Validators.required]],
      horaFim: ['', [Validators.required]],
      medicoId: ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
    const atendimento = this.route.snapshot.data['atendimento'];
    this.form.patchValue(atendimento);

    this.medicos = this.medicoService.selecionarTodos();
  }

  get tipo() {
    return this.form.get('tipo')
  }

  get horaInicio() {
    return this.form.get('horaInicio')
  }

  get horaFim() {
    return this.form.get('horaFim')
  }

  get medicoId() {
    return this.form.get('medicoId')
  }

  public gravar() {
    if (this.form.invalid) {
      return;
    }

    const id = this.route.snapshot.params['id'];
    const editarAtendimentoVm: EditarAtendimentoViewModel = this.form.value;
    console.log(editarAtendimentoVm)

    const observer: PartialObserver<AtendimentoEditadoViewModel> = {
      next: (atendimentoEditado) => this.processarSucesso(atendimentoEditado),
      error: (erro) => this.processarFalha(erro)
    }

    this.atendimentoService.editar(id, editarAtendimentoVm).subscribe(observer);
  }

  private processarSucesso(categoria: AtendimentoEditadoViewModel): void {
    this.toastr.success('Atendimento editado com sucesso!!')

    this.router.navigate(['/atendimento', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }
}
