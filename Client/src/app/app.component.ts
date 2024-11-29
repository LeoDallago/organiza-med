import { Component, LOCALE_ID, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ShellComponent } from "./core/components/shell/shell.component";
import { Observable } from 'rxjs';
import { UsuarioTokenViewModel } from './core/auth/models/auth.models';
import { UsuarioService } from './core/auth/services/usuario.service';
import { LocalStorageService } from './core/auth/services/local-storage.service';
import { AuthService } from './core/auth/services/auth.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ShellComponent, AsyncPipe],
  templateUrl: './app.component.html',
  providers: [{ provide: LOCALE_ID, useValue: 'pt-BR' }]
})
export class AppComponent implements OnInit {
  title = 'OrganizaMed';

  usuarioAutenticado$?: Observable<UsuarioTokenViewModel | undefined>

  constructor(
    private router: Router,
    private usuarioService: UsuarioService,
    private localStorageService: LocalStorageService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.usuarioAutenticado$ = this.usuarioService.usuarioAutenticado;

    const token = this.localStorageService.obterTokenAutenticacao();

    if (!token) return;

    const usuarioPersistido = token.usuario;
    const dataExpiracao = new Date(token.dataExpiracao);

    const tokenValido: boolean = this.authService.validarExpiracaoToken(dataExpiracao);

    if (usuarioPersistido && tokenValido) {
      this.usuarioService.logarUsuario(usuarioPersistido);
    } else {
      this.efetuarLogout()
    }
  }

  efetuarLogout() {
    this.usuarioService.logout();
    this.authService.logout();
    this.localStorageService.limparDadosLocais();
    this.router.navigate(['/login'])
  }
}
