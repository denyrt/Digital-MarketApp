import { HttpClient } from "../../../http/http-client.js";
var CollectionsApiClient = /** @class */ (function () {
    function CollectionsApiClient() {
        this.http = HttpClient.createDefault();
    }
    CollectionsApiClient.prototype.getCollection = function (id, signal) {
        return this.http.get("api/collections/" + id, signal);
    };
    CollectionsApiClient.prototype.getCollections = function () {
        return this.http.get('api/collections');
    };
    CollectionsApiClient.prototype.changeAvailable = function (id, available, signal) {
        var body = {
            id: id,
            available: available
        };
        return this.http.post('/api/collections/ChangeAvailable', body, signal);
    };
    CollectionsApiClient.prototype.deleteCollections = function (ids, signal) {
        return this.http.delete('/api/collections', { ids: ids }, signal);
    };
    return CollectionsApiClient;
}());
export { CollectionsApiClient };
//# sourceMappingURL=collections-api-client.js.map