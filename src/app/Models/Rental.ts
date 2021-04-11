export interface Rental{
    id:number;
    userId:number;
    customerId:number;
    brandId:number;
    colorId:number;
    carId:number;
    creditCardId:number;
    rentPrice:number;
    rentDate:Date;
    returnDate:Date;
    description:string;
}