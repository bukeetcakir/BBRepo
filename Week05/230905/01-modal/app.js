const btnSave = document.querySelector("#btn-save");
const btnModalClose = document.querySelector(".btn-modal-header-close");
const btnModalFooterSave = document.querySelector(".btn-modal-footer-save");
const mainModal = document.querySelector(".main-modal");

btnSave.addEventListener("click", openModal);
btnModalClose.addEventListener("click", closeModal);
btnModalFooterSave.addEventListener("click", saveChanges);
mainModal.addEventListener("click", function (e) {
    if (e.target.className == "main-modal") {
        closeModal();
    }
});

function openModal() {
    mainModal.classList.remove("hidden");
}

function closeModal() {
    mainModal.classList.add("hidden");
}

function saveChanges() {
    //Burada kaydetme kodları yer alır
    closeModal();
}

