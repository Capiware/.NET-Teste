# Bem-Vindo a Capiware Technologies!

Este repo foi criado para que você desenvolva seu teste técnico! 


# Instruções

1. Clone o repo
2. Crie um branch seguindo o Git Flow
3. Desenvolva seu codigo
4. Commite usando o padrao de commits abaixo
5. Abra um PR e solicite Revisão do seu código
6. Espere o feedback

## Padrão de commit
> Este é o padrão que usamos no dia a dia
https://www.conventionalcommits.org/en/v1.0.0-beta.4/

## GitFlow
> Este é o flow que usamos no nosso dia a dia.

![](https://cdn.discordapp.com/attachments/1152311301964578916/1217513413958307920/image.png?ex=66044cba&is=65f1d7ba&hm=3dd981541a0c9a75d757584f77f9ffa0b8aa45fb65c69f31b19054fdee82500f&=)

# Problema

Estamos desenvolvendo um sistema para um lava-car, e precisamos que você faca algumas coisas, para nos ajudar a entregar este sistema. Precisamos que você desenvolva uma API CRUD(Create, Read, Update e Delete).
Os endpoints criados vão ser com o intuito de criar uma entrada e saída de serviço.

Será necessário os seguintes endpoints implementados:
POST - Criar servico
> Este endpoint deve realizar o cadastro de uma ordem de serviço
 
POST - Finalizar servico
> Este endpoint deve encerrar uma ordem de serviço

PUT - Atualizar informacoes de servico
> Este endpoint deve atualizar as informações de um serviço

GET - Listar servicos
> Este endpoint deve listar todos os serviços nao concluídos

GET - Consultar servico
> Este endpoint deve trazer todas as informações de uma ordem de serviço

GET - Resumo do dia
> Este endpoint deve trazer quantidade de serviços que foram realizados no dia X, e o total financeiro do respectivo dia.

DELETE - Excluir Servico
> Este endpoint pode somente excluir serviços nao concluídos.

Desenvolva os endpoints usando as boas praticas, lembre que seu código como um todo será analisado, seja a forma que construiu suas classes, seja os testes que possa ter desenvolvido, seja a maneira que desenvolveu os métodos, até a organização de pastas.