import { ResponseBase } from '../../shared/responses/response-base.js';

export interface CreateSellOfferResponse extends ResponseBase {
    sellOfferId: string;
}