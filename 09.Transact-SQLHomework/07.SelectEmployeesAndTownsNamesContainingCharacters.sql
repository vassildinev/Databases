use TelerikAcademy;
go

create function ufn_SelectEmployeesAndTownsNamesContainingCharacters(@chars varchar(50))
returns @table table(Name varchar(50))
as
begin
	declare @NameCursor cursor;
	declare @Name varchar(50);
	set @NameCursor = cursor for
		select e.FirstName from Employees e 
		union
		select i.LastName from Employees i
		union
		select t.Name from Towns t;

	open @NameCursor
	fetch next from @NameCursor
	into @Name;
	while @@fetch_status = 0
	begin
		declare @meetsRequirements bit;
		set @meetsRequirements = 1;

		declare @i int;
		set @i = 1;

		while @i <= len(@Name)
		begin
			declare @c char;
			set @c = lower(substring(@Name, @i, 1));

			if(charindex(@c, lower(@chars)) = 0)
			begin
				set @meetsRequirements = 0;
			end
			set @i += 1;
		end
		if(@meetsRequirements = 1)
		begin
			insert into @table(Name) values (@Name);
		end
		fetch next from @NameCursor
		into @Name;
	end
	return;
end
go

select * from ufn_SelectEmployeesAndTownsNamesContainingCharacters('oistmiahf');