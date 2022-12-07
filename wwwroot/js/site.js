
const slideshowImages = document.querySelectorAll(".slideshow-img");

const nextImageDelay = 1000;
let currentImageCounter = 0;

slideshowImages[currentImageCounter].style.display = "block";  //HELP

setInterval(nextImage, nextImageDelay);

function nextImage() {
    
    slideshowImages[currentImageCounter].style.display = "none"; //HELP
    currentImageCounter = (currentImageCounter + 1);
    if (currentImageCounter == slideshowImages.length) {
        currentImageCounter = 0;
    }
}