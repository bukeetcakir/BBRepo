let result;
// result = document.getElementById("card-header");// id'ye göre element seçer
// result.style.fontSize = "100px";
// result.style.backgroundColor="#FCF050";
// result.className="bg-warning";
// result.className = "deneme";
// result = document.getElementById("title").classList;
// result = document.getElementById("bau-bright").style.display = "none";
// result = document.getElementById("title"); //Id ya da class iki yerde yazılırsa kod akışına göre ilk elementi seçer

result = document.querySelector("#card-header");
result = document.querySelector(".display-6");
result = document.querySelector(".card-title");
result = document.querySelector("ul");

console.log(result);
