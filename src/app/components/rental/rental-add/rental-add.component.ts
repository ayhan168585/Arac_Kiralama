import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Bank } from 'src/app/Models/bank';
import { Brand } from 'src/app/Models/brand';
import { Car } from 'src/app/Models/car';
import { CarDetail } from 'src/app/Models/carDetail';
import { Color } from 'src/app/Models/color';
import { CreditCard } from 'src/app/Models/creditCard';
import { Customer } from 'src/app/Models/customer';
import { Rental } from 'src/app/Models/Rental';
import { RentalDetail } from 'src/app/Models/rentalDetail';
import { User } from 'src/app/Models/user';
import { BankService } from 'src/app/services/bank.service';
import { BrandService } from 'src/app/services/brand.service';
import { CarDetailService } from 'src/app/services/car-detail.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';
import { CreditCardService } from 'src/app/services/credit-card.service';
import { CustomerService } from 'src/app/services/customer.service';
import { RentalService } from 'src/app/services/rental.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-rental-add',
  templateUrl: './rental-add.component.html',
  styleUrls: ['./rental-add.component.css'],
})
export class RentalAddComponent implements OnInit {
  dataLoaded = false;

  rentalAddForm: FormGroup;
  userAddForm:FormGroup;
  customerAddForm:FormGroup;
  creditCardAddForm:FormGroup;
  customers: Customer[] = [];
  users: User[] = [];
  cars: Car[] = [];
  cardetails: CarDetail[] = [];
  brands: Brand[] = [];
  banks:Bank[]=[];
  rentals:Rental[]=[];
  rentaldetails:RentalDetail[]=[];
  creditcards:CreditCard[]=[];
  colors: Color[] = [];
  carName:string
  carId:number;
  carBrandName: string;
  carColorName:string;
  carDailyPrice:number;
  carFindexScore:number;
  

  constructor(
    private brandService: BrandService,
    private customerService: CustomerService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private carService: CarService,
    private colorService: ColorService,
    private carDetailService: CarDetailService,
    private activatedRoute:ActivatedRoute,
    private toastrService:ToastrService,
    private bankService:BankService,
    private creditCardService:CreditCardService,
    private rentalService:RentalService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["carId"]){
        this.getCarById(params["carId"])
        this.createUserAddForm();
        this.createCustomerAddForm();
        this.createCreditCardAddForm();
        this.createRentalAddForm();
      }
      else{
  
      }
      this.getBrands();
      this.getBanks();
      this.getCustomers();
      this.getUsers();
      this.getAll();
      this.GetColors(); 
      this.getCreditCards(); 
    })
  
    
  }

  createRentalAddForm() {
    this.rentalAddForm = this.formBuilder.group({
      userId: ['', Validators.required],
      carId: ['', Validators.required],
      creditCardId:["",Validators.required],
      rentPrice:["",Validators.required],
      rentDate:["",Validators.required],
      returnDate:["",Validators.required],
      description:["",Validators.required]


    });
  }

  createUserAddForm(){
    this.userAddForm=this.formBuilder.group({
      firstName:["",Validators.required],
      lastName:["",Validators.required],
      email:["",Validators.required]


    });
  }

  createCustomerAddForm(){
this.customerAddForm=this.formBuilder.group({
  userId:["",Validators.required],
  companyName:["",Validators.required]
})
  }

  createCreditCardAddForm(){
    this.creditCardAddForm=this.formBuilder.group({
      bankId:["",Validators.required],
      creditCardNumber:["",Validators.required],
      ccv:["",Validators.required],
      description:["",Validators.required]
     
    })
  }

  addUser(){
    if(this.userAddForm.valid){
      let userModel=Object.assign({},this.userAddForm.value);
      this.userService.add(userModel).subscribe(response=>{
        this.toastrService.info(response.message,"Başarılı")
        this.getUsers();
      })
    }
    else{
      this.toastrService.error("Form eksik","Hata")
      this.getUsers();
    }
  }

  addCustomer(){
    if(this.customerAddForm.valid){
      let customerModel=Object.assign({},this.customerAddForm.value);
      this.customerService.add(customerModel).subscribe(response=>{
        this.toastrService.info(response.message,"Başarılı")
        this.getCustomers();
      })
    }
    else{
      this.toastrService.error("Form eksik","Hata")
      this.getCustomers();
    }

  }

  addCreditCard(){
    if(this.creditCardAddForm.valid){
      let creditCardModel=Object.assign({},this.creditCardAddForm.value)
      this.creditCardService.add(creditCardModel).subscribe(response=>{
        this.toastrService.info(response.message,"Başarılı")
        this.getCreditCards()
      })
    }
    else{
      this.toastrService.error("Form eksik","Hata")
      this.getCreditCards()
    }
  }
  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
    });
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe((response) => {
      this.customers = response.data;
    });
  }

  getUsers() {
    this.userService.getUsers().subscribe((response) => {
      this.users = response.data;
    });
  }
  getAll() {
    this.carService.getAll().subscribe((response) => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }

  GetColors() {
    this.colorService.GetColors().subscribe((response) => {
      this.colors = response.data;

      this.dataLoaded = true;
    });
  }
  getBanks(){
    this.bankService.getBanks().subscribe(response=>{
      this.banks=response.data
    })
  }

  getCreditCards(){
    this.creditCardService.getCreditcards().subscribe(response=>{
      this.creditcards=response.data
    })
  }

  getCarById(carId: number) {
    this.carDetailService.getCarById(carId).subscribe((response) => {
      this.cardetails = response.data;
      this.carName=this.cardetails[0].carName;
      this.carId=this.cardetails[0].carId;
      this.carBrandName = this.cardetails[0].brandName;
      this.carColorName=this.cardetails[0].colorName;
      this.carDailyPrice=this.cardetails[0].dailyPrice;
      this.carFindexScore=this.cardetails[0].requiredFindexScore;
      this.dataLoaded = true;
    });
  }

  addRental() {
    if(this.rentalAddForm.valid){
      let rentalModel=Object.assign({},this.rentalAddForm.value)
      this.rentalService.add(rentalModel).subscribe(response=>{
        this.toastrService.info(response.message,"Başarılı")
        this.GetRentalDetail()
        
      })
    }
    else{
      this.toastrService.error("Form eksik","Hata")
    }
  }
  getRentals(){
    this.rentalService.getRentals().subscribe(response=>{
      this.rentals=response.data
    })
  }
  GetRentalDetail(){
    this.rentalService.GetRentalDetail().subscribe(response=>{
      this.rentaldetails=response.data
    })
  }

  getrentalsbycarid(carId:number){
    this.rentalService.getrentalsbycarid(carId).subscribe(response=>{
      this.rentaldetails=response.data
    })

  }
}
