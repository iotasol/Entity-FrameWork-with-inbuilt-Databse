CREATE PROCEDURE [dbo].[DepartmentList]
	
AS
	Select * from Department where IsDeleted=0
RETURN 0
