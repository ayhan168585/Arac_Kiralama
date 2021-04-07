import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/Models/brand';
import { Car } from 'src/app/Models/car';
import { Color } from 'src/app/Models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.css'],
})
export class CarAddComponent implements OnInit {
  brands: Brand[] = [];
  colors: Color[] = [];
  cars: Car[] = [];
  carAddForm : FormGroup;

  constructor(
    private carService: CarService,
    private brandService: BrandService,
    private colorService: ColorService,
    private formBuilder: FormBuilder,
    private toastrService:ToastrService
  ) {}

  ngOnInit(): void {
    this.createCarAddForm()
    this.getBrands()
    this.GetColors()
  }

  getBrands(){

    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    });

  }

  GetColors(){
    this.colorService.GetColors().subscribe(response=>{
      this.colors=response.data

    })
  }

  createCarAddForm(){
    this.carAddForm =this.formBuilder.group({
      brandId: ["", Validators.required],
      colorId: ["", Validators.required],
      carName: ["", Validators.required],
      modelYear: ["", Validators.required],
      dailyPrice: ["", Validators.required],
      plaka: ["", Validators.required],
      requiredFindexScore: ["", Validators.required],
      description: ["", Validators.required]
    })
  }

  add() {
    if(this.carAddForm.valid){
      let carModel=Object.assign({},this.carAddForm.value);
      this.carService.add(carModel).subscribe(response=>{
        this.toastrService.info(response.message,"Başarılı")
      })
    }
    else{
      this.toastrService.error("Form eksik","Hata")
    }

  }
}
