import {HttpClient} from "../../../core/http/HttpClient";
import {Company} from "../models/Company";

export class CompanyService {
    constructor(private http: HttpClient) {
    }

    async fetchCompanies(): Promise<Company[]> {
        const response = await this.http.get('/companies');
        return response.data.map((item: any) =>
            new Company(item.id, item.title, item.registrationDate, item.phoneNumber, item.email, item.inn, item.kpp, item.ogrn, item.address)
        );
    }
}