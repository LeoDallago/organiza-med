import { ActivatedRoute, ActivatedRouteSnapshot, ResolveFn, Routes } from "@angular/router";
import { ListarComponent } from "./listar/listar.component";
import { CadastrarComponent } from "./cadastrar/cadastrar.component";
import { EditarComponent } from "./editar/editar.component";
import { ExcluirComponent } from "./excluir/excluir.component";
import { ListarAtendimentoViewModel, VisualizarAtendimentoViewModel } from "./models/atendimento.model";
import { inject } from "@angular/core";
import { AtendimentoService } from "./services/atendimento.service";

const listagemAtendimentoResolver: ResolveFn<ListarAtendimentoViewModel[]> = () => {
    return inject(AtendimentoService).selecionarTodos();
}

const visualizarAtendimentoResolver: ResolveFn<VisualizarAtendimentoViewModel> = (route: ActivatedRouteSnapshot) => {
    const id = route.params['id'];

    return inject(AtendimentoService).selecionarPorId(id);
}

export const atendimentoRoutes: Routes = [
    { path: '', redirectTo: 'listar', pathMatch: 'full' },

    {
        path: 'listar', component: ListarComponent, resolve: {
            atendimentos: listagemAtendimentoResolver
        }
    },

    { path: 'cadastrar', component: CadastrarComponent },

    {
        path: 'editar/:id', component: EditarComponent, resolve: {
            atendimento: visualizarAtendimentoResolver
        }
    },

    {
        path: 'excluir/:id', component: ExcluirComponent, resolve: {
            atendimento: visualizarAtendimentoResolver
        }
    }
]