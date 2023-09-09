$("#btn-hide").click(() => {
    $(".box").hide(500);
})

$("#btn-show").click(() => {
    $(".box").show(500);
})

$("#btn-toggle").click(() => {
    $(".box").toggle("slow");
})
