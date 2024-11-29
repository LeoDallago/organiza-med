import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { ListarMedicoViewModel } from '../models/medico.model';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

  private readonly url = `${environment.API_URL}/api/medicos`;

  constructor(private http: HttpClient) { }

  selecionarTodos(): Observable<ListarMedicoViewModel[]> {
    return this.http.get<ListarMedicoViewModel[]>(this.url)
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
