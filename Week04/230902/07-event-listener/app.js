let taskArray = [
    { id: 1, descripition: "Netflix'i iptal et" },
    { id: 2, descripition: "Pilav yapmayı unutma" },
    { id: 3, descripition: "Su iç" },
    { id: 4, descripition: "Çöpleri at" },
    { id: 5, descripition: "Voleybol maçı izle" }
];

let taskList = document.getElementById("task-list");

function displayTasks() {
    for (const task of taskArray) {
        let li = `
    <li class="list-group-item task ">
    <div class="form-check">
        <input class="form-check-input" type="checkbox" name="" id="${task.id}">
        <label class="form-check-label" for="${task.id}">${task.descripition}</label>
    </div>
    </li>
    `;
        taskList.insertAdjacentHTML("beforeend", li);
    }
}

let btnAdd = document.getElementById("btn-add");
btnAdd.addEventListener("click", addNewTask);

function addNewTask() {
    let inputNewTask = document.getElementById("txt-description");
    if (isFull(inputNewTask.value)) {
        let newId = taskArray[taskArray.length - 1].id + 1;
        taskArray.push({ id: newId, descripition: inputNewTask.value });
        taskList.innerHTML = "";//ilgili elementin içindeki html scriptlerini etkiler.
        displayTasks();
    }
    else {
        alert("Lütfen görev açıklamasını boş bırakmayınız");
    }
    inputNewTask.value = "";
}

function isFull(value) {
    if (value.trim() == "") {
        return false;
    }
    return true;
}

displayTasks();

