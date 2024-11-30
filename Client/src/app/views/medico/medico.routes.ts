import { ActivatedRoute, ActivatedRouteSnapshot, ResolveFn, Routes } from "@angular/router";
import { ListarMedicoComponent } from "./listar-medico/listar-medico.component";
import { CadastrarMedicoComponent } from "./cadastrar-medico/cadastrar-medico.component";
import { EditarMedicoComponent } from "./editar-medico/editar-medico.component";
import { ExcluirMedicoComponent } from "./excluir-medico/excluir-medico.component";
import { ListarMedicoViewModel, VisualizarMedicoViewModel } from "./models/medico.model";
import { inject } from "@angular/core";
import { MedicoService } from "./services/medico.service";

const listagemMedicoResolver: ResolveFn<ListarMedicoViewModel[]> = () => {
    return inject(MedicoService).selecionarTodos();
}

const visualizarMedicoResolver: ResolveFn<VisualizarMedicoViewModel> = (route: ActivatedRouteSnapshot) => {
    const id = route.params['id'];

    return inject(MedicoService).selecionarPorId(id);
}


export const medicoRoutes: Routes = [
    { path: '', redirectTo: 'listar', pathMatch: 'full' },

    {
        path: 'listar', component: ListarMedicoComponent, resolve: {
            medicos: listagemMedicoResolver
        }
    },

    { path: 'cadastrar', component: CadastrarMedicoComponent },

    {
        path: 'editar/:id', component: EditarMedicoComponent, resolve: {
            medico: visualizarMedicoResolver
        }
    },

    {
        path: 'excluir/:id', component: ExcluirMedicoComponent, resolve: {
            medico: visualizarMedicoResolver
        }
    }

]