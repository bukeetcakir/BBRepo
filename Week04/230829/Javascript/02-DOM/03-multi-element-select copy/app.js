let result;
result = document.getElementsByClassName("card-title");
result = document.getElementsByClassName("task");
result[0].innerText = "Netflix'i iptal et";
for (let i = 0; i < result.length; i++) {
    if (i % 2 == 0) {
        result[i].style.backGroundColor = "#fcfc00";
    }
    else {
        result[i].style.backGroundColor = "#689844";
    }
}

result = document.querySelectorAll(".task");
result = document.querySelectorAll("#title");

result = document.querySelectorAll("ul");
result = document.querySelectorAll("#task-list2 .task");

result = document.getElementsByTagName("li");
result = document.querySelectorAll("li");

console.log(result);