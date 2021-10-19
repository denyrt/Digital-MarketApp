import { HttpClient } from '../../../http/http-client.js';
import { GetItemsQuery } from '../queries/get-items-query.js';
import { GetItemsResponse } from '../queries/get-items-response.js';
import { DeleteItemsCommand } from '../commands/delete-items-command.js';
import { DeleteItemsResponse } from '../commands/delete-items-response.js';

export {
    GetItemsQuery,
    GetItemsResponse,
    DeleteItemsCommand,
    DeleteItemsResponse
};

export class ItemsApiClient {
    private readonly http: HttpClient;

    constructor() {
        this.http = HttpClient.createDefault();
    }

    public getItems(query?: GetItemsQuery, signal?: AbortSignal) : Promise<GetItemsResponse> {
        const queryString = toQueryString(query);
        const endpoint = `/api/items${queryString}`;
        return this.http.get(endpoint, signal);
    }

    public deleteItems(command: DeleteItemsCommand, signal?: AbortSignal): Promise<DeleteItemsResponse> {
        return this.http.delete('/api/items', command, signal);
    }
}

function toQueryString(query?: GetItemsQuery): string {
    if (query == undefined || query == null) return '';

    const parameters: string[] = [];

    if (query.collectionId) {
        parameters.push(`collectionId=${query.collectionId}`);
    }
    if (query.countInPage) {
        parameters.push(`countInPage=${query.countInPage}`);
    }
    if (query.pageOffset) {
        parameters.push(`pageOffset=${query.pageOffset}`);
    }
    if (parameters.length == 0) {
        return ''
    }
    
    return '?'.concat(parameters.join('&'));
}