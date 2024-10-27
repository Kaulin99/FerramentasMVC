use Ferramentas
GO

CREATE TABLE [dbo].[ferramentas]( 
 Id [int] NOT NULL  primary key identity (1,1), 
 descricao [varchar](50) NULL, 
 FabricanteId  int ); 
 GO

 insert into ferramentas(descricao,FabricanteId) values ( 'Martelo',56)
 insert into ferramentas(descricao,FabricanteId) values ( 'Pregos',3)
 GO


create or alter procedure spDeletar(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'delete from ' + @tabela + ' where id = ' +  cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure spConsulta(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure spListagem(
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from ' + @tabela
	exec(@sql)
end
go

create or alter procedure spProximoId(
	@tabela varchar(max)
)
as
begin
	exec('select isnull(max(id)+1,1) as MAIOR from ' + @tabela) 
end
go


-------------------------------------------------
create or alter procedure spInserir(
	@descricao varchar(50),
	@FabricanteId int
)
as
begin
	insert into ferramentas(descricao,FabricanteId)
	values (@descricao,@FabricanteId)
end

go


create or alter procedure spEditar(
	@Id int,
	@descricao varchar(50),
	@FabricanteId int
)
as
begin
	update ferramentas set descricao = @descricao, FabricanteId = @FabricanteId
	where id = @Id
end
go
