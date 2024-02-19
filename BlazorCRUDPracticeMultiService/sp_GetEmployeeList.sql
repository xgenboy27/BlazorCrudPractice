USE [BlazorCrudPractice]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeList]    Script Date: 19/02/2024 3:52:52 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
ALTER PROCEDURE [dbo].[sp_GetEmployeeList]

-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    SELECT [Employee].[RecId],
           [Employee].[EmployeeName],
           [Employee].[EmployeeMiddleName],
           [Employee].[EmployeeLastName],
           [Employee].[EmployeeAge],
           ISNULL([Employee].[EmployeeDateOfBirth], '01/01/1900') AS [EmployeeDateOfBirth],
           CONVERT(VARCHAR(10), ISNULL([Employee].[EmployeeDateOfBirth], '01/01/1900'), 103) AS [EmployeeDateOfBirthStr]
    FROM [dbo].[Employee]
END
