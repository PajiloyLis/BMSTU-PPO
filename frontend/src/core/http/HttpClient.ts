import { container } from "../di/DIContainer";

export class HttpClient {
    private readonly baseUrl: string;

    constructor(baseUrl: string = import.meta.env.VITE_API_URL) {
        this.baseUrl = baseUrl;
    }

    async get<T>(endpoint: string): Promise<T> {
        const response = await fetch(`${this.baseUrl}${endpoint}`, {
            headers: this.getHeaders(),
        });
        return this.handleResponse<T>(response);
    }

    async post<T>(endpoint: string, body: object): Promise<T> {
        const response = await fetch(`${this.baseUrl}${endpoint}`, {
            method: 'POST',
            headers: this.getHeaders(),
            body: JSON.stringify(body),
        });
        return this.handleResponse<T>(response);
    }

    // Другие методы (put, delete, patch) аналогично

    private getHeaders(): HeadersInit {
        const headers: HeadersInit = {
            'Content-Type': 'application/json',
        };

        // Пример добавления токена авторизации
        const authToken = localStorage.getItem('token');
        if (authToken) {
            headers['Authorization'] = `Bearer ${authToken}`;
        }

        return headers;
    }

    private async handleResponse<T>(response: Response): Promise<T> {
        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || 'HTTP-ошибка');
        }
        return response.json();
    }
}