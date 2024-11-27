import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Item } from './models/navitem.model';
import { NgClass, NgForOf } from '@angular/common';

@Component({
  selector: 'app-shell',
  standalone: true,
  imports: [RouterOutlet, NgForOf, NgClass, RouterLink],
  templateUrl: './shell.component.html',
  styleUrl: './shell.component.scss'
})
export class ShellComponent {
  public itensMenu: Item[] = [
    {
      titulo: 'Medicos',
      icone: 'bi bi-person',
      rota: '/medico'
    }
  ]
}