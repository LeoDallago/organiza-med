import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { EnvironmentProviders, makeEnvironmentProviders } from "@angular/core";
import { AuthInterceptor } from "./services/auth.interceptor";
import { AuthService } from "./services/auth.service";
import { LocalStorageService } from "./services/local-storage.service";
import { UsuarioService } from "./services/usuario.service";

export const provideAuthentication = (): EnvironmentProviders => {
    return makeEnvironmentProviders([
        AuthService,
        UsuarioService,
        LocalStorageService,

        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        },
    ]);
}