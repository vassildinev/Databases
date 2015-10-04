use TelerikAcademy;

select FirstName, LastName, AddressText from Employees e, Addresses a
where a.AddressID = e.AddressId;
