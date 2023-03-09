//Order model
export class Order {
    
    id: string;
    customerName: string;
    orderDate: Date;
    totalAmount: number;

    constructor() {
        this.id = '';
        this.customerName = '';
        this.orderDate = new Date();
        this.totalAmount = 0;
    };
}

export class CreateOrder {
    
    customerName: string;
    orderDate: Date;
    totalAmount: number;

    constructor() {
        this.customerName = '';
        this.orderDate = new Date();
        this.totalAmount = 0;
    };
}