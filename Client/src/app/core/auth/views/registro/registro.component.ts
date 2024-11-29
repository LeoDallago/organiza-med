import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UsuarioService } from '../../services/usuario.service';
import { RegistrarUsuarioViewModel } from '../../models/auth.models';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [NgIf, ReactiveFormsModule],
  templateUrl: './registro.component.html',
})
export class RegistroComponent {
  form: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private usuarioService: UsuarioService,
  ) {
    this.form = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(30)]],
    })
  }

  get userName() {
    return this.form.get('userName');
  }

  get email() {
    return this.form.get('email');
  }
  get password() {
    return this.form.get('password');
  }

  public registrar() {
    if (this.form.invalid) {
      return;
    }

    const registro: RegistrarUsuarioViewModel = this.form.value;
    console.log(registro)

    this.authService.registrar(registro).subscribe((res) => {
      console.log(res);
      this.usuarioService.logarUsuario(res.usuario)
      this.router.navigate(['/dashboard'])
    });

  }
}
