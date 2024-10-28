# Gerenciamento de Ferramentas - ASP.NET MVC
Este é um projeto ASP.NET MVC para o gerenciamento de ferramentas, implementando operações de CRUD (Create, Read, Update, Delete) utilizando procedures armazenadas no banco de dados SQL Server. O projeto permite o cadastro, edição, listagem e exclusão de ferramentas, com funcionalidades adicionais para garantir que o campo de Id seja tratado como auto-incremento.

# Funcionalidades
Listar Ferramentas: Exibe uma lista de todas as ferramentas registradas no sistema.
Cadastrar Nova Ferramenta: Permite adicionar uma nova ferramenta ao sistema. O campo Id é auto-incrementado e ocultado do usuário.
Editar Ferramenta: Possibilita a edição das informações de uma ferramenta existente. O campo Id fica desabilitado durante a edição.
Excluir Ferramenta: Confirmação de exclusão antes de remover uma ferramenta do sistema.
Estrutura do Projeto
Modelos: Contém a classe FerramentasViewModel que representa a estrutura dos dados.
Views: Interface do usuário para exibir, cadastrar, editar e excluir ferramentas.
Controllers: Contém o controlador FerramentasController que gerencia as operações CRUD.
Procedures Armazenadas: O projeto utiliza procedures SQL para listar, inserir, atualizar e deletar registros, promovendo uma interação otimizada com o banco de dados.

# Banco de Dados
O projeto foi desenvolvido para SQL Server e utiliza as seguintes procedures armazenadas para manipulação dos dados:

spProximoId: Retorna o próximo Id disponível.
spDeletar: Exclui um registro com base no Id fornecido.
spConsulta: Exibe os dados de uma ferramenta específica.
spListagem: Lista todas as ferramentas.
spInserir: Insere uma nova ferramenta.
spAlteraJogos: Atualiza uma ferramenta existente.
