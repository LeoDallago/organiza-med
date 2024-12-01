import { MedicoInseridoViewModel } from "../../medico/models/medico.model";

export interface InserirAntendimentoViewModel {
    tipo: string,
    horaInicio: string,
    horaFim: string,
    medicoId: string
}

export interface AtendimentoInseridoViewModel {
    id: string,
    tipo: string,
    horaInicio: string,
    horaFim: string,
    medicoId: string
}

export interface AtendimentoExcluidoViewModel { }

export interface ListarAtendimentoViewModel {
    id: string,
    tipo: string,
    medico: string
}

export interface EditarAtendimentoViewModel extends InserirAntendimentoViewModel { }

export interface AtendimentoEditadoViewModel extends AtendimentoInseridoViewModel { }

export interface VisualizarAtendimentoViewModel extends AtendimentoInseridoViewModel { }
