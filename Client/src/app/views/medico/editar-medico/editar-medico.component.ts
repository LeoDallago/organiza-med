import { Component, OnInit } from '@angular/core';
import { EditarMedicoViewModel, MedicoEditadoViewModel } from '../models/medico.model';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PartialObserver } from 'rxjs';
import { MedicoService } from '../services/medico.service';
import { NgIf } from '@angular/common';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-editar-medico',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, RouterLink, NgxMaskDirective],
  providers: [provideNgxMask()],
  templateUrl: './editar-medico.component.html',
})
export class EditarMedicoComponent implements OnInit {
  public form: FormGroup;


  constructor(
    private route: ActivatedRoute,
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

  ngOnInit(): void {
    const medico = this.route.snapshot.data['medico'];
    var nome = this.nome
    this.form.patchValue(medico);
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

    const id = this.route.snapshot.params['id'];
    const editarMedicoVm: EditarMedicoViewModel = this.form.value;
    console.log(editarMedicoVm)

    const observer: PartialObserver<MedicoEditadoViewModel> = {
      next: (medicoEditado) => this.processarSucesso(medicoEditado),
      error: (erro) => this.processarFalha(erro)
    }

    this.medicoService.editar(id, editarMedicoVm).subscribe(observer);
  }

  private processarSucesso(categoria: MedicoEditadoViewModel): void {
    this.toastr.success('Medico editado com sucesso!!')

    this.router.navigate(['/medico', 'listar'])
  }

  private processarFalha(erro: any) {
    this.toastr.error(erro);
  }
}
