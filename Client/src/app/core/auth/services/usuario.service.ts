import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { UsuarioTokenViewModel } from "../models/auth.models";


@Injectable()
export class UsuarioService {

    private usuarioAutenticadoSubject: BehaviorSubject<UsuarioTokenViewModel | undefined>;


    constructor() {
        this.usuarioAutenticadoSubject = new BehaviorSubject<UsuarioTokenViewModel | undefined>(undefined);
    }

    get usuarioAutenticado() {
        return this.usuarioAutenticadoSubject.asObservable();
    }

    public logarUsuario(usuario: UsuarioTokenViewModel): void {
        this.usuarioAutenticadoSubject.next(usuario);
    }

    public logout(): void {
        this.usuarioAutenticadoSubject.next(undefined);
    }
}