import { ResponseBase } from "../../../shared/responses/response-base.js";

export interface DeleteItemsResponse extends ResponseBase
{
    deletedCount: number;
}