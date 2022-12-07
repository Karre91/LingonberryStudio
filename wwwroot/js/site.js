
const slideshowImages = document.querySelectorAll(".intro .slideshow-img");

if (slideshowImages.length != 0) {
    const nextImageDelay = 1000;
    let currentImageCounter = 0;

    slideshowImages[currentImageCounter].style.display = "block";  //HELP

    setInterval(nextImage, nextImageDelay);

    function nextImage() {

        slideshowImages[currentImageCounter].style.display = "none"; //HELP
        currentImageCounter = (currentImageCounter + 1) % slideshowImages.length;
        slideshowImages[currentImageCounter].style.display = "block";  //HELP
    }
}

