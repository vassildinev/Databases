use TelerikAcademy;
go

-- specify your path to the assembly!
CREATE ASSEMBLY StrConcat FROM 'D:\My Documents\2_KURS\PROGRAMMING\Telerik Academy\GitHub\Databases\09.Transact-SQLHomework\StrConcat\StrConcat\bin\Debug\StrConcat.dll';
GO

CREATE AGGREGATE dbo.StrConcat (@input nvarchar(200), @separator nvarchar(10)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.[StrConcat.StrConcat];
go

select t.Name as [Town], dbo.StrConcat([Full Name], ',') from
	(select e.FirstName + ' ' + e.LastName as [Full Name], a.TownId from Employees e
	inner join Addresses a on a.AddressID = e.AddressID) x
inner join Towns t on t.TownID = x.TownID
group by t.Name;

DROP AGGREGATE dbo.StrConcat
DROP ASSEMBLY StrConcat