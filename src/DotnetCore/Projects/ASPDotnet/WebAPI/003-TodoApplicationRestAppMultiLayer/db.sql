create table TodoInfo (
	Id int primary key identity(1, 1),
	Title nvarchar(128) not null,
	Text nvarchar(max) not null,
	CreateDateTime datetime not null,
	LastUpdate datetime not null,
	Completed bit not null	
)