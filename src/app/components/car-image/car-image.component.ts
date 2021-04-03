import { Component, OnInit } from '@angular/core';
import { CarDetail } from 'src/app/Models/carDetail';
import { CarImage } from 'src/app/Models/carImage';
import { CarDetailService } from 'src/app/services/car-detail.service';
import { CarimageService } from 'src/app/services/carimage.service';

@Component({
  selector: 'app-car-image',
  templateUrl: './car-image.component.html',
  styleUrls: ['./car-image.component.css']
})
export class CarImageComponent implements OnInit {
  dataLoaded=false

  carimages:CarImage[]=[];
  carDetails:CarDetail[]=[];

  constructor(private carimageservice:CarimageService,private cardetailService:CarDetailService) { }

  ngOnInit(): void {
    this.getimages()
    this.getCarDetail()
  }

  getimages(){
    this.carimageservice.getimages().subscribe(response=>{
      this.carimages=response.data
      this.dataLoaded=true
    })
  }

  getCarDetail(){
    this.cardetailService.getCarDetail().subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true
    })
  }

}
