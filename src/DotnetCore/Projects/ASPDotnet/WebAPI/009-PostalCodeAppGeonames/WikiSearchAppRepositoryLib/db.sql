create database DCJSWPA21_PostalCodeAppDb

go

use DCJSWPA21_PostalCodeAppDb

go 

create table PostalCodeInfo (
	Id int primary key identity(1, 1),
	postalCode int unique not null,
	SearchTime datetime default(sysdatetime()) not null
)

go

create table Geoname (
	Id bigint primary key identity(1, 1),
	SearchId int foreign key references PostalCodeInfo(Id),
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
