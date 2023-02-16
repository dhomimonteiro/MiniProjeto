create database MiniProjeto_T13

use MiniProjeto_T13

create table usuario 
(
	id_Usuario int not null	identity primary key,
	nome_Usuario varchar(50) not null,
	login_Usuario varchar(30) not null unique,
	senha_Usuario varchar(30) not null,
	obs_Usuario	varchar(255) null,
	status_Usuario	varchar(30)	not null		
)

insert into usuario
	(nome_Usuario, login_Usuario, senha_Usuario, obs_Usuario, status_Usuario)
values
	('Dhomi', 'dhomi', '123', 'sem observação', 'ativo')

select * from usuario

create table categoria
(
	id_Categoria int	not null	identity primary key,
	nome_Categoria varchar(50) not null,
	descricao_Categoria	varchar(255) null,
	obs_Categoria varchar(255) null,
	status_Categoria varchar(30) not null		
)

insert into categoria
	(nome_Categoria, descricao_Categoria, obs_Categoria, status_Categoria)
values
	('Frios', 'Comida gelada', 'sem observação', 'ativo')

select * from categoria

create table produto
(
	id_Produto int not null	identity primary key,
	nome_Produto varchar(50) not null unique,
	id_Categoria_Produto int not null,
	valorcusto_Produto decimal(10,2) not null,
	valorvenda_Produto decimal(10,2) not null,
	descricao_Produto varchar(255) null,
	qtde_Produto int not null default 0,
	datacadastro_Produto smalldatetime not null default getdate(),
	obs_Produto	varchar(255) null,
	status_Produto	varchar(30)	not null

	constraint FK_Id_Categoria_Produto foreign key (id_Categoria_Produto) references categoria (id_Categoria)
)

insert into produto
	(nome_Produto, id_Categoria_Produto, valorcusto_Produto, valorvenda_Produto, descricao_Produto, qtde_Produto, datacadastro_Produto, obs_Produto, status_Produto)
values
	('Spaguetti', 4, 15.00, 20.00, '', 5, '', '', 'Ativo')

select * from produto
 
drop table produto

create table MovProduto
(
	id_MovProduto int not null identity,
	id_Produto_MovProduto int not null,
	id_Usuario_MovProduto int not null,
	qtde_MovProduto	int	not null,
	dataCadastro_MovProduto	smalldatetime not null default getdate(),
	obs_MovProduto varchar(255) null,
	status_MovProduto varchar(30) not null		

	constraint FK_Id_Produto_MovProduto foreign key (id_Produto_MovProduto) references produto (id_Produto),
	constraint FK_Id_Usuario_MovProduto foreign key (id_Usuario_MovProduto) references usuario (id_Usuario)
)


select * from MovProduto

create table cliente
(
	id_Cliente int	not null identity primary key,
	nome_Cliente varchar(50) not null,
	cnpj_Cliente	char(14) not null	unique,
	dataNasc_Cliente date not null,
	telefone1_Cliente char(14)	not null,
	telefone2_Cliente char(14)	null,
	logradouro_Cliente varchar(50)	not null,
	bairro_Cliente varchar(50)	not null,
	numero_Cliente int not null,
	complemento_Cliente	varchar(50)	null,
	cidade_Cliente varchar(50)	not null,
	uf_Cliente char(2) not null,
	obs_Cliente	varchar(255) null,
	status_Cliente	varchar(30)	not null		
)

create table venda
(
	id_Venda int not null identity primary key,
	id_Cliente_Venda int not null,
	id_Usuario_Venda int not null,
	dataRealizacao_Venda smalldatetime not null default getdate(),
	obs_Venda varchar(255) null,
	status_Venda varchar(50) not null		

	constraint FK_Id_Cliente_Venda foreign key (id_Cliente_Venda) references cliente (id_Cliente),
	constraint FK_Id_Usuario_Venda foreign key (id_Usuario_Venda) references usuario (id_Usuario)
)

create table ItemVenda
(
	id_ItemVenda int not null identity primary key,
	id_Produto_ItemVenda int not null,
	id_Venda_ItemVenda int not null,
	obs_ItemVenda varchar(255) null,
	status_ItemVenda varchar(50) not null		

	constraint FK_Id_Produto_ItemVenda foreign key (id_Produto_ItemVenda) references produto (id_Produto),
	constraint FK_Id_Venda_ItemVenda foreign key (id_Venda_ItemVenda) references venda (id_Venda)
)

select * from usuario
select * from categoria
select * from produto
select * from MovProduto
select * from cliente
select * from venda
select * from ItemVenda



set dateformat dmy
update produto set id_Categoria_Produto = '1',nome_Produto = 'Salame',valorcusto_Produto = '12.00',valorvenda_Produto = '15.00',descricao_Produto = '',qtde_Produto = '5',dataCadastro_Produto = '16/02/2023',obs_Produto = 'Nome alterado 2',status_Produto = 'Ativo'where id_Produto = 5"