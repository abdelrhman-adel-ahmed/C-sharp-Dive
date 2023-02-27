import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllProductComponent } from './componenets/all-product/all-product.component';
import { ProductsDetailsComponent } from './componenets/products-details/products-details.component';



@NgModule({
  declarations: [
    AllProductComponent,
    ProductsDetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
