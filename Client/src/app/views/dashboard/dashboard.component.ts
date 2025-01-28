import { Component, OnInit } from '@angular/core';
import { ListarAtendimentoViewModel } from '../atendimento/models/atendimento.model';
import { AtendimentoService } from '../atendimento/services/atendimento.service';
import { Observable } from 'rxjs';
import { AsyncPipe, NgForOf, NgIf } from '@angular/common';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgForOf, NgIf, AsyncPipe],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  atendimentos?: Observable<ListarAtendimentoViewModel[]>
  public mensagem: string = ''

  public diaHoje = new Date()
  public dateOptions: Intl.DateTimeFormatOptions = {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric'
  };
  public dataFormatada = new Intl.DateTimeFormat('pt-BR', this.dateOptions).format(this.diaHoje)

  constructor(private atendimentosService: AtendimentoService) { }

  ngOnInit(): void {
    this.atendimentos = this.atendimentosService.selecionarTodos();
  }

  periodoMensagem() {
    var hora = this.diaHoje.getHours()

    if (hora > 12 && hora < 18) {
      this.mensagem = 'Boa tarde'
    } else if (hora >= 18 && hora < 24) {
      this.mensagem = 'Boa noite'
    } else {
      this.mensagem = 'Bom dia'
    }

    return this.mensagem
  }
}

