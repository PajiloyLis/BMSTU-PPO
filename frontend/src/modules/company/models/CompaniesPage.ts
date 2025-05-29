import { Company } from "./Company";

export class CompaniesModel {
    private _companies: Company[] = [];

    get companies() {
        return this._companies;
    }

    setCompanies(data: Company[]) {
        this._companies = data;
    }
}