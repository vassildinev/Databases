use TelerikAcademy;

select avg(Salary) as [Department #1 Avg Salary] from
	(select Salary from Employees e
	where e.DepartmentID = 1) x;