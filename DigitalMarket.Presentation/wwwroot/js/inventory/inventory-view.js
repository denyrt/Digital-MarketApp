var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import { MarketplaceApiClient } from '../marketplace/services/marketplace-api-client.js';
document.addEventListener('DOMContentLoaded', function () {
    var marketplaceApi = new MarketplaceApiClient();
    var removeSellOfferListener = function (e) { return __awaiter(void 0, void 0, void 0, function () {
        var btn, offerId, cancelOfferCommand, result;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    btn = e.target;
                    offerId = btn.getAttribute('data');
                    cancelOfferCommand = { id: offerId };
                    return [4 /*yield*/, marketplaceApi.cancelSellOffer(cancelOfferCommand)];
                case 1:
                    result = _a.sent();
                    if (result.success) {
                        if (btn.classList.contains('cancel-offer'))
                            btn.classList.remove('cancel-offer');
                        btn.classList.add('sell-at-marketplace');
                        btn.textContent = 'Sell at marketplace';
                        btn.removeEventListener('click', removeSellOfferListener);
                        btn.addEventListener('click', sellAtMarketplaceListener);
                    }
                    else {
                        alert(result.code);
                    }
                    return [2 /*return*/];
            }
        });
    }); };
    var sellAtMarketplaceListener = function (e) {
        var button = e.target;
        var card = button.parentElement.parentElement.parentElement.parentElement.parentElement;
        var instanceId = card.getAttribute('data');
        document.getElementById('sellItemDialog').innerHTML =
            "<div class=\"modal-dialog modal-dialog-centered\" role=\"document\">\n            <div class=\"modal-content\">\n                <div class=\"modal-header\">\n                    <h5 class=\"modal-title\" id=\"dialogTitle\">Create sell offer</h5>\n                    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\n                        <span aria-hidden=\"true\">&times;</span>\n                    </button>\n                </div>\n                <div class=\"modal-body\">\n                    <div class=\"row\">\n                        <div class=\"col\">\n                            <h5>" + card.querySelector('h5.card-title').textContent + "</h5>\n                            <hr />\n                        </div>\n                    </div>\n                    <div class=\"row\">\n                        <div class=\"col\">\n                            <div class=\"form-group\">\n                                <label>Price</label>\n                                <input id=\"price\"\n                                       type=\"number\"\n                                       step=0.01\n                                       class=\"form-control\" />\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"row\">\n                        <div class=\"col\">\n                            <div id=\"alerts-area\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"modal-footer\">\n                    <button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Cancel</button>\n                    <button id=\"dialog-confirm\" type=\"button\" class=\"btn btn-warning\" disabled>Confirm</button>\n                </div>\n            </div>\n        </div>";
        var dialog = $('#sellItemDialog');
        var alertsArea = document.getElementById('alerts-area');
        var acceptButton = document.getElementById('dialog-confirm');
        var acceptListener = function (e) { return __awaiter(void 0, void 0, void 0, function () {
            var command, result;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        command = {
                            instanceId: instanceId,
                            price: Number.parseFloat(Number.parseFloat(priceInput.value).toFixed())
                        };
                        return [4 /*yield*/, marketplaceApi.createSellOffer(command)];
                    case 1:
                        result = _a.sent();
                        if (result.success) {
                            button.removeEventListener('click', sellAtMarketplaceListener);
                            if (button.classList.contains('sell-at-marketplace')) {
                                button.classList.remove('sell-at-marketplace');
                            }
                            button.classList.add('cancel-offer');
                            button.setAttribute('data', result.sellOfferId);
                            button.textContent = 'Cancel sell offer';
                            button.addEventListener('click', removeSellOfferListener);
                            dialog.modal('hide');
                        }
                        else {
                            alertsArea.innerHTML = "<div class=\"alert alert-danger\" role=\"alert\">" + result.code + "</div>";
                            return [2 /*return*/];
                        }
                        return [2 /*return*/];
                }
            });
        }); };
        var priceInput = document.getElementById('price');
        var priceIsValid = function () {
            var value = Number.parseFloat(priceInput.value);
            if (Number.isNaN(value)) {
                alertsArea.innerHTML = '<div class="alert alert-danger" role="alert">Price is required (it must be number).</div>';
                return false;
            }
            if (value <= 0) {
                alertsArea.innerHTML = '<div class="alert alert-danger" role="alert">Price must be greater than 0.</div>';
                return false;
            }
            alertsArea.innerHTML = '';
            return true;
        };
        var priceListener = function (e) {
            acceptButton.disabled = !priceIsValid();
        };
        acceptButton.addEventListener('click', acceptListener);
        priceInput.addEventListener('keyup', priceListener);
        priceInput.addEventListener('change', priceListener);
        dialog.on('hidden.bs.modal', function (e) {
            acceptButton.removeEventListener('click', acceptListener);
            priceInput.removeEventListener('keyup', priceListener);
            priceInput.removeEventListener('change', priceListener);
            dialog.modal('dispose');
        });
        dialog.modal('show');
    };
    document.querySelectorAll('.item-instance-card').forEach(function (x) {
        var _a, _b;
        (_a = x.querySelector('.sell-at-marketplace')) === null || _a === void 0 ? void 0 : _a.addEventListener('click', sellAtMarketplaceListener);
        (_b = x.querySelector('.cancel-offer')) === null || _b === void 0 ? void 0 : _b.addEventListener('click', removeSellOfferListener);
    });
}, { once: true });
//# sourceMappingURL=inventory-view.js.map