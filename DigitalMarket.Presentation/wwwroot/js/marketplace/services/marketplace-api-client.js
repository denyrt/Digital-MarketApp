import { HttpClient } from "../../http/http-client.js";
var MarketplaceApiClient = /** @class */ (function () {
    function MarketplaceApiClient() {
        this.http = new HttpClient("https://" + location.host);
    }
    MarketplaceApiClient.prototype.createSellOffer = function (command, signal) {
        return this.http.post('/api/marketplace/create-sell-offer', command, signal);
    };
    MarketplaceApiClient.prototype.cancelSellOffer = function (command, signal) {
        return this.http.post('/api/marketplace/cancel-cell-offer', command, signal);
    };
    return MarketplaceApiClient;
}());
export { MarketplaceApiClient };
//# sourceMappingURL=marketplace-api-client.js.map