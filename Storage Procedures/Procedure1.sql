CREATE PROCEDURE InsertTablaDetalleFactura
	@FacturaId Int,
	@ProductoId Int,
	@CantidadProducto Int,
	@PrecioUnitarioProducto decimal,
	@SubTotalProducto decimal,
	@Notas Varchar(200) 

AS 
BEGIN 
	INSERT INTO TblDetallesFacturas (FacturaId,ProductoId,CantidadProducto, PrecioUnitarioProducto, SubtotalProcuto,Notas)
	Values (@FacturaId,@ProductoId,@CantidadProducto,@PrecioUnitarioProducto,@SubTotalProducto,@Notas);

	UPDATE CatProductos 
	SET Ext = Ext - @CantidadProducto
	WHERE CatProductos.ProductId = @ProductoId

END