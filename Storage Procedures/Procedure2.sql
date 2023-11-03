CREATE PROCEDURE InsertTableFactura
	@FechaEmisionFactura DateTime,
	@ClienteId Int,
	@NumeroFactura Int,
	@NumeroTotalArticulos Int,
	@SubtotalFactura decimal,
	@TotalImpuesto decimal,
	@TotalFactura decimal 

AS 
BEGIN 
	INSERT INTO TblFacturas (FechaEmisionFactura, ClienteId,NumeroFactura, NumeroTotalArticulos, SubtotalFactura, TotalImpuesto, TotalFactura)
	Values (@FechaEmisionFactura,@ClienteId,@NumeroFactura,@NumeroTotalArticulos,@SubtotalFactura,@TotalImpuesto,@TotalFactura);

END