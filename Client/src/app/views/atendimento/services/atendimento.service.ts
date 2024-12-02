import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AtendimentoEditadoViewModel, AtendimentoExcluidoViewModel, AtendimentoInseridoViewModel, EditarAtendimentoViewModel, InserirAntendimentoViewModel, ListarAtendimentoViewModel, VisualizarAtendimentoViewModel } from '../models/atendimento.model';
import { catchError, map, Observable, throwError } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root'
})
export class AtendimentoService {

  private readonly url = `${environment.API_URL}/api/atendimentos`

  constructor(private http: HttpClient) { }

  inserir(inserirAtendimentoVm: InserirAntendimentoViewModel): Observable<AtendimentoInseridoViewModel> {
    return this.http.post<AtendimentoInseridoViewModel>(this.url, inserirAtendimentoVm)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  editar(id: string, editarAtendimentoVm: EditarAtendimentoViewModel): Observable<AtendimentoEditadoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.put<AtendimentoEditadoViewModel>(urlCompleto, editarAtendimentoVm)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  excluir(id: string): Observable<AtendimentoExcluidoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.delete<AtendimentoEditadoViewModel>(urlCompleto)
      .pipe(catchError(this.processarFalha))
  }

  selecionarTodos(): Observable<ListarAtendimentoViewModel[]> {
    return this.http.get<ListarAtendimentoViewModel[]>(this.url)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  selecionarPorId(id: string): Observable<VisualizarAtendimentoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.get<VisualizarAtendimentoViewModel>(urlCompleto)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  private processarDados(resposta: any) {
    if (resposta.sucesso) return resposta.dados;
    throw new Error('erro ao mapear dados');
  }

  private processarFalha(resposta: any) {
    return throwError(() => new Error(resposta.error.erros[0]))
  }
}
