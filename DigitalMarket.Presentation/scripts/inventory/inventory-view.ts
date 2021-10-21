import { CancelSellOfferCommand, CreateSellOfferCommand, MarketplaceApiClient } from '../marketplace/services/marketplace-api-client.js';

document.addEventListener('DOMContentLoaded', () => {
    const marketplaceApi = new MarketplaceApiClient();

    const removeSellOfferListener = async (e: Event) => {
        const btn = e.target as HTMLButtonElement;
        const offerId = btn.getAttribute('data');
        const cancelOfferCommand: CancelSellOfferCommand = { id: offerId };
        const result = await marketplaceApi.cancelSellOffer(cancelOfferCommand);
        if (result.success) {
            if (btn.classList.contains('cancel-offer')) btn.classList.remove('cancel-offer');
            btn.classList.add('sell-at-marketplace');
            btn.textContent = 'Sell at marketplace';
            btn.removeEventListener('click', removeSellOfferListener);
            btn.addEventListener('click', sellAtMarketplaceListener);
        }
        else {
            alert(result.code);
        }
    };

    const sellAtMarketplaceListener = (e: Event) => {
        const button = e.target as HTMLElement;
        const card = button.parentElement.parentElement.parentElement.parentElement.parentElement;
        const instanceId = card.getAttribute('data');

        document.getElementById('sellItemDialog').innerHTML =
        `<div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="dialogTitle">Create sell offer</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <h5>${card.querySelector('h5.card-title').textContent}</h5>
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <label>Price</label>
                                <input id="price"
                                       type="number"
                                       step=0.01
                                       class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div id="alerts-area">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    <button id="dialog-confirm" type="button" class="btn btn-warning" disabled>Confirm</button>
                </div>
            </div>
        </div>`;

        const dialog: any = $('#sellItemDialog');
        const alertsArea = document.getElementById('alerts-area');
        
        const acceptButton = document.getElementById('dialog-confirm') as HTMLButtonElement;
        const acceptListener = async (e: Event) => {
            const command: CreateSellOfferCommand = {
                instanceId: instanceId,
                price: Number.parseFloat(Number.parseFloat(priceInput.value).toFixed())
            };
            const result = await marketplaceApi.createSellOffer(command);

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
                alertsArea.innerHTML = `<div class="alert alert-danger" role="alert">${result.code}</div>`;
                return;
            }
        }

        const priceInput = document.getElementById('price') as HTMLButtonElement;
        const priceIsValid = (): boolean => {
            const value = Number.parseFloat(priceInput.value);
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
        }
        const priceListener = (e: Event) => {
            acceptButton.disabled = !priceIsValid();
        };

        acceptButton.addEventListener('click', acceptListener);
        priceInput.addEventListener('keyup', priceListener);
        priceInput.addEventListener('change', priceListener);

        dialog.on('hidden.bs.modal', function (e) {
            acceptButton.removeEventListener('click', acceptListener)
            priceInput.removeEventListener('keyup', priceListener);
            priceInput.removeEventListener('change', priceListener);
            dialog.modal('dispose');
        });
        dialog.modal('show');
    };

    document.querySelectorAll('.item-instance-card').forEach(x => {
        x.querySelector('.sell-at-marketplace')?.addEventListener('click', sellAtMarketplaceListener);
        x.querySelector('.cancel-offer')?.addEventListener('click', removeSellOfferListener);
    });
}, { once: true });