import { Component, OnInit } from '@angular/core';
import { IClientDTO } from 'src/Enums/ClientDTO';
import { IFacturaRespuestaDTO } from 'src/Enums/FacturaRespuestaDTO';
import { FacturacionService } from 'src/services/facturacion.service';

@Component({
  selector: 'app-all-facturas',
  templateUrl: './all-facturas.component.html',
  styleUrls: ['./all-facturas.component.css']
})
export class AllFacturasComponent implements OnInit {
  seleccion!: string ;
  selectedCliente! : number;
  clientes : IClientDTO[] = [];
  numeroFactura! : number ;
  facturaRespuesta : IFacturaRespuestaDTO[] = [];
  boolClient = true;
  boolBill = true;
  restrictivoMensaje = '';
  constructor(private facturasService : FacturacionService,) { }

  ngOnInit(): void {
    this.getAllClients();
  }
  getAllClients(){
    this.facturasService.getClients().subscribe(resp =>{
      this.clientes = resp;
    })
  }

  buscarFactura(){
    if(this.seleccion == 'client'){
      this.facturasService.getFactura(this.selectedCliente, 0).subscribe(resp=>{
        this.facturaRespuesta = resp;
        console.log(this.facturaRespuesta);
      })
    }else if(this.seleccion == 'bill') {
      this.facturasService.getFactura(0,this.numeroFactura).subscribe(resp =>{
        this.facturaRespuesta = resp;
      })
    }
    else{
      this.restrictivoMensaje = 'Debe seleccionar un filtro para buscar las facturas';
    }
  }
  opcionSeleccionada(opcion: string) {
    if(opcion == 'bill'){
      this.boolClient = true;
      this.boolBill = false;
      this.restrictivoMensaje = '';
    }
    else if( opcion == 'client'){
      this.boolBill = true;
      this.boolClient = false;
      this.restrictivoMensaje = '';
    }
  }

}
