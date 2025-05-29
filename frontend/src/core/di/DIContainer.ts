class DIContainer {
    private services: Map<string, any> = new Map();

    register(name: string, service: any) {
        this.services.set(name, service);
    }

    resolve<T>(name: string): T {
        const service = this.services.get(name);
        if (!service) throw new Error(`Сервис ${name} не найден`);
        return service;
    }
}

export const container = new DIContainer();