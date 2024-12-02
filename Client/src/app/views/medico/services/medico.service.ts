import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { EditarMedicoViewModel, InserirMedicoViewModel, ListarMedicoViewModel, MedicoEditadoViewModel, MedicoExcluidoViewModel, MedicoInseridoViewModel, VisualizarMedicoViewModel } from '../models/medico.model';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

  private readonly url = `${environment.API_URL}/api/medicos`;

  constructor(private http: HttpClient) { }

  inserir(inserirMedicoVm: InserirMedicoViewModel): Observable<MedicoInseridoViewModel> {
    return this.http.post<MedicoInseridoViewModel>(this.url, inserirMedicoVm)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  editar(id: string, editarMedicoVm: EditarMedicoViewModel): Observable<MedicoEditadoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.put<MedicoEditadoViewModel>(urlCompleto, editarMedicoVm)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  excluir(id: string): Observable<MedicoExcluidoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.delete<MedicoExcluidoViewModel>(urlCompleto)
      .pipe(catchError(this.processarFalha))
  }

  selecionarTodos(): Observable<ListarMedicoViewModel[]> {
    return this.http.get<ListarMedicoViewModel[]>(this.url)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  selecionarPorId(id: string): Observable<VisualizarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`
    return this.http.get<VisualizarMedicoViewModel>(urlCompleto)
      .pipe(map(this.processarDados), catchError(this.processarFalha))
  }

  private processarDados(resposta: any) {
    if (resposta.sucesso) return resposta.dados;
    throw new Error('erro ao mapear dados');
  }

  private processarFalha(resposta: any) {
    return throwError(() => new Error(resposta.error.dados))
  }
}
