import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RentalDetail } from 'src/app/Models/rentalDetail';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.css']
})
export class RentalComponent implements OnInit {

  rentalDetails:RentalDetail[]=[];

  constructor(private rentalService:RentalService,private toastrService:ToastrService ) { }

  ngOnInit(): void {
    this.GetRentalDetail()
  }

  GetRentalDetail(){
    this.rentalService.GetRentalDetail().subscribe(response=>{
      this.rentalDetails=response.data
      this.toastrService.info(response.message,"Başarılı")
    })
  }

}
