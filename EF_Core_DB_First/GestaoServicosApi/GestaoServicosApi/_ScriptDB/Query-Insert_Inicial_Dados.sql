
insert into statusRequisicao (descricao) values ('Criada'); 
insert into statusRequisicao (descricao) values ('Designada para Analista');
insert into statusRequisicao (descricao) values ('Em Atendimento'); 
insert into statusRequisicao (descricao) values ('Pendente');
insert into statusRequisicao (descricao) values ('Concluida'); 
insert into statusRequisicao (descricao) values ('Encerrada');
insert into statusRequisicao (descricao) values ('Cancelada');

insert into statusOrdemTrabalho (descricao) values ('Nova');
insert into statusOrdemTrabalho (descricao) values ('Em Atendimento');
insert into statusOrdemTrabalho (descricao) values ('Pendente');
insert into statusOrdemTrabalho (descricao) values ('Concluida');

insert into analistaSuporte (nome, email, ramal, analistaAtivo) values ('Joao Marcos','joao.marcos@consultoria.com','2365',1);
insert into analistaSuporte (nome, email, ramal, analistaAtivo) values ('Pedro Souza','pedro.souza@consultoria.com','4578',1);
insert into analistaSuporte (nome, email, ramal, analistaAtivo) values ('Cintia Teixeira','cintia.teixeira@consultoria.com','7898',1);


-- script de geração de dados de requisição

declare @requisicaoId bigint, @woId bigint, @analistaId bigint, @descricao varchar(200)

set @descricao = 'Instalação de Software Postman';

insert into requisicao (descricao, dataAbertura, statusId) values (@descricao, GetDate(), 1);
select @requisicaoId = @@IDENTITY;

insert into ordemTrabalho (requisicaoId, descricao, statusOrdemTrabalhoId) values (@requisicaoId, 'Ordem Trabalho Criada', 1)
select @woId = @@IDENTITY;

select @analistaId = analistaSuporteId from analistaSuporte where analistaAtivo = 1;

update ordemTrabalho set descricao = 'Analista Designado', statusOrdemTrabalhoId = 2, analistaSuporteId = @analistaId
where orderTrabalhoId = @woId;

update requisicao set statusId = 2, dataUltimaAtualizacao = GetDate() where requisicaoId = @requisicaoId;


/***

Alterar apenas a descrição na linha 24 (@descricao) para criar novos serviços

exemplos de serviços

Instalação de Software Visual Studio
Configuração de Impressora
Liberação de Acesso a servidor Linux Desenvolvimento
Liberação de Acesso a Banco de Dados MySql Dev
Liberação de Acesso a Banco de Dados SqlServer Prod
Liberação de Firewall Ambiente Homolog
***/

