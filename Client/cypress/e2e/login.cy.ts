describe('Pagina de Login', () => {

    it('Deve acessar a pagina de login', () => {
        cy.visit('/login')
        cy.contains('Login de Usuario')
    })

    it('Deve apresentar mensagens de campo vazio', () => {
        cy.visit('/login')
        cy.contains('O login precisa ser preenchido!')
        cy.contains('A senha precisa ser preenchida!')
    })

    it('Deve logar corretamente', () => {
        cy.visit('/login')

        cy.get('[data-cy=userName]').type('teste')
        cy.get('[data-cy=password]').type('Teste@123')

        cy.get('[data-cy=submit]').click()

        cy.wait(3000)

        cy.contains('olá, teste')
    })
})