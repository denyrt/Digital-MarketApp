document.addEventListener('DOMContentLoaded', () => {
    const imageUrl = document.getElementById('imageUrl') as HTMLInputElement;
    const image = document.getElementById('image') as HTMLImageElement;
    if (imageUrl) {
        imageUrl.addEventListener('change', (e) => {
            if (image) {
                image.src = imageUrl.value;
            }
        });
    }
}, { once: true });