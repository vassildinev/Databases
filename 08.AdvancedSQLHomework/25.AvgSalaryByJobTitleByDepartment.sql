use TelerikAcademy;

select * from
	(select d.Name, JobTitle, avg(Salary) as Salary from Employees e
	inner join Departments d on d.DepartmentID = e.DepartmentID
	group by d.Name, JobTitle) x
order by x.Name, JobTitle, Salary;