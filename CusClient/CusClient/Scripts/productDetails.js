$(document).ready(function () {
    $(".edit-product-section__select-img").slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: "<button type='button' class='select__slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow: "<button type='button' class='select__slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>",
        cssEase: 'ease-in-out',
        speed: 500,
        vertical: true,
        responsive: [
            {
                breakpoint: 1025,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    autoplay: false,
                    speed: 300,
                    infinite: false,
                    vertical: false,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    autoplay: false,
                    speed: 300,
                    infinite: false,
                    vertical: false,
                }
            },
        ]
    })
})

// Click to show image
const arrayImage = [
    "product-section_img1",
    "product-section_img2",
    "product-section_img3",
    "product-section_img4",
    "product-section_img5",
    "product-section_img6"
];

const thisSelectImage = document.querySelector("#edit-product__img");
const selectImageItems = document.querySelectorAll(".select-img__item");

Array.from(selectImageItems).forEach(function (elementItem) {
    elementItem.addEventListener("click", function () {
        let firstImageChild = elementItem.firstElementChild.src;
        let startSliceIndex = firstImageChild.indexOf("Images");
        let jpgIndex = firstImageChild.indexOf(".jpg");
        let imageName = firstImageChild.slice(startSliceIndex + 7, jpgIndex);

        thisSelectImage.src = `/Content/Images/${imageName}.jpg`;
    });
});

//Feedback slider
$(document).ready(function () {
    $(".introduce-section__feedback-slider").slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        autoplay: true,
        autoplaySpeed: 3000,
        prevArrow: "<button type='button' class='feedback__slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow: "<button type='button' class='feedback__slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>",
        cssEase: 'ease-in-out',
        speed: 500,
        responsive: [
            {
                breakpoint: 1025,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    autoplay: false,
                    speed: 300,
                    infinite: false,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    autoplay: false,
                    speed: 300,
                    infinite: false,
                }
            },
        ]
    })
})