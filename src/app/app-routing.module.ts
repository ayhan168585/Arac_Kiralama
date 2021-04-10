import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { CarImageComponent } from './components/car-image/car-image.component';
import { BrandAddComponent } from './components/brand/brand-add/brand-add.component';
import { ColorAddComponent } from './components/color/color-add/color-add.component';
import { CarAddComponent } from './components/car/car-add/car-add.component';
import { RentalAddComponent } from './components/rental/rental-add/rental-add.component';
import { RentalComponent } from './components/rental/rental.component';
import { UserAddComponent } from './components/user/user-add/user-add.component';

const routes: Routes = [
  {path:"",component:CarComponent,pathMatch:"full"},
  {path:"cars",component:CarComponent},
  {path:"cars/brand/:brandId",component:CarComponent},
  {path:"cars/color/:colorId",component:CarComponent},
  {path:"cars/cardetail/:carId",component:CarDetailComponent},
  {path:"cars/carimages",component:CarImageComponent},
  {path:"cars/filter/:brandId",component:CarComponent},
  {path:"cars/brand-add",component:BrandAddComponent},
  {path:"cars/color-add",component:ColorAddComponent},
  {path:"cars/car-add",component:CarAddComponent},
  {path:"cars/rental-add/:carId",component:RentalAddComponent},
  {path:"cars/rentals",component:RentalComponent},
  {path:"cars/rentals/:carId",component:RentalComponent},
  {path:"cars/user-add",component:UserAddComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
