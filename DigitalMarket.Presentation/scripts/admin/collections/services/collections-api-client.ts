import { HttpClient } from "../../../http/http-client.js";

export class CollectionsApiClient
{
    private readonly http: HttpClient;

    constructor() {
        this.http = HttpClient.createDefault();
    }

    public getCollection(id: string, signal?: AbortSignal): Promise<any> {
        return this.http.get(`api/collections/${id}`, signal);
    }

    public getCollections(): Promise<any> {
        return this.http.get('api/collections');
    }

    public changeAvailable(id: string, available: boolean, signal?: AbortSignal): Promise<any> {
        const body =
        {
            id: id,
            available: available
        };

        return this.http.post('/api/collections/ChangeAvailable', body, signal);
    }

    public deleteCollections(ids: string[], signal?: AbortSignal): Promise<any> {
        return this.http.delete('/api/collections', { ids: ids }, signal);
    }
}