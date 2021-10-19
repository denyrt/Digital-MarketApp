import { ResponseBase } from "../../../shared/responses/response-base.js";
import { Item } from '../../../shared/models/item.js';

export interface GetItemsResponse extends ResponseBase
{
    items: Item[];
    maxCount: number;
}