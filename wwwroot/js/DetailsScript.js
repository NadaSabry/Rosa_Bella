function Imgsrc(source) {
    console.log(source);
    document.getElementById("big-image").style.backgroundImage = `url('${source}')`;
}

$(document).ready(function () {
    $('.content').click(function () {
        $('.content').toggleClass("heart-active")
        $('.text').toggleClass("heart-active")
        $('.numb').toggleClass("heart-active")
        $('.heart').toggleClass("heart-active")
    });
});