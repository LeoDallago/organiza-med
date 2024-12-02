import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { AutenticarUsuarioViewModel, RegistrarUsuarioViewModel, TokenViewModel } from "../models/auth.models";
import { catchError, map, Observable, throwError } from "rxjs";


@Injectable()
export class AuthService {
    private apiUrl: string = environment.API_URL;


    constructor(private http: HttpClient) { }

    public registrar(registro: RegistrarUsuarioViewModel): Observable<TokenViewModel> {
        const urlCompleto = `${this.apiUrl}/registrar`

        return this.http.post<TokenViewModel>(urlCompleto, registro)
            .pipe(map(this.processarDados), catchError((err: any) => this.processarFalha(err)));
    }

    public login(loginUsuario: AutenticarUsuarioViewModel) {
        const urlCompleto = `${this.apiUrl}/autenticar`

        return this.http.post<TokenViewModel>(urlCompleto, loginUsuario).pipe(map(this.processarDados), catchError((err: any) => this.processarFalha(err)));
    }

    public logout() {
        const urlCompleto = `${this.apiUrl}/sair`
        return this.http.post(urlCompleto, {});
    }

    public validarExpiracaoToken(dataExpiracao: Date): boolean {
        return dataExpiracao > new Date();
    }

    private processarDados(resposta: any): TokenViewModel {

        if (resposta.sucesso) return resposta.dados;
        throw new Error('Erro ao mapear token do usuario')
    }

    private processarFalha(resposta: any) {

        return throwError(() => new Error(resposta.error.erros[0]))
    }
}