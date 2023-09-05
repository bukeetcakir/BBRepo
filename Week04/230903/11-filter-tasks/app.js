let taskList;
let btnAdd = document.getElementById("btn-add");
let inputNewTask = document.getElementById("txt-description");
let filters = document.querySelectorAll("#filters span");
let btnClearAll = document.getElementById("btn-clear-all");
let taskListContainer = document.getElementById("task-list-container");


let taskArray = [];

let filterMode = "all";
let isArrayFull = true;

let updatedId; //O sırada güncellenecek task'in id'si
let isUpdateMode = false;

btnAdd.addEventListener("click", addNewTask);

btnClearAll.addEventListener("click", function () {
    taskArray = [];
    displayTasks();
})

for (const span of filters) {
    span.addEventListener("click", function () {
        document.querySelector("span.active").classList.remove("active");
        span.classList.add("active");
        filterMode = span.id;
        displayTasks();
    });
}

function getTasks() {
    taskArray = [
        { id: 1, descripition: "Netflixi iptal et", status: "completed" },
        { id: 2, descripition: "Pilav yapmayı unutma", status: "pending" },
        { id: 3, descripition: "Su iç", status: "completed" },
        { id: 4, descripition: "Çöpleri at", status: "completed" },
        { id: 5, descripition: "Voleybol maçı izle", status: "pending" }
    ];
    if (taskArray.length > 0) {
        let div = `
            <div class="card mt-3">
                <ul id="task-list" class="list-group">
                        
                </ul>
            </div>
        `;
        taskListContainer.insertAdjacentHTML("beforeend", div);
    }
}





function displayTasks() {

    if (taskArray.length >= 1) {
        taskList = document.getElementById("task-list");
        taskList.innerHTML = ""; //ilgili elementin içindeki html scriptlerini etkiler.
        for (const task of taskArray) {

            let isCompleted = task.status == "completed" ? true : false;
            if (filterMode == task.status || filterMode == "all") {

                let li = `
            <li class="list-group-item task d-flex justify-content-between align-items-center ${isCompleted ? "bg-success" : ""}" >
            <div class="form-check">
                <input onclick="updateStatus(this)" class="form-check-input" type="checkbox" name="" id="${task.id}" ${isCompleted ? "checked" : ""}>
                <label class="form-check-label ${isCompleted ? 'completed' : ''}" for="${task.id}">${task.descripition}</label>
            </div>
            <div class="dropdown ">
                <button class="btn btn-outline-info dropdown-toggle" type="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                    <i class="fa-solid fa-ellipsis"></i>
                </button>
                <ul class="dropdown-menu">
                    <li><a onclick="updateTask(${task.id},'${task.descripition}')" class="dropdown-item" href="#">Düzenle</a></li>
                    <li><a onclick="removeTask(${task.id})" class="dropdown-item" href="#">Sil</a></li>
                </ul>
            </div>
            </li>
            `;
                taskList.insertAdjacentHTML("beforeend", li);
            }
        }
    }
    else {
        let alert = `
        <div class="alert alert-warning">
            Herhangi bir görev kaydı bulunamadı.
        </div>
        `;
        taskListContainer.insertAdjacentHTML("beforeend", alert);
        taskList = document.getElementById("task-list");
        taskList ? taskList.innerHTML = "" : taskList;
    }
}


function addNewTask(e) {
    e.preventDefault();
    if (!isUpdateMode) {
        //Yeni kayıt
        if (isFull(inputNewTask.value)) {
            let newId = textArray.length == 0 ? 1 : taskArray[taskArray.length - 1].id + 1;
            taskArray.push({ id: newId, descripition: inputNewTask.value });
        } else {
            alert("Lütfen görev açıklamasını boş bırakmayınız");
        }
    } else {
        //Güncelleme
        for (const task of taskArray) {
            if (task.id == updatedId) {
                task.descripition = inputNewTask.value;
                isUpdateMode = false;
                updatedId = null;
                btnAdd.innerText = "Ekle";
                btnAdd.classList.remove("btn-outline-info");
            }
        }
    }
    displayTasks();
    inputNewTask.value = "";
    inputNewTask.focus();
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

function updateTask(id, descripition) {
    updatedId = id;
    isUpdateMode = true;
    inputNewTask.value = descripition;
    inputNewTask.focus();
    btnAdd.innerText = "Güncelle";
    btnAdd.classList.add("btn-outline-info");
    //Ödev: Buraya öyle bir kod yazılsın ki diğer task'lerin olduğu bölüm kullanılamaz olsun.
}

function updateStatus(element) {
    // console.log(element.getAttribute("id"));
    // console.log(element.id);
    let updatedIndex;
    for (let i = 0; i < taskArray.length; i++) {
        if (taskArray[i].id == element.getAttribute("id")) {
            updatedIndex = i;
        }
    }
    if (element.checked) {
        element.nextElementSibling.classList.add("completed");
        element.parentElement.parentElement.classList.add("bg-success");
        taskArray[updatedIndex].status = "completed";
    } else {
        element.nextElementSibling.classList.remove("completed");
        element.parentElement.parentElement.classList.remove("bg-success");
        taskArray[updatedIndex].status = "pending";
    }
}

getTasks();
displayTasks();