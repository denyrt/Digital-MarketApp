//const form = $('#form');
//const marketName = $('#marketName');
//const description = $('#description');
//const rarityId = $('#rarityId');
//const collectionId = $('#collectionId');
//const submit = $('#submit');

//let marketNameIsValid: boolean;
//let descriptionIsValid: boolean = true;
//let rarityIdIsValid: boolean = true;
//let collectionIdIsValid: boolean = true;

//marketName.change((data) => {
//    const input = data.target as HTMLInputElement;
//    marketNameIsValid = input.value.length >= 1 && input.value.length <= 100;
//    actualizeSubmitButton();
//});

//function actualizeSubmitButton(): void {
//    const formIsValid = marketNameIsValid && descriptionIsValid && rarityIdIsValid && collectionIdIsValid;
//    const btn = submit[0] as HTMLButtonElement;
//    btn.disabled = !formIsValid;
//}