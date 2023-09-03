let taskArray = [
    { id: 1, descripition: "Netflix'i iptal et" },
    { id: 2, descripition: "Pilav yapmayı unutma" },
    { id: 3, descripition: "Su iç" },
    { id: 4, descripition: "Çöpleri at" },
    { id: 5, descripition: "Voleybol maçı izle" }
];

let taskList = document.getElementById("task-list");

function displayTasks() {
    taskList.innerHTML = "";//ilgili elementin içindeki html scriptlerini etkiler.
    for (const task of taskArray) {
        let li = `
    <li class="list-group-item task d-flex justify-content-between align-items-center">
    <div class="form-check">
        <input class="form-check-input" type="checkbox" name="" id="${task.id}">
        <label class="form-check-label" for="${task.id}">${task.descripition}</label>
    </div>
    <div class="dropdown ">
        <button class="btn btn-outline-info dropdown-toggle" type="button" data-bs-toggle="dropdown"
        aria-expanded="false">
            <i class="fa-solid fa-ellipsis"></i>
        </button>
        <ul class="dropdown-menu">
            <li><a onclick="updateTask(${task.id})" class="dropdown-item" href="#">Düzenle</a></li>
            <li><a onclick="removeTask(${task.id})" class="dropdown-item" href="#">Sil</a></li>
        </ul>
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

function removeTask(id) {
    let deletedIndex;
    for (let i = 0; i < taskArray.length; i++) {
        if (taskArray[i].id == id) {
            deletedIndex = i;
        }
    }
    let answer = confirm(taskArray[deletedIndex].descripition + " görevini silmek istediğinizden emin misiniz?");
    if (answer) {
        taskArray.splice(deletedIndex, 1);
        displayTasks();
    }
}

displayTasks();

