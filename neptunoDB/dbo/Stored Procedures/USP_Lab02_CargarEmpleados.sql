CREATE PROCEDURE [dbo].[USP_Lab02_CargarEmpleados]
AS
SELECT IdEmpleado, Nombre+' '+Apellidos AS Empleado
FROM Empleados