use TelerikAcademy;

begin tran
	alter table Departments nocheck constraint FK_Departments_Employees
	delete from Employees
	where DepartmentID = 3
rollback tran