export interface InserirMedicoViewModel {
    nome: string,
    dataNascimento: string,
    telfone: string,
    cpf: string,
    crm: string
}

export interface MedicoInseridoViewModel {
    id: string,
    nome: string,
    dataNascimento: string,
    telfone: string,
    cpf: string,
    crm: string
}

export interface ListarMedicoViewModel {
    id: string,
    nome: string,
    telefone: string,
    crm: string
}

export interface MedicoExcluidoViewModel { }

export interface EditarMedicoViewModel extends InserirMedicoViewModel { }

export interface MedicoEditadoViewModel extends MedicoInseridoViewModel { }

export interface VisualizarMedicoViewModel extends MedicoInseridoViewModel { }