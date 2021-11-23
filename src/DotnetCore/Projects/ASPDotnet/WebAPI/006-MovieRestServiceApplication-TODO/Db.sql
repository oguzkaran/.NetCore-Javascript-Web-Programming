create database DCJSWPA21_MoviesAppDb

go

use DCJSWPA21_MoviesAppDb

go

create table Movie (
	Id bigint primary key identity(1, 1),
	Name nvarchar(256) not null,
    SceneDate date not null,
	Rating bigint default(0),
	Imdb real default(0.0),
	Cost money not null
)

go

create table Director (
	Id int primary key identity(1, 1),
	Name nvarchar(256) not null,
	BirthDate Date not null,
)

go

create table MovieToDirector (
	Id bigint primary key identity(1, 1),
	MovieId bigint foreign key references Movie(Id) not null,
	DirectorId int foreign key references Director(Id) not null
)