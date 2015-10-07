use TelerikAcademy;
go

create function ufn_GetTownEmployeeTuples()
returns @table table(Town varchar(50), FirstEmployeeName varchar(50), SecondEmployeeName varchar(50))
as
begin
    declare @tempTable table(Town varchar(50), FirstName varchar(50), LastName varchar(50));
    insert into @table select y.Name, y.FirstName, y.LastName from
		(select x.FirstName, x.LastName, t.Name from
			(select e.FirstName, e.LastName, a.TownID from Employees e
			inner join Addresses a on a.AddressID = e.AddressID) x
		inner join Towns t on t.TownID = x.TownID) y;

	insert into @tempTable select * from @table;
	delete @table;

	insert into @table 
	select t.Town, t.LastName, p.LastName from @tempTable t
	join @tempTable p on p.Town = t.Town
	where t.LastName != p.LastName;

	return
end
go

select * from ufn_GetTownEmployeeTuples();