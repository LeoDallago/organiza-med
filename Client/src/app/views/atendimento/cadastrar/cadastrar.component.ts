import { AsyncPipe, NgForOf, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AtendimentoService } from '../services/atendimento.service';
import { MedicoService } from '../../medico/services/medico.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AtendimentoInseridoViewModel, InserirAntendimentoViewModel } from '../models/atendimento.model';
import { Observable, PartialObserver } from 'rxjs';
import { ListarMedicoViewModel } from '../../medico/models/medico.model';

@Component({
  selector: 'app-cadastrar',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgForOf, AsyncPipe],
  templateUrl: './cadastrar.component.html',
})
export class CadastrarComponent implements OnInit {
  form: FormGroup;
  medicos?: Observable<ListarMedicoViewModel[]>;

  constructor(
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

  ngOnInit(): void {
    this.medicos = this.medicoService.selecionarTodos();
  }

  public gravar() {
    if (this.form.invalid) {
      return;
    }

    const inserirAtendimentoVm: InserirAntendimentoViewModel = this.form.value;
    console.log(inserirAtendimentoVm);

    const observer: PartialObserver<AtendimentoInseridoViewModel> = {
      next: (atendimentoInserido) => this.processarSucesso(atendimentoInserido),
      error: (erro) => this.processarFalha(erro)
    }

    this.atendimentoService.inserir(inserirAtendimentoVm).subscribe(observer);
  }

  private processarSucesso(atendimento: AtendimentoInseridoViewModel): void {
    this.toastr.success('Atendimento cadastrado com sucesso!!')

    this.router.navigate(['/atendimento', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }

}

