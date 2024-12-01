import { Component, OnInit } from '@angular/core';
import { ListarAtendimentoViewModel } from '../models/atendimento.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { NgForOf } from '@angular/common';

@Component({
  selector: 'app-listar',
  standalone: true,
  imports: [RouterLink, NgForOf],
  templateUrl: './listar.component.html',
})
export class ListarComponent implements OnInit {
  atendimentos: ListarAtendimentoViewModel[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.atendimentos = this.route.snapshot.data['atendimentos']
  }
}
