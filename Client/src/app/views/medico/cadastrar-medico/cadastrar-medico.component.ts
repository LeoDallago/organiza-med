import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MedicoService } from '../services/medico.service';
import { InserirMedicoViewModel, MedicoInseridoViewModel } from '../models/medico.model';
import { PartialObserver } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgIf } from '@angular/common';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-cadastrar-medico',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgxMaskDirective],
  providers: [provideNgxMask()],
  templateUrl: './cadastrar-medico.component.html',
})
export class CadastrarMedicoComponent {
  public form: FormGroup;


  constructor(
    private router: Router,
    private fb: FormBuilder,
    private medicoService: MedicoService,
    private toastr: ToastrService
  ) {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(2)]],
      dataNascimento: ['', [Validators.required]],
      telefone: ['', [Validators.required, Validators.maxLength(30)]],
      cpf: ['', [Validators.required, Validators.maxLength(11)]],
      crm: ['', [Validators.required, Validators.maxLength(7)]]
    })
  }

  get nome() {
    return this.form.get('nome')
  }

  get dataNascimento() {
    return this.form.get('dataNascimento')
  }

  get telefone() {
    return this.form.get('telefone')
  }

  get cpf() {
    return this.form.get('cpf')
  }

  get crm() {
    return this.form.get('crm')
  }

  public gravar() {
    if (this.form.invalid) {
      return;
    }

    const inserirMedicoVm: InserirMedicoViewModel = this.form.value;

    const observer: PartialObserver<MedicoInseridoViewModel> = {
      next: (medicoInserido) => this.processarSucesso(medicoInserido),
      error: (erro) => this.processarFalha(erro)
    }

    this.medicoService.inserir(inserirMedicoVm).subscribe(observer);
  }

  private processarSucesso(medico: MedicoInseridoViewModel): void {
    this.toastr.success('Medico cadastrado com sucesso!!')

    this.router.navigate(['/medico', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }
}
