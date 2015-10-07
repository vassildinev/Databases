use Bank;
go

create proc dbo.usp_Withdraw(@accountId int, @amount float)
as
	declare @balance float
	select @balance = Balance from Accounts
	where Id = @accountId;

	if(@balance > @amount)
	begin
		set @balance = @balance - @amount;
		update Accounts
		set Balance = @balance
		where Id = @accountId
	end
go

create proc dbo.usp_Deposit(@accountId int, @amount float)
as
	declare @balance float
	select @balance = Balance from Accounts
	where Id = @accountId;

	begin
		set @balance = @balance + @amount;
		update Accounts
		set Balance = @balance
		where Id = @accountId
	end
go