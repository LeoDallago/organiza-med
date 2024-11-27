import { ResolveFn, Routes } from "@angular/router";
import { ListarMedicoComponent } from "./listar-medico/listar-medico.component";
import { CadastrarMedicoComponent } from "./cadastrar-medico/cadastrar-medico.component";
import { EditarMedicoComponent } from "./editar-medico/editar-medico.component";
import { ExcluirMedicoComponent } from "./excluir-medico/excluir-medico.component";
import { ListarMedicoViewModel } from "./models/medico.model";
import { inject } from "@angular/core";
import { MedicoService } from "./services/medico.service";

const listagemMedicoResolver: ResolveFn<ListarMedicoViewModel[]> = () => {
    return inject(MedicoService).selecionarTodos();
}

//implementar visualizar resolver


export const medicoRoutes: Routes = [
    { path: '', redirectTo: 'listar', pathMatch: 'full' },

    {
        path: 'listar', component: ListarMedicoComponent, resolve: {
            medicos: listagemMedicoResolver
        }
    },
    { path: 'cadastrar', component: CadastrarMedicoComponent },
    { path: 'editar/:id', component: EditarMedicoComponent },
    { path: 'excluir/:id', component: ExcluirMedicoComponent }

]