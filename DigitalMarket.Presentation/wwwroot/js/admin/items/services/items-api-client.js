import { HttpClient } from '../../../http/http-client.js';
var ItemsApiClient = /** @class */ (function () {
    function ItemsApiClient() {
        this.http = HttpClient.createDefault();
    }
    ItemsApiClient.prototype.getItems = function (query, signal) {
        var queryString = toQueryString(query);
        var endpoint = "/api/items" + queryString;
        return this.http.get(endpoint, signal);
    };
    ItemsApiClient.prototype.deleteItems = function (command, signal) {
        return this.http.delete('/api/items', command, signal);
    };
    return ItemsApiClient;
}());
export { ItemsApiClient };
function toQueryString(query) {
    if (query == undefined || query == null)
        return '';
    var parameters = [];
    if (query.collectionId) {
        parameters.push("collectionId=" + query.collectionId);
    }
    if (query.countInPage) {
        parameters.push("countInPage=" + query.countInPage);
    }
    if (query.pageOffset) {
        parameters.push("pageOffset=" + query.pageOffset);
    }
    if (parameters.length == 0) {
        return '';
    }
    return '?'.concat(parameters.join('&'));
}
//# sourceMappingURL=items-api-client.js.map