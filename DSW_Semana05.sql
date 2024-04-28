
CREATE database DSW_Semana_05
go

USE DSW_Semana_05
GO

-- tabla medico
CREATE TABLE medico (
    codigo INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50),
    apellido VARCHAR(80),
    especialidad VARCHAR(100),
    documento VARCHAR(8),
    estado int, 
	fechaRegistro datetime
);
GO




-- procedimiento almacenado usp_medico_crud
alter PROCEDURE usp_medico_crud
    @indicador VARCHAR(20),
    @codigo INT = NULL,
    @nombre VARCHAR(50) = NULL,
    @apellido VARCHAR(80) = NULL,
    @especialidad VARCHAR(100) = NULL,
    @documento VARCHAR(8) = NULL
AS
BEGIN
	set nocount on 

    IF @indicador = 'I' -- Insertar
    BEGIN
        INSERT INTO medico (nombre, apellido, especialidad, documento, estado, fechaRegistro)
        VALUES (@nombre, @apellido, @especialidad, @documento, 1, GETDATE());
		select 1
    END

    IF @indicador = 'U' -- Actualizar
    BEGIN
        UPDATE medico
        SET nombre = @nombre, apellido = @apellido, especialidad = @especialidad, documento = @documento, fechaActualizacion= getdate()
		where codigo=  @codigo
		select 1
    END
    
	IF @indicador = 'D' -- Eliminar (borrado lógico)
    BEGIN
        UPDATE medico SET estado = 0, fechaEliminacion=GETDATE() WHERE codigo = @codigo;
		select 1
    END
    
	IF @indicador = 'lista' -- Consultar todos
    BEGIN
		SELECT codigo, nombre, apellido, especialidad, documento FROM medico WHERE estado = 1;
    END

    IF @indicador = 'getXID' -- Consultar por ID
    BEGIN
        SELECT codigo, nombre, apellido, especialidad, documento FROM medico WHERE codigo = @codigo and estado=1 
    END
END;
GO


select * from medico