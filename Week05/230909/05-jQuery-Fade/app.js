$("#btn-fade-out").click(() => {
    $(".box").fadeOut(1000);
})

$("#btn-fade-in").click(() => {
    $(".box").fadeIn(1000);
})

$("#btn-fade-toggle").click(() => {
    $(".box").fadeToggle(1000);
})

$("#btn-fade-to").click(() => {
    $(".box").fadeTo("slow",0.5);
})