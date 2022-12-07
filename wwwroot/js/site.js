// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const slideshowImages = document.querySelectorAll(".intro .slideshow-img");

const nextImageDelay = 3000;
let currentImageCounter = 0;

slideshowImages[currentImageCounter].site.display = "block";

setInterval(nextImage, nextImageDelay);

function nextImage() {
    slideshowImages[currentImageCounter].site.display = "none";
    currentImageCounter = (currentImageCounter + 1) % slideshowImages.length;

}