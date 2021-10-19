import { CollectionsApiClient } from "./services/collections-api-client.js";
document.addEventListener('DOMContentLoaded', function () {
    var collectionsApiClient = new CollectionsApiClient();
    var table = document.getElementById('table');
    var _loop_1 = function (i) {
        var row = table.rows.item(i);
        var availableAtMarketCheckbox = row.querySelector('.checkbox');
        var collectionId = row.getAttribute('data');
        var dropdown = row.querySelector('.dropdown-toggle');
        var placeAtStoreButton = row.querySelector('.place-at-store');
        var removeFromStoreButton = row.querySelector('.remove-from-store');
        var deleteButton = row.querySelector('.delete');
        var availableAtMarketCheckboxListener = function (e) {
            placeAtStoreButton.disabled = availableAtMarketCheckbox.checked;
            removeFromStoreButton.disabled = !availableAtMarketCheckbox.checked;
        };
        var placeAtStoreListener = function (e) {
            collectionsApiClient.changeAvailable(collectionId, true)
                .then(function (e) {
                if (e.success) {
                    availableAtMarketCheckbox.checked = true;
                }
                else {
                    alert('Collection must have more then 0 items. Sum of items drop chance must be equals to 100.');
                }
            });
        };
        var removeFromStoreListener = function (e) {
            collectionsApiClient.changeAvailable(collectionId, false)
                .then(function (e) {
                availableAtMarketCheckbox.checked = false;
            });
        };
        var deleteCollectionListener = function (e) {
            collectionsApiClient.deleteCollections([collectionId])
                .then(function (e) {
                if (e.success) {
                    availableAtMarketCheckbox.removeEventListener('change', availableAtMarketCheckboxListener);
                    placeAtStoreButton.removeEventListener('click', placeAtStoreListener);
                    removeFromStoreButton.removeEventListener('click', removeFromStoreListener);
                    deleteButton.removeEventListener('click', deleteCollectionListener);
                    table.deleteRow(i);
                }
            });
        };
        availableAtMarketCheckbox.addEventListener('change', availableAtMarketCheckboxListener);
        placeAtStoreButton.addEventListener('click', placeAtStoreListener);
        removeFromStoreButton.addEventListener('click', removeFromStoreListener);
        deleteButton.addEventListener('click', deleteCollectionListener);
    };
    for (var i = 1; i < table.rows.length; ++i) {
        _loop_1(i);
    }
}, { once: true });
//# sourceMappingURL=manage-collections.js.map