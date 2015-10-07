use Bank;
go

create proc dbo.usp_GetPeopleFullNames
as
	select FirstName + ' ' + LastName as [Full Name] from People;
go

exec dbo.usp_GetPeopleFullNames;