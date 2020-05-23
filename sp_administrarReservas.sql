create procedure sp_administrarReservas as
begin
	declare @fecha_fin as datetime; 
	declare @index as int = 1, @cantidad as int = (select count(*) from dbo.Reservas where IdEstadoReserva <> 
							 (select IdEstadoReserva from dbo.EstadoReservas where DescripcionEstado = 'Finalizado')); 
	
	 

	create table #Temporal_registrosReservas(
	 [Index] int identity(1,1) primary key, 
	 IdReserva int, 
	 FechaFin datetime
	)

	select IdReserva, FechaFinReserva into ##registrosReservas from dbo.Reservas where IdEstadoReserva <> 
							 (select IdEstadoReserva from dbo.EstadoReservas where DescripcionEstado = 'Finalizado')

	while (@index <= @cantidad)
	begin 
	   declare @IdReserva as int = (select IdReserva from dbo.Reservas where IdReserva = (
									select IdReserva from #Temporal_registrosReservas where [Index] = @index)); 
	   set @fecha_fin = (select FechaFin from #Temporal_registrosReservas where [Index] = @index); 
		if(@fecha_fin > GETDATE())
		 begin 
			update dbo.Reservas set IdEstadoReserva = (select IdEstado from dbo.EstadoReservas where DescripcionEstado = 'Mora')
			where IdReserva = @IdReserva; 
		 end 
		 set @index = @index + 1; 
	end 
end 

							