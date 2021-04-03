import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/Models/car';
import { CarDetail } from 'src/app/Models/carDetail';
import { CarDetailService } from 'src/app/services/car-detail.service';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css'],
})
export class CarDetailComponent implements OnInit {
  carDetails: CarDetail[] = [];
  cars:Car[]=[];
  dataLoaded = false;

  constructor(
    private carService: CarService,
    private carDetailService:CarDetailService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['carId']) {
        this.getCarById(params['carId']);
      }
      else{
        this.getCarDetail();
      }
    });
  }

 

  getCarDetail(){
    this.carDetailService.getCarDetail().subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true
    })
  }

  getCarById(carId: number) {
    this.carDetailService.getCarById(carId).subscribe((response) => {
      this.carDetails = response.data;
      this.dataLoaded=true
    });
  }
}
