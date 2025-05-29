import {container} from "./DIContainer";
import {HttpClient} from "../http/HttpClient";
import {CompanyService} from "../../modules/company/services/CompanyService";

// Регистрируем зависимости
container.register('http', new HttpClient('http://localhost:5075/api/'));
container.register('companyService', new CompanyService(
    container.resolve('http')
));