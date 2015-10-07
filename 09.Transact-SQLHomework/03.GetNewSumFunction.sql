-- let's say if rate is 12% and months is 6 then result rate is 6 / 12 * 12% = 6%
create function dbo.ufn_GetNewSum(@sum float, @rate float, @months float)
returns float
as
begin
	declare @resultRate float;
	set @resultRate = @rate * @months / 12;
	return @sum * (1 + @resultRate / 100);
end
go

declare @result float
set @result = dbo.ufn_GetNewSum(200, 5, 9);

select @result as Result;