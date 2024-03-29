USE [BlazorCrudPractice]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 19/02/2024 3:53:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
ALTER PROCEDURE [dbo].[sp_UpdateEmployee]
    @RecId AS INT = 0,
    @EmployeeName AS VARCHAR(100) = '',
    @EmployeeMiddleName AS VARCHAR(100) = '',
    @EmployeeLastName AS VARCHAR(100) = '',
    @EmployeeAge AS INT = 0,
	@EmployeeDateOfBirth DATETIME = NULL,
	@Message_Code AS VARCHAR(100) OUTPUT

-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    UPDATE [dbo].[Employee]
    SET [Employee].[EmployeeName] = @EmployeeName,
        [Employee].[EmployeeMiddleName] = @EmployeeMiddleName,
        [Employee].[EmployeeLastName] = @EmployeeLastName,
        [Employee].[EmployeeAge] = @EmployeeAge,
		[Employee].[EmployeeDateOfBirth] = @EmployeeDateOfBirth
    WHERE [Employee].[RecId] = @RecId


    IF @@ROWCOUNT > 0
    BEGIN
        SET @Message_Code = 'SUCCESS'
    END
END
