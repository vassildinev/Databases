use Bank;
go

create trigger tr_AccountUpdate on Accounts after update
as
	insert into Logs(AccountId, OldSum, NewSum)
	select d.Id, d.Balance, i.Balance from deleted d, inserted i
go

--exec dbo.usp_Withdraw 1, 1000;
