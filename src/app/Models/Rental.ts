export interface Rental{
    id:number;
    userId:number;
    carId:number;
    creditCardId:number;
    rentPrice:number;
    rentDate:Date;
    returnDate:Date;
    description:string;
}