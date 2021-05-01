$(function () {
    let thisSlide = 0;
    let slideInterval = 8000;
    let sliders;
    sliders = $('#slider-controller').children();
    $('.kkk').hide(1000, 'linear');
    setInterval(() => {
        $(sliders[thisSlide]).hide(1000, 'linear');
        if (thisSlide >= sliders.length - 1) {
            thisSlide = 0;
        }
        else {
            ++thisSlide;
        }
        $(sliders[thisSlide]).show(1000, 'linear');
    }, slideInterval);

})
