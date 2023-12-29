let myCarousel = document.querySelector('#carouselExampleIndicators')
let carousel = new bootstrap.Carousel(myCarousel, {
    interval: 5000,
    ride: true,
    pause: 'hover',
})

$('[data-slide-to=0]').trigger('click');

