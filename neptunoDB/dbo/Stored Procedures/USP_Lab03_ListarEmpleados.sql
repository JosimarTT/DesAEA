  CREATE PROCEDURE USP_Lab03_ListarEmpleados
  AS
  select IdEmpleado, Nombre+' '+Apellidos AS Empleado
  from Empleados