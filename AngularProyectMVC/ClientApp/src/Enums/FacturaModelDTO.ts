export interface IDetallesFactura {
    facturaId?: number;
    productoId: number;
    cantidadProducto: number;
    precioUnitarioProducto: number;
    subtotalProducto: number;
    notas: string | '';
    cantidad : number;
}

export interface IFacturaModel {
    fechaEmisionFactura: Date;
    clienteId: number;
    numeroFactura: number;
    numeroTotalArticulos: number;
    subtotalFactura: number;
    totalImpuesto: number;
    totalFactura: number;
    detallesFactura: IDetallesFactura[];
}