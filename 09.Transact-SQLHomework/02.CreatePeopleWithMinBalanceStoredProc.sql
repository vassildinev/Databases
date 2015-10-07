use Bank;
go

create proc dbo.usp_GetSalariesHigherThan(@minBalance int)
as
	select p.FirstName, p.LastName, a.Balance from People p
	inner join Accounts a on a.PersonId = p.Id
	where a.Balance > @minBalance;
go

exec dbo.usp_GetSalariesHigherThan 200;