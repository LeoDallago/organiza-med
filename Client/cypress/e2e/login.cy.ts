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
})