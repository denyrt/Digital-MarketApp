import { Item } from "../../shared/models/item.js";
import { DeleteItemsCommand, GetItemsQuery, ItemsApiClient } from "./services/items-api-client.js";

document.addEventListener('DOMContentLoaded', () => {
    const itemsApiClient = new ItemsApiClient();
    const table = document.getElementById('table') as HTMLTableElement;
    const collectionFilter = document.getElementById('collectionFilter') as HTMLSelectElement;

    let filterAbortController: AbortController;

    const deleteItemListener = (e: Event) => {
        const btn = e.target as HTMLButtonElement;
        const currentRow = btn.parentElement.parentElement.parentElement.parentElement.parentElement as HTMLTableRowElement;
        const itemId = currentRow.getAttribute('data');
        const deleteCommand: DeleteItemsCommand = { ids: [itemId] };
        itemsApiClient.deleteItems(deleteCommand)
            .then(response => {
                if (response.success) {
                    table.deleteRow(currentRow.rowIndex);
                }
                else {
                    alert(response.code);
                }
            })
            .catch(error => console.log(error));
    };

    table.querySelectorAll('.dropdown-item.delete').forEach(x =>
        x.addEventListener('click', deleteItemListener));

    const collectionFilterListener = (e: Event) => {
        if (filterAbortController) {
            filterAbortController.abort();
        }

        filterAbortController = new AbortController();
        const signal = filterAbortController.signal;
        const select = e.target as HTMLSelectElement;
        const query: GetItemsQuery = {
            collectionId: select.value == 'null' ? null : select.value,
            countInPage: 20,
            pageOffset: 0
        };
        
        itemsApiClient.getItems(query, signal)
            .then((data) => {
                console.log(data);
                clearTable(table);
                data.items.forEach(item => {
                    const row = addRow(table);
                    initRow(row, item);
                });
            })
            .catch((error) => {
                console.log(error);
            });
    };

    collectionFilter.addEventListener('change', collectionFilterListener);

    function clearTable(table: HTMLTableElement): void {
        while (table.rows.length > 1) {
            table.deleteRow(1);
        }
    }

    function addRow(table: HTMLTableElement): HTMLTableRowElement {
        const tbody = table.tBodies.item(0);
        const row = tbody.insertRow(0);
        return row;
    }

    function initRow(row: HTMLTableRowElement, item: Item): void {
        row.setAttribute('data', item.id);
        row.insertCell(0).innerHTML = `<input value="${item.id}" type="checkbox" class="form-check-input" />`;
        row.insertCell(1).innerHTML = `<a href="/Admin/Item/${item.id}">${item.marketName}</a>`;
        row.insertCell(2).innerHTML = `<label>${item.collection.name}</label>`;
        row.insertCell(3).innerHTML = `<label>${item.rarity.name}</label>`;
        row.insertCell(4).innerHTML = `<div>
                                           <div class="dropdown">
                                               <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                   <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-three-dots" viewBox="0 0 16 16">
                                                       <path d="M3 9.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z"></path>
                                                   </svg>
                                               </button>
                                               <div class="dropdown-menu">
                                                   <a class="dropdown-item" href="/Admin/EditItem/${item.id}">Edit</a>
                                                   <button class="dropdown-item delete">Delete</button>
                                               </div>
                                           </div>
                                       </div>`;

        row.cells.item(4).querySelector('.delete').addEventListener('click', deleteItemListener);
    }

}, { once: true });