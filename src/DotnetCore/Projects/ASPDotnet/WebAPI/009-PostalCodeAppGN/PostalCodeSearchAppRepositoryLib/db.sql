create database DCJSWPA21_PostalCodeSearchAppDb

go

use DCJSWPA21_PostalCodeSearchAppDb

go 

create table PostalCodeSearch (
	Id int primary key identity(1, 1),
	Q varchar(250) unique not null,	
	SearchTime datetime default(sysdatetime()) not null
)

go

create table PostalCode (
	Id bigint primary key identity(1, 1),
	PostalCodeSearchId int references PostalCodeSearch(Id),
	AdminCode2 varchar(50),
	AdminCode1 varchar(50),
	AdminName2 varchar(50),
	Lng real,
	CountryCode varchar(50),
	PostalCode int,
	AdminName1 varchar(50),
	ISO31662 varchar(50),
	PlaceName varchar(50),
	Lat real,
	PostalCodeUrl varchar(max)
)
