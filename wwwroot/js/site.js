// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const slideshowImages = document.querySelectorAll(".slideshow-img");

const nextImageDelay = 1000;
let currentImageCounter = 0;

slideshowImages[currentImageCounter].style.display = "block";

setInterval(nextImage, nextImageDelay);

function nextImage() {
    
    slideshowImages[currentImageCounter].style.display = "block";
    currentImageCounter = (currentImageCounter + 1) % slideshowImages.length;

}