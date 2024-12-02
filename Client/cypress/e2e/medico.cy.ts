describe('Pagina de medico', () => {

    beforeEach(() => {
        cy.visit('/login')

        cy.get('[data-cy=userName]').type('teste')
        cy.get('[data-cy=password]').type('Teste@123')

        cy.get('[data-cy=submit]').click()

        cy.wait(2000)
    })


    it('Deve exibir a lista de medicos', () => {
        cy.visit('/medico')

        cy.contains('Médicos')
    })

    it('Deve acessar pagina de cadastro de medicos', () => {
        cy.visit('/medico/cadastrar')
        cy.contains('Cadastrar Médico')

    })

    it('Deve cadastrar medico', () => {
        cy.visit('/medico/cadastrar')

        cy.get('[data-cy=nome]').type('Cypress')
        cy.get('[data-cy=dataNascimento]').type('1996-12-19')
        cy.get('[data-cy=telefone]').type('12345678')
        cy.get('[data-cy=cpf]').type('11122233344')
        cy.get('[data-cy=crm]').type('12345SC')

        cy.get('[data-cy=submit]').click()
        cy.wait(3000)

        cy.contains('Cypress')
    })
})