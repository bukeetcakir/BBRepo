$("#btn-slide-up").click(() => {
    $(".box").slideUp(500);
})

$("#btn-slide-down").click(() => {
    $(".box").slideDown(500);
})

$("#btn-slide-toggle").click(() => {
    $(".box").slideToggle(500);
})



$("#btn-show-courses").click(() => {
    $(".courses").slideToggle(300);
})


$("#change-box").click(function(){
    // $("#description").removeClass("box1");
    // $("#description").addClass("box2");
    $("#description").toggleClass("box2");
})
