import {CompaniesModel} from "../models/CompaniesPage";
import {CompanyService} from "../services/CompanyService";

export class CompanyController {
    constructor(
        private model: CompaniesModel,
        private service: CompanyService
    ) {
    }

    async loadCompanies() {
        const data = await this.service.fetchCompanies();
        this.model.setCompanies(data);
    }
}