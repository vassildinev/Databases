use TelerikAcademy;

select avg(Salary) as [Sales Department's Avg Salary] from
	(select Salary from Employees e
	where e.DepartmentID = (select d.DepartmentID from Departments d
							where d.Name = 'Sales')) x;