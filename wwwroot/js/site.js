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

$('#popupForm').load("/Adverts/Form")





//function toggle($toBeHidden, $toBeShown) {
//    $toBeHidden.hide().prop('disabled', true);
//    $toBeShown.show().prop('disabled', false).focus();
//}

//function showOptions(inputName) {
//    var $select = $(`select[name=${inputName}]`);
//    toggle($(`input[name=${inputName}]`), $select);
//    $select.val(null);
//}


//function showCustomInput(inputName) {
//    toggle($(`select[name=${inputName}]`), $(`input[name=${inputName}]`));
//}
