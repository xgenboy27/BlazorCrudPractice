USE [BlazorCrudPractice]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 19/02/2024 3:52:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
ALTER PROCEDURE [dbo].[sp_DeleteEmployee]
    @RecId AS INT = 0,
	@Message_Code AS VARCHAR(100) OUTPUT
-- WITH ENCRYPTION, RECOMPILE, EXECUTE AS CALLER|SELF|OWNER| 'user_name'
AS
BEGIN
    DELETE FROM [dbo].[Employee] WHERE	[Employee].[RecId] = @RecId
	IF @@ROWCOUNT > 0

	BEGIN

	 SET @Message_Code = 'SUCCESS'
	END
	ELSE
	BEGIN

	 SET @Message_Code = ERROR_MESSAGE() 
	END
END
