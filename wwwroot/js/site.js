window.onload = function () {

    const slideshowImages = document.querySelectorAll("#hero-banner-container .slideshow-img");

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

$('#popupTandC').load("/Adverts/TC");


// Open popup
document.addEventListener('click', function (event) {
    if (event.target.matches('[id^="openPopup-"]')) {
        var adId = event.target.id.replace('openPopup-', '');
        var popup = document.getElementById('adPopup-' + adId);
        if (popup) {
            popup.style.display = 'block';
        }
    }
});

// Close popup
document.addEventListener('click', function (event) {
    if (event.target.matches('[id^="closePopup-"]')) {
        var adId = event.target.id.replace('closePopup-', '');
        var popup = document.getElementById('adPopup-' + adId);
        if (popup) {
            popup.style.display = 'none';
        }
    }
});

// Open popup
document.addEventListener('click', function (event) {
    if (event.target.matches('[id^="openPopup-"]')) {
        var adId = event.target.id.replace('openPopup-', '');
        var popup = document.getElementById('filterPopup-' + adId);
        if (popup) {
            popup.style.display = 'block';
        }
    }
});

// Close popup
document.addEventListener('click', function (event) {
    if (event.target.matches('[id^="closePopup-"]')) {
        var adId = event.target.id.replace('closeFilterPopup', '');
        var popup = document.getElementById('filterPopup-' + adId);
        if (popup) {
            popup.style.display = 'none';
        }
    }
});


$(document).ready(function () {
    $('.ad-link').click(function (e) {
        e.preventDefault();

        var adId = $(this).data('ad-id');

        
        if (adId === adId) {
            // Do something for Link 2
            var popupContainer = $('#popup-container');

            // Make an AJAX call to retrieve the popup content from the server
            $.ajax({
                url: '/Adverts/GetPopupContent',
                data: { adId: adId },
                success: function (response) {
                    // Render the retrieved popup content in the popup container
                    popupContainer.html(response);
                },
                error: function () {
                    console.log('Error retrieving popup content');
                }
            });
            console.log("Link 2 clicked");
        }

        
    });
});

$(document).ready(function () {
    $('.filter-link').click(function (e) {
        e.preventDefault();

        //var adId = $(this).data('ad-id');
        var popupContainer = $('#popup-container');

        // Make an AJAX call to retrieve the popup content from the server
        $.ajax({
            url: '/Adverts/GetFilterContent',
            success: function (response) {
                // Render the retrieved popup content in the popup container
                popupContainer.html(response);
            },
            error: function () {
                console.log('Error retrieving popup content');
            }
        });
    });
});