import { CollectionsApiClient } from "./services/collections-api-client.js";

document.addEventListener('DOMContentLoaded', () => {
    const collectionsApiClient = new CollectionsApiClient();
    const table = document.getElementById('table') as HTMLTableElement;

    for (let i = 1; i < table.rows.length; ++i) {
        const row = table.rows.item(i);
        const availableAtMarketCheckbox = row.querySelector('.checkbox') as HTMLInputElement;
        const collectionId = row.getAttribute('data');
        const dropdown = row.querySelector('.dropdown-toggle') as HTMLButtonElement;
        const placeAtStoreButton = row.querySelector('.place-at-store') as HTMLButtonElement;
        const removeFromStoreButton = row.querySelector('.remove-from-store') as HTMLButtonElement;
        const deleteButton = row.querySelector('.delete') as HTMLButtonElement;

        const availableAtMarketCheckboxListener = (e) => {
            placeAtStoreButton.disabled = availableAtMarketCheckbox.checked;
            removeFromStoreButton.disabled = !availableAtMarketCheckbox.checked;
        };

        const placeAtStoreListener = (e) => {
            collectionsApiClient.changeAvailable(collectionId, true)
                .then(e => {
                    if (e.success) {
                        availableAtMarketCheckbox.checked = true;
                    }
                    else {
                        alert('Collection must have more then 0 items. Sum of items drop chance must be equals to 100.')
                    }
                });
        };

        const removeFromStoreListener = (e) => {
            collectionsApiClient.changeAvailable(collectionId, false)
                .then(e => {
                    availableAtMarketCheckbox.checked = false;
                });
        };

        const deleteCollectionListener = (e) => {
            collectionsApiClient.deleteCollections([collectionId])
                .then(e => {
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
    }
}, { once: true });