window.onload = function () {

    const slideshowImages = document.querySelectorAll(".intro .slideshow-img");

    if (slideshowImages.length != 0) {
        const nextImageDelay = 3000;
        let currentImageCounter = 0;

        slideshowImages[currentImageCounter].style.display = "block";

        setInterval(nextImage, nextImageDelay);

        function nextImage() {
            slideshowImages[currentImageCounter].style.display = "none";
            currentImageCounter = (currentImageCounter + 1) % slideshowImages.length;
            slideshowImages[currentImageCounter].style.display = "block";
        }
    }
}

$('#popupForm').load("/Adverts/Form");


