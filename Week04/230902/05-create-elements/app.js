let taskArray = [
    { id: 1, descripition: "Netflix'i iptal et" },
    { id: 2, descripition: "Pilav yapmayı unutma" },
    { id: 3, descripition: "Su iç" },
    { id: 4, descripition: "Çöpleri at" },
    { id: 5, descripition: "Voleybol maçı izle" }
];

let taskList = document.getElementById("task-list");

for (let i = 0; i < taskArray.length; i++) {
    console.log(taskArray[i].descripition)
}

for (const task of taskArray) {
    let li = `
    <li class="list-group-item task">
    <div class="form-check">
        <input class="form-check-input" type="checkbox" name="" id="${task.id}">
        <label class="form-check-label" for="${task.id}">${task.descripition}</label>
    </div>
    </li>
    `;
    taskList.insertAdjacentHTML("beforeend", li);
}