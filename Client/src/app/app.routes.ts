import { CanMatchFn, Router, Routes, UrlTree } from '@angular/router';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { UsuarioService } from './core/auth/services/usuario.service';

const authGuard: CanMatchFn = (): Observable<boolean | UrlTree> => {

    const router = inject(Router);
    const usuarioService = inject(UsuarioService);

    return usuarioService.usuarioAutenticado.pipe(map(usuario => {
        if (!usuario) return router.parseUrl('/login')

        return true;
    }));
}

const authUserGuard: CanMatchFn = (): Observable<boolean | UrlTree> => {

    const router = inject(Router);
    const usuarioService = inject(UsuarioService);

    return usuarioService.usuarioAutenticado.pipe(map(usuario => {
        if (usuario) return router.parseUrl('/dashboard')

        return true;
    }));
}

export const routes: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    {
        path: 'dashboard',
        loadComponent: () => import('./views/dashboard/dashboard.component')
            .then((c) => c.DashboardComponent),
        canMatch: [authGuard]
    },

    {
        path: 'registro',
        loadComponent: () => import('./core/auth/views/registro/registro.component')
            .then((c) => c.RegistroComponent),
        canMatch: [authUserGuard]
    },

    {
        path: 'login',
        loadComponent: () => import('./core/auth/views/login/login.component')
            .then((c) => c.LoginComponent),
        canMatch: [authUserGuard]
    },

    {
        path: 'medico',
        loadChildren: () => import('./views/medico/medico.routes')
            .then((m) => m.medicoRoutes),
        canMatch: [authGuard]
    }
];
