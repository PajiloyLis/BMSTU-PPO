export class Company {
    id: any;
    title: any;
    phoneNumber: any;
    email: any;
    address: any;
    private registrationDate: any;
    private inn: any;
    private kpp: any;
    private ogrn: any;
    constructor( id: any, title: any, registrationDate: any, phone: any, email: any, inn: any, kpp: any, ogrn: any, address: any) {
        this.id = id;
        this.title = title;
        this.phoneNumber = phone;
        this.email = email;
        this.address = address;
        this.registrationDate = registrationDate;
        this.inn = inn;
        this.kpp = kpp;
        this.ogrn = ogrn;
    }
}