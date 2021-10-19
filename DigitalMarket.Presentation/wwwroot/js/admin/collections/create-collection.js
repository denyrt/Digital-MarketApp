document.addEventListener('DOMContentLoaded', function () {
    var imageUrl = document.getElementById('imageUrl');
    var image = document.getElementById('image');
    if (imageUrl) {
        imageUrl.addEventListener('change', function (e) {
            if (image) {
                image.src = imageUrl.value;
            }
        });
    }
}, { once: true });
//# sourceMappingURL=create-collection.js.map