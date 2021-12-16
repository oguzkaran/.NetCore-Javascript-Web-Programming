create database DCJSWPA21_TodoDb

go

use TodoDb

go

create table TodoInfo (
	Id int primary key identity(1, 1),
	Title nvarchar(128) not null,
	Description nvarchar(max) not null,
	CreateDateTime datetime default(SYSDATETIME()) not null,	
	Completed bit default(0) not null
)

go

create table ItemInfo (
	Id int primary key identity(1, 1),
	TodoId int foreign key references TodoInfo(Id) not null,
	Text nvarchar(max) not null,
	CreateDateTime datetime default(SYSDATETIME()) not null,
	LastUpdate datetime default(SYSDATETIME()) not null,
	Completed bit default(0) not null
)

go
