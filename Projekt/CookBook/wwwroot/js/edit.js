const editIcons = document.querySelectorAll(".edit-icon");
const deleteIcons = document.querySelectorAll(".delete-icon");
const addIconsIn = document.querySelectorAll(".addIconsIn-icon");
const addIconsSt = document.querySelectorAll(".addIconsSt-icon");

function editRow(chosenRow) {
  const inputs = chosenRow.querySelectorAll(".edit-input");
  const texts = chosenRow.querySelectorAll(".edit-text");
  for (let i = 0; i < inputs.length; i++) {
    if (!inputs[i].classList.contains("d-none") && texts[i]) {
      texts[i].innerText = inputs[i].value;
    }
    inputs[i].classList.toggle("d-none");
    if (texts[i]) texts[i].classList.toggle("d-none");
  }
}

function deleteRow(chosenRow) {
  const row = chosenRow;
  const container = row.parentElement;
  if (container.querySelectorAll(".editable-row").length > 1) {
    row.remove();
    updateIndexes(container);
  }
}

function updateIndexes(containerOrSelector) {
  const container =
    typeof containerOrSelector === "string"
      ? document.querySelector(containerOrSelector)
      : containerOrSelector;

  if (!container) return;
  const rows = container.querySelectorAll(".editable-row");

  rows.forEach((row, i) => {
    const fields = row.querySelectorAll("input, textarea");
    fields.forEach((field) => {
      field.name = field.name.replace(/\[\d+\]/, `[${i}]`);
    });
  });
}

for (let icon of addIconsIn) {
  icon.addEventListener("click", function addIn() {
    const copy = document
      .querySelector(".ingredients-list .editable-row")
      .cloneNode(true);
    const deleteIcon = copy.querySelector(".delete-icon");
    deleteIcon.addEventListener("click", function () {
      const row = this.closest(".editable-row");
      deleteRow(row);
    });
    const editIcon = copy.querySelector(".edit-icon");
    editIcon.addEventListener("click", function () {
      const row = this.closest(".editable-row");
      editRow(row);
    });

    for (let input of copy.querySelectorAll(".edit-input")) input.value = "";
    for (let span of copy.querySelectorAll(".edit-text")) span.innerText = "";
    copy.querySelector('input[type="hidden"]').value = "0";
    copy.querySelector(".addIconsIn-icon").addEventListener("click", addIn);
    icon.closest(".editable-row").after(copy);
    updateIndexes(".ingredients-list");
  });
}

for (let icon of addIconsSt) {
  icon.addEventListener("click", function addSt() {
    const copy = document
      .querySelector(".steps-list .editable-row")
      .cloneNode(true);
    const deleteIcon = copy.querySelector(".delete-icon");
    deleteIcon.addEventListener("click", function () {
      const row = this.closest(".editable-row");
      deleteRow(row);
    });
    const editIcon = copy.querySelector(".edit-icon");
    editIcon.addEventListener("click", function () {
      const row = this.closest(".editable-row");
      editRow(row);
    });

    for (let input of copy.querySelectorAll(".edit-input")) input.value = "";
    for (let span of copy.querySelectorAll(".edit-text")) span.innerText = "";
    copy.querySelector('input[type="hidden"]').value = "0";
    copy.querySelector(".addIconsSt-icon").addEventListener("click", addSt);
    icon.closest(".editable-row").after(copy);
    updateIndexes(".steps-list");
  });
}

for (let icon of editIcons) {
  icon.addEventListener("click", function () {
    const inputEditFiled = this.parentElement.querySelector(".edit-input");
    const textEditField = this.parentElement.querySelector(".edit-text");
    const row = this.closest(".editable-row");
    if (row) {
      editRow(row);
    } else {
      if (
        inputEditFiled &&
        textEditField &&
        !inputEditFiled.classList.contains("d-none")
      ) {
        textEditField.innerText = inputEditFiled.value;
      }

      if (inputEditFiled) inputEditFiled.classList.toggle("d-none");
      if (textEditField) textEditField.classList.toggle("d-none");
    }
  });
}

for (let icon of deleteIcons) {
  icon.addEventListener("click", function () {
    const row = this.closest(".editable-row");

    deleteRow(row);
  });
}

document.getElementById("deleteEditBtn").addEventListener("click", function () {
  if (confirm("Czy na pewno chcesz usunąć ten przepis?")) {
    const id = this.dataset.id;

    fetch(`/Recipe/Delete/${id}`, { method: "POST" })
      .then((response) => response.json())
      .then((data) => {
        if (data.success) {
          window.location.href = "/Recipe/MyRecipe";
        }
      });
  }
});


const image = document.querySelector(".editable-image-wrapper");

if (image) {
  const overlay = image.querySelector(".edit-icon-overlay");
  const fileInput = image.querySelector("input[name='NewPhoto']");
  const img = image.querySelector(".recipe-main-image");
  const removeBtn = image.querySelector(".btn-remove-image");


  overlay.addEventListener("click", () => {
    fileInput.click();
  });

  fileInput.addEventListener("change", function () {
    if (this.files && this.files[0]) {
      const reader = new FileReader();

      reader.onload = function (e) {
        img.src = e.target.result;
      };

      reader.readAsDataURL(this.files[0]);
    }
  });

  if (removeBtn) {
    removeBtn.addEventListener("click", () => {
      img.src = "/images/no-image.png"; 
      fileInput.value = "";
    });
  }
}

document.addEventListener("keydown", function(e) {
  if (e.key === "Enter" && e.target.tagName === "INPUT") {
    e.preventDefault();
  }
});
