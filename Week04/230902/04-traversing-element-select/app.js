let taskList = document.getElementById("task-list");

let result = taskList;
result = taskList.children;
result = taskList.children[2];
result = taskList.firstElementChild;
result = taskList.lastElementChild;

result = document.getElementById("title");
result = document.querySelector("#title");
result = result.parentElement.parentElement.parentElement.parentElement;

let task1 = document.querySelector(".task");
result = task1;
result = result.nextElementSibling.nextElementSibling;
result = result.previousElementSibling.previousElementSibling;

result = taskList.children;
result[0].children[0].children[0].checked = true;


console.log(result);

