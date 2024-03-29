USE [BlazorCrudPractice]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateEmployee]    Script Date: 19/02/2024 10:14:57 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DECLARE @JData NVARCHAR(MAX) = N'{


--  "EmployeeName": "asd",
--  "EmployeeMiddleName": "asd",
--  "EmployeeLastName": "asd",
--  "EmployeeAge": 30,
--  "EmployeeDateOfBirth": "2024-02-15T15:30:00"

--}'

--DECLARE @Message_Code VARCHAR(100)
--EXEC [sp_CreateEmployee] @jdata,  @Message_Code OUTPUT

ALTER PROCEDURE [dbo].[sp_CreateEmployee]
    @JData VARCHAR(MAX) ,
    --   @EmployeeName AS VARCHAR(100) = '',
    --   @EmployeeMiddleName AS VARCHAR(100) = '',
    --   @EmployeeLastName AS VARCHAR(100) = '',
    --   @EmployeeAge AS INT = 0,
    --@EmployeeDateOfBirth AS VARCHAR(20) = NULL,
    @Message_Code AS VARCHAR(100) OUTPUT

-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN


    IF (ISJSON(@JData) = 0)
        RETURN;

    -- Create temporary table for location.
    SELECT *
    INTO [#tmpEmployee]
    FROM
        OPENJSON(@JData)
        WITH
        (
            [RecId] [INT] '$.RecId',
            [EmployeeName] [VARCHAR](100) '$.EmployeeName',
            [EmployeeMiddleName] [VARCHAR](100) '$.EmployeeMiddleName',
            [EmployeeLastName] [VARCHAR](100) '$.EmployeeLastName',
            [EmployeeAge] [INT] '$.EmployeeAge',
            [EmployeeDateOfBirth] [VARCHAR](100) '$.EmployeeDateOfBirth',
			[EmployeeDateOfBirthStr] [VARCHAR](100) '$.EmployeeDateOfBirthStr'
        );



    IF ((SELECT COUNT(*)FROM [#tmpEmployee]) = 0)
        RETURN;

    INSERT INTO [dbo].[Employee]
    (
        [EmployeeName],
        [EmployeeMiddleName],
        [EmployeeLastName],
        [EmployeeAge],
        [EmployeeDateOfBirth]
    )
    SELECT [#tmpEmployee].[EmployeeName],
           [#tmpEmployee].[EmployeeMiddleName],
           [#tmpEmployee].[EmployeeLastName],
           [#tmpEmployee].[EmployeeAge],
           CONVERT(DATE,[#tmpEmployee].[EmployeeDateOfBirth],103)
    FROM [#tmpEmployee]

    --SET @AppointmentID = SCOPE_IDENTITY()
    --  VALUES
    --  (   @EmployeeName,       -- EmployeeName - varchar(100)
    --      @EmployeeMiddleName, -- EmployeeMiddleName - varchar(100)
    --      @EmployeeLastName,   -- EmployeeLastName - varchar(100)
    --      @EmployeeAge,         -- EmployeeAge - int
    --CONVERT(DATE,@EmployeeDateOfBirth,103)
    --      )


    IF @@ROWCOUNT > 0
    BEGIN
        SET @Message_Code = 'SUCCESS'
    END

	DROP TABLE [#tmpEmployee]

END
