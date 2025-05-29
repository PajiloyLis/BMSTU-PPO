import {useEffect} from "react";
import {container} from "../../../core/di/DIContainer";
import {CompaniesModel} from "../models/CompaniesPage";
import {CompanyController} from "../controller/CompanyController";

export function CompanyCard() {
    const model = new CompaniesModel();
    const controller = new CompanyController(
        model,
        container.resolve('companyService')
    );

    useEffect(() => {
        controller.loadCompanies()
    }, []);

    return (
        <div className="company-card">
            {model.companies.map(company => (
                <>
                    <div className="company-title" key={company.id}>
                        <h3>{company.title}</h3>
                    </div>
                    <div className="contact-info" key={company.id}>
                        <p>{company.phoneNumber}</p>
                        <p>{company.email}</p>
                        <p>{company.address}</p>
                    </div>
                </>
            ))}
        </div>
    );
}