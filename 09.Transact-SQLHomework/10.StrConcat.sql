use TelerikAcademy;
go

CREATE ASSEMBLY StrConcat FROM 'D:\My Documents\2_KURS\PROGRAMMING\Telerik Academy\GitHub\Databases\09.Transact-SQLHomework\StrConcat\StrConcat\bin\Debug\StrConcat.dll';
GO

CREATE AGGREGATE dbo.StrConcat (@input nvarchar(200), @separator nvarchar(10)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.[StrConcat.StrConcat];
go

select dbo.StrConcat(FirstName, '=') as Meaningless from Employees
where DepartmentID = 1;

DROP AGGREGATE dbo.StrConcat
DROP ASSEMBLY StrConcat