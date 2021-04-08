$(function () {
    let thisSlide = 0;
    let slideInterval = 8000;
    let sliders;
    sliders = $('#slider-controller').children();
    $('.kkk').hide('slow', 'linear');
    setInterval(() => {
        $(sliders[thisSlide]).hide('slow', 'linear');
        if (thisSlide >= sliders.length - 1) {
            thisSlide = 0;
        }
        else {
            ++thisSlide;
        }
        $(sliders[thisSlide]).show('slow', 'linear');
    }, slideInterval);

})
