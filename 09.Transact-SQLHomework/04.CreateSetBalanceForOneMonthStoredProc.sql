use Bank;
go

create proc dbo.usp_SetNewBalance(@personId int, @rate float, @months int = 1)
as
	declare @sum float
	select @sum = Balance from Accounts
	where PersonId = @personId;

	set @sum = dbo.ufn_GetNewSum(@sum, @rate, @months);

	update Accounts
	set Balance = @sum
	where PersonId = @personId;
	go
go

declare @personId int
set @personId = 1;

exec dbo.usp_SetNewBalance 1, 10;

select Balance from Accounts
where PersonId = @personId;