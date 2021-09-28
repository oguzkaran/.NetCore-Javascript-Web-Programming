create table TodoInfo (
	Id int primary key identity(1, 1),
	Title nvarchar(128) not null,
	Text nvarchar(max) not null,
	CreateDateTime datetime default(SYSDATETIME()) not null,
	LastUpdate datetime default(SYSDATETIME()) not null,
	Completed bit default(0) not null	
)