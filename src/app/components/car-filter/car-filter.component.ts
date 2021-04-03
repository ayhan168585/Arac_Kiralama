import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/Models/brand';
import { Color } from 'src/app/Models/color';
import { BrandService } from 'src/app/services/brand.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car-filter',
  templateUrl: './car-filter.component.html',
  styleUrls: ['./car-filter.component.css']
})
export class CarFilterComponent implements OnInit {

  dataLoaded=false

  brands:Brand[]=[];
 
  brandFilter:number;


  constructor(private brandService:BrandService) { }

  ngOnInit(): void {
    this.getBrands()
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data
      this.dataLoaded=true
      
    })
  }
 
  getSelectedBrand(brand:number){
    if(this.brandFilter==brand){
      return true
    }
    else{
      return false
    }
  }

 

}
