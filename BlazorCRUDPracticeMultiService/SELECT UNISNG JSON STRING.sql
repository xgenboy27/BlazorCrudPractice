DECLARE @JData NVARCHAR(MAX)
    = N'{
  "EmployeeName": "test",
  "EmployeeMiddleName": "test",
  "EmployeeLastName": "test",
  "EmployeeAge": 30,
  "EmployeeDateOfBirth": "2024-02-15T15:30:00"

}'


SELECT *
FROM
    OPENJSON(@JData)
    WITH
    (
        [EmployeeName] NVARCHAR(50) '$.EmployeeName',
        [EmployeeMiddleName] NVARCHAR(50) '$.EmployeeMiddleName',
        [EmployeeLastName] NVARCHAR(50) '$.EmployeeLastName',
        [EmployeeAge] INT '$.EmployeeAge',
        [EmployeeDateOfBirth] DATETIME '$.EmployeeDateOfBirth'
    )