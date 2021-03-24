var thisSlide = 0;
var slideInterval = 2000;
var sliders;
$(function () {
    sliders = $('#slider-controller').children();
    $('.kkk').hide('slow', 'linear');
    setInterval(function () {
        $(sliders[thisSlide]).hide('slow', 'linear');
        if (thisSlide >= sliders.length - 1) {
            thisSlide = 0;
        }
        else {
            thisSlide++;
        }
        $(sliders[thisSlide]).show('slow', 'linear');
    }, slideInterval);

})
