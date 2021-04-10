export interface RentalDetail{
    id:number;
    userId:number;
    customerId:number;
    carId:number;
    requiredFindexScore:number;
    brandId:number;
    colorId:number;
    bankId:number;
    creditCardId:number;
    cardOperationId:number;
    firstName:string;
    lastName:string;
    companyName:string;
    carName:string;
    brandName:string;
    colorName:string;
    bankName:string;
    creditCardNumber:string;
    operationName:string;
    rentPrice:number;
    rentDate:Date;
    returnDate:Date;
    description:string;
}