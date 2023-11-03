import { CurrencyPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { IClientDTO } from 'src/Enums/ClientDTO';
import { IDetallesFactura, IFacturaModel } from 'src/Enums/FacturaModelDTO';
import { IproductsDTO } from 'src/Enums/ProductsDTO';
import { FacturacionService } from 'src/services/facturacion.service';

@Component({
  selector: 'app-new-factura',
  templateUrl: './new-factura.component.html',
  styleUrls: ['./new-factura.component.css']
})
export class NewFacturaComponent implements OnInit {
  clientes : IClientDTO[] = [];
  productos: any[] = [];
  productsFac : IproductsDTO[] = [];
  productsinFac : any = [];
  subtotal = 0;
  impuesto = 0;
  total = 0;
  completeFactura! : IFacturaModel;
  numeroFactura! : string ;
  selectedCliente! : number;
  cantTotal = 0;
  disbutton = false;
  restrictivoMensaje = '';
  constructor( private facturasService : FacturacionService,) { }

  ngOnInit(): void {
    this.getAllClients();
    this.getAllProdcuts();
    
  }

  
  getAllClients(){
    this.facturasService.getClients().subscribe(resp =>{
      this.clientes = resp;
    })
  }
  getAllProdcuts(){
    this.facturasService.getProducts().subscribe(resp =>{
      this.productsFac = resp;
    })
  }
  agregarProducto(){
    this.restrictivoMensaje = '';
    this.productos.push({cantidad: 0, precioUnitario : 0, total : 0, subtotalP : 0 });
  }

  addProductsToFact(event: any){

    const index = event.target.value;
    const productSelect = this.productsFac.filter(elem => elem.productId == index )[0];
    this.productos[this.productos.length -1] = {
      ...this.productos[this.productos.length -1],
      productoId : productSelect.productId,
      precioUnitario: productSelect.precioUnitario,
      imagenPrducto : productSelect.imagenProduct,
      notas : '',
    }
    this.subtotal = this.productos.reduce((accumulator, producto) => accumulator + producto.total, 0)

  }
  actualizarTotal(product : any){

    if (product.precioUnitario !== undefined && product.cantidad !== undefined) {
      product.total = product.precioUnitario * product.cantidad;
      this.subtotal += product.total; 
      this.impuesto = (this.subtotal*0.19);
      this.total = this.subtotal + this.impuesto;
      this.cantTotal =+ product.cantidad; 
    }   else {
      product.total = 0;
    }
  }

  saveFactura(){
    if(this.productos.length <= 0){
      this.restrictivoMensaje = 'Debe seleccionar al menos un producto';
    }
    this.completeFactura = {
      fechaEmisionFactura : new Date(),
      clienteId : this.selectedCliente,
      numeroFactura : parseInt(this.numeroFactura),
      numeroTotalArticulos : this.cantTotal ,
      subtotalFactura : this.subtotal,
      totalImpuesto :this.impuesto ,
      totalFactura : this.total,
      detallesFactura : this.productos
      }
      console.log(this.completeFactura);
      this.facturasService.saveFactura(this.completeFactura).subscribe(res =>{
        console.log(res);
        this.disbutton = true;
      });
    }

    limpiarPantalla(){
      this.productos = [];
      this.numeroFactura = '';
      this.selectedCliente = 0;
      this.subtotal= 0;
      this.impuesto = 0;
      this.total =0 
      this.disbutton = false;
    }

    quitarProduct(index: number){
      if (index >= 0 && index < this.productos.length) {
        this.productos.splice(index, 1);
      }
    }

}
