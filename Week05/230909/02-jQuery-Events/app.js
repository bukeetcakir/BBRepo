$("#name-lastname").keyup(function(e){
    console.log(e.target.value);
})

$("#keypress").keypress(function(e){
    console.log("keypress olayı gerçekleşti");
})

$("keydown").keydown(function(e){
    console.log("keydown olayı gerçekleşti")
})

$("keyup").keyup(function(e){
    console.log("keyup olayı gerçekleşti")
})

$("button").dblclick(function(e){
    $(".box").css("color","white");
    $(".box").css("background-color","red");
})