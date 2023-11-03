import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FacturacionService } from 'src/services/facturacion.service';

@Component({
  selector: 'app-facturacion',
  templateUrl: './facturacion.component.html',
  styleUrls: ['./facturacion.component.css']
})
export class FacturacionComponent implements OnInit {
  constructor(private router : Router) { 
    

  }

  ngOnInit(): void {

  }

  newFactura(){
    return this.router.navigate(['/newFactura']);
  }
  searchFactura(){
    return this.router.navigate(['facturas']);
  }


}
