export class HttpClient {
    private readonly host: string;

    constructor(host: string) {
        this.host = host;
    }

    public async get<T>(url?: string, signal?: AbortSignal): Promise<T> {
        if (signal?.aborted) {
            return;
        }

        const settings: RequestInit = {
            method: 'GET',
            headers: HttpClient.jsonHeaders(),
            signal: signal
        };

        const endpoint: string = `${this.host}${url}`;
        const fetchResponse: Response = await fetch(endpoint, settings);
        return fetchResponse.json();
    }

    public async post<T>(url?: string, body?: any, signal?: AbortSignal): Promise<T> {
        if (signal?.aborted) {
            return;
        }

        const settings: RequestInit = {
            method: 'POST',
            headers: HttpClient.jsonHeaders(),
            body: JSON.stringify(body),
            signal: signal
        };

        const endpoint: string = `${this.host}${url}`;
        const fetchResponse: Response = await fetch(endpoint, settings);
        return fetchResponse.json();
    }

    public async put<T>(url?: string, body?: any, signal?: AbortSignal): Promise<T> {
        if (signal?.aborted) {
            return;
        }

        const settings: RequestInit = {
            method: 'PUT',
            headers: HttpClient.jsonHeaders(),
            body: JSON.stringify(body),
            signal: signal
        };

        const endpoint: string = `${this.host}${url}`;
        const fetchResponse: Response = await fetch(endpoint, settings);
        return fetchResponse.json();
    }

    public async delete<T>(url?: string, body?: any, signal?: AbortSignal): Promise<T> {
        if (signal?.aborted) {
            return;
        }

        const settings: RequestInit = {
            method: 'DELETE',
            headers: HttpClient.jsonHeaders(),
            body: JSON.stringify(body),
            signal: signal
        };

        const endpoint: string = `${this.host}${url}`;
        const fetchResponse: Response = await fetch(endpoint, settings);
        return fetchResponse.json();
    }

    private static jsonHeaders(): Headers {
        const headers = new Headers();
        headers.append('Accept', 'application/json')
        headers.append('Content-Type', 'application/json');
        return headers;
    }

    public static createDefault(): HttpClient {
        return new HttpClient(`https://${location.host}`);
    }
}