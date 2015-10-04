use TelerikAcademy;

select x.FirstName + ' ' + x.LastName as [Employee Name], a.AddressText as [Employee Address],
	   y.FirstName + ' ' + y.LastName as [Manager Name], b.AddressText as [Manager Address]
from Employees x, Employees y, Addresses a, Addresses b
where x.ManagerID = y.EmployeeID and x.AddressID = a.AddressID and y.AddressID = b.AddressID
order by y.FirstName;