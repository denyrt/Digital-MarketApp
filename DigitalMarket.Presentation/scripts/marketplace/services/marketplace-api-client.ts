import { HttpClient } from "../../http/http-client.js";
import { CreateSellOfferCommand } from '../commands/create-sell-offer-command.js';
import { CreateSellOfferResponse } from '../commands/create-sell-offer-response.js';
import { CancelSellOfferCommand } from '../commands/cancel-sell-offer-command.js';
import { CancelSellOfferResponse } from '../commands/cancel-sell-offer-response.js';

export {
    CreateSellOfferCommand,
    CreateSellOfferResponse,
    CancelSellOfferCommand,
    CancelSellOfferResponse
}

export class MarketplaceApiClient {
    private readonly http: HttpClient;

    constructor() {
        this.http = new HttpClient(`https://${location.host}`);
    }

    public createSellOffer(command: CreateSellOfferCommand, signal?: AbortSignal) : Promise<CreateSellOfferResponse> {
        return this.http.post('/api/marketplace/create-sell-offer', command, signal);
    }

    public cancelSellOffer(command: CancelSellOfferCommand, signal?: AbortSignal): Promise<CreateSellOfferResponse> {
        return this.http.post('/api/marketplace/cancel-cell-offer', command, signal);
    }
}