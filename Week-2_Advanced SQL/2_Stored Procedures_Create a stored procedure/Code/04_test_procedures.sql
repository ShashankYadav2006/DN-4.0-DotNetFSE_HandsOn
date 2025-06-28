
EXEC sp_InsertEmployee 
    @FirstName = 'Sanjay', 
    @LastName = 'Yadav', 
    @DepartmentID = 3, 
    @Salary = 7200.00, 
    @JoinDate = '2024-07-01';

EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
