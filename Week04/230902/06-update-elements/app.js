let taskArray = [
    { id: 1, descripition: "Netflix'i iptal et" },
    { id: 2, descripition: "Pilav yapmayı unutma" },
    { id: 3, descripition: "Su iç" },
    { id: 4, descripition: "Çöpleri at" },
    { id: 5, descripition: "Voleybol maçı izle" }
];

let taskList = document.getElementById("task-list");

for (const task of taskArray) {
    let li = `
    <li class="list-group-item task ${task.id % 2 == 0 ? "bg-warning" : ""}">
    <div class="form-check">
        <input class="form-check-input" type="checkbox" name="" id="${task.id}">
        <label class="form-check-label" for="${task.id}">${task.descripition}</label>
    </div>
    </li>
    `;
    taskList.insertAdjacentHTML("beforeend", li);
}

// document.getElementById("task-list").parentElement.remove();
// console.log(document.getElementById("task-list").children[0].firstElementChild.firstElementChild.getAttribute("type"));

// document.getElementById("task-list").children[0].firstElementChild.firstElementChild.setAttribute("id", "bu-degisen-id");

// console.log(console.log(document.getElementById("task-list").children[0].firstElementChild.firstElementChild.getAttribute("id")));

taskList = document.querySelectorAll(".task");
for (const task of taskList) {
    if (task.classList.contains("bg-warning")) {
        task.classList.remove("bg-warning");
        task.classList.add("bg-danger");
    }

}