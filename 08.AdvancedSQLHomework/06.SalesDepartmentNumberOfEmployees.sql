use TelerikAcademy;

select count(*) as [Total Sales Department Employees] from
	(select * from Employees e
		where e.DepartmentID = (select d.DepartmentID from Departments d
								where d.Name = 'Sales')) x;