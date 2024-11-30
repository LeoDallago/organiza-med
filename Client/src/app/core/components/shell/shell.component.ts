import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Item } from './models/navitem.model';
import { NgClass, NgForOf, NgIf } from '@angular/common';
import { UsuarioTokenViewModel } from '../../auth/models/auth.models';

@Component({
  selector: 'app-shell',
  standalone: true,
  imports: [RouterOutlet, NgForOf, NgClass, RouterLink, NgIf],
  templateUrl: './shell.component.html',
})
export class ShellComponent {

  @Input() usuarioAutenticado?: UsuarioTokenViewModel;
  @Output() logout: EventEmitter<void>


  public itensLogin: Item[] = [
    {
      titulo: 'Login',
      icone: 'bi bi-door-open',
      rota: '/login'
    },
    {
      titulo: 'Registro',
      icone: 'bi bi-person-badge',
      rota: '/registro'
    }
  ]

  public itensMenu: Item[] = [
    {
      titulo: 'Medicos',
      icone: 'bi bi-person',
      rota: '/medico'
    },
    {
      titulo: 'Atendimentos',
      icone: 'bi bi-file-medical',
      rota: '/atendimento'
    }
  ]

  constructor() {
    this.logout = new EventEmitter();
  }

  logoutEfetuado() {
    this.logout.emit();
  }
}