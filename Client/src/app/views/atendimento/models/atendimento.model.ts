import { MedicoInseridoViewModel } from "../../medico/models/medico.model";

export interface InserirAntendimentoViewModel {
    tipo: string,
    horaInicio: string,
    horaTermino: string,
    medico: MedicoInseridoViewModel
}

export interface AtendimentoInseridoViewModel {
    id: string,
    tipo: string,
    horaInicio: string,
    horaTermino: string,
    medico: MedicoInseridoViewModel
}

export interface AtendimentoExcluidoViewModel { }

export interface ListarAtendimentoViewModel {
    id: string,
    tipo: string,
    medico: MedicoInseridoViewModel
}

export interface EditarAtendimentoViewModel extends InserirAntendimentoViewModel { }

export interface AtendimentoEditadoViewModel extends AtendimentoInseridoViewModel { }

export interface VisualizarAtendimentoViewModel extends ListarAtendimentoViewModel { }
