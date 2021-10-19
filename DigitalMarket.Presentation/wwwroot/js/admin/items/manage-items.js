import { ItemsApiClient } from "./services/items-api-client.js";
document.addEventListener('DOMContentLoaded', function () {
    var itemsApiClient = new ItemsApiClient();
    var table = document.getElementById('table');
    var collectionFilter = document.getElementById('collectionFilter');
    var filterAbortController;
    var deleteItemListener = function (e) {
        var btn = e.target;
        var currentRow = btn.parentElement.parentElement.parentElement.parentElement.parentElement;
        var itemId = currentRow.getAttribute('data');
        var deleteCommand = { ids: [itemId] };
        itemsApiClient.deleteItems(deleteCommand)
            .then(function (response) {
            if (response.success) {
                table.deleteRow(currentRow.rowIndex);
            }
            else {
                alert(response.code);
            }
        })
            .catch(function (error) { return console.log(error); });
    };
    table.querySelectorAll('.dropdown-item.delete').forEach(function (x) {
        return x.addEventListener('click', deleteItemListener);
    });
    var collectionFilterListener = function (e) {
        if (filterAbortController) {
            filterAbortController.abort();
        }
        filterAbortController = new AbortController();
        var signal = filterAbortController.signal;
        var select = e.target;
        var query = {
            collectionId: select.value == 'null' ? null : select.value,
            countInPage: 20,
            pageOffset: 0
        };
        itemsApiClient.getItems(query, signal)
            .then(function (data) {
            console.log(data);
            clearTable(table);
            data.items.forEach(function (item) {
                var row = addRow(table);
                initRow(row, item);
            });
        })
            .catch(function (error) {
            console.log(error);
        });
    };
    collectionFilter.addEventListener('change', collectionFilterListener);
    function clearTable(table) {
        while (table.rows.length > 1) {
            table.deleteRow(1);
        }
    }
    function addRow(table) {
        var tbody = table.tBodies.item(0);
        var row = tbody.insertRow(0);
        return row;
    }
    function initRow(row, item) {
        row.setAttribute('data', item.id);
        row.insertCell(0).innerHTML = "<input value=\"" + item.id + "\" type=\"checkbox\" class=\"form-check-input\" />";
        row.insertCell(1).innerHTML = "<a href=\"/Admin/Item/" + item.id + "\">" + item.marketName + "</a>";
        row.insertCell(2).innerHTML = "<label>" + item.collection.name + "</label>";
        row.insertCell(3).innerHTML = "<label>" + item.rarity.name + "</label>";
        row.insertCell(4).innerHTML = "<div>\n                                           <div class=\"dropdown\">\n                                               <button class=\"btn btn-primary dropdown-toggle\" type=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                                                   <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" fill=\"currentColor\" class=\"bi bi-three-dots\" viewBox=\"0 0 16 16\">\n                                                       <path d=\"M3 9.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z\"></path>\n                                                   </svg>\n                                               </button>\n                                               <div class=\"dropdown-menu\">\n                                                   <a class=\"dropdown-item\" href=\"/Admin/EditItem/" + item.id + "\">Edit</a>\n                                                   <button class=\"dropdown-item delete\">Delete</button>\n                                               </div>\n                                           </div>\n                                       </div>";
        row.cells.item(4).querySelector('.delete').addEventListener('click', deleteItemListener);
    }
}, { once: true });
//# sourceMappingURL=manage-items.js.map