import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/Models/brand';
import { Car } from 'src/app/Models/car';
import { CarDetail } from 'src/app/Models/carDetail';
import { CarImage } from 'src/app/Models/carImage';
import { Color } from 'src/app/Models/color';
import { CarDetailService } from 'src/app/services/car-detail.service';
import { CarService } from 'src/app/services/car.service';
import { CarimageService } from 'src/app/services/carimage.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css'],
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  brands: Brand[] = [];
  colors:Color[]=[];
  carDetails: CarDetail[] = [];
  carimages:CarImage[]=[];
  dataLoaded = false;
  imageUrl:string ="C:/Users/Ayhan Özer/Desktop/Araç Kiralama/Arac_Kiralama/AracKiralama/WebAPI/Images/"
  filterText="";
  filterBrandText="";
  filterColorText:"";

  constructor(
    private carService: CarService,
    private carDetailService:CarDetailService,
    private carimageservice:CarimageService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['brandId']) {
        this.getcarsByBrand(params['brandId']);
      } else if (params['carId']) {
        this.getCarById(params['carId']);
      }
      else if(params["colorId"]){
        this.getcarsByColorId(params["colorId"]);
      }
      
      else {
        this.getCarDetail();
       
      }
    });
  }

  getAll() {
    this.carService.getAll().subscribe((response) => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }

  getcarsByBrand(brandId: number) {
    this.carDetailService.getcarsByBrand(brandId).subscribe((response) => {
      this.carDetails = response.data;
      this.dataLoaded = true;
    });
  }

  getimages(){
    this.carimageservice.getimages().subscribe(response=>{
      this.carimages=response.data
      this.dataLoaded=true
    })
  }
  getbycarid(carId:number){
    this.carimageservice.getbycarid(carId).subscribe(response=>{

    })
  }
  getCarDetail(){
    this.carDetailService.getCarDetail().subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true
    })
  }
  getCarById(carId:number){
    this.carDetailService.getCarById(carId).subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true
    })
  }

  getcarsByColorId(colorId:number){
    this.carDetailService.getcarsByColorId(colorId).subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true
    })
  }

}
