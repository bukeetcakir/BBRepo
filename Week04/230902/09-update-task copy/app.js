let taskList = document.getElementById("task-list");
let inputNewTask = document.getElementById("txt-description");
let btnAdd = document.getElementById("btn-add");


let taskArray = [
    { id: 1, descripition: "Netflixi iptal et" },
    { id: 2, descripition: "Pilav yapmayı unutma" },
    { id: 3, descripition: "Su iç" },
    { id: 4, descripition: "Çöpleri at" },
    { id: 5, descripition: "Voleybol maçı izle" }
];


let updatedId;//O sırada güncellenecek task'in id'si
let isUpdateMode = false;


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
            <li><a onclick="updateTask(${task.id},'${task.descripition}')" class="dropdown-item" href="#">Düzenle</a></li>
            <li><a onclick="removeTask(${task.id})" class="dropdown-item" href="#">Sil</a></li>
        </ul>
    </div>
    </li>
    `;
        taskList.insertAdjacentHTML("beforeend", li);
    }
}

btnAdd.addEventListener("click", addNewTask);

function addNewTask(e) {
    e.preventDefault();
    if (!isUpdateMode) {
        //Yeni kayıt
        if (isFull(inputNewTask.value)) {
            let newId = taskArray[taskArray.length - 1].id + 1;
            taskArray.push({ id: newId, descripition: inputNewTask.value });
        }
        else {
            alert("Lütfen görev açıklamasını boş bırakmayınız");
        }
    }
    else {
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


displayTasks();

