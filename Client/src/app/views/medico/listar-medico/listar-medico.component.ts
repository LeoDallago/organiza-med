import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ListarMedicoViewModel } from '../models/medico.model';
import { NgForOf } from '@angular/common';
import { NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-listar-medico',
  standalone: true,
  imports: [RouterLink, NgForOf, RouterLink, NgxMaskPipe],
  providers: [provideNgxMask()],
  templateUrl: './listar-medico.component.html',
})
export class ListarMedicoComponent implements OnInit {
  medicos: ListarMedicoViewModel[] = []


  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicos = this.route.snapshot.data['medicos']
  }

}
