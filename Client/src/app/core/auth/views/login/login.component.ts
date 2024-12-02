import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { UsuarioService } from '../../services/usuario.service';
import { LocalStorageService } from '../../services/local-storage.service';
import { Router } from '@angular/router';
import { AutenticarUsuarioViewModel, TokenViewModel } from '../../models/auth.models';
import { NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './login.component.html',
})
export class LoginComponent {
  form: FormGroup;


  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private usuarioService: UsuarioService,
    private localStorageService: LocalStorageService,
    private toastr: ToastrService,
  ) {
    this.form = this.fb.group({
      userName: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(30),
        ],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
        ],
      ],
    })

  }

  get userName() {
    return this.form.get('userName');
  }

  get password() {
    return this.form.get('password');
  }

  public entrar() {
    if (this.form.invalid) {

      return;
    }

    const loginUsuario: AutenticarUsuarioViewModel = this.form.value;

    const observer = {
      next: (res: TokenViewModel) => this.processarSucesso(res),
      error: (erro: Error) => this.processarFalha(erro)
    }

    this.authService
      .login(loginUsuario)
      .subscribe(observer)
  }

  private processarSucesso(res: TokenViewModel) {
    this.usuarioService.logarUsuario(res.usuario);
    this.localStorageService.salvarTokenAutenticacao(res);

    this.router.navigate(['/dashboard']);
  }

  private processarFalha(err: any) {
    this.toastr.error(err);
  }
}
