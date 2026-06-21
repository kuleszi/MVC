let ingredientIndex = 1;
let stepIndex = 1;

const IngredientsBtn = document.getElementById("IngredientsBtn");
const IngredientsDiv = document.getElementById("Ingredients");
const StepsBtn = document.getElementById("StepsBtn");
const StepsDiv = document.getElementById("Steps");

function updateCreateIndexes(containerId, listName) {
    const rows = document.querySelectorAll(`#${containerId} .row`);
    rows.forEach((row, i) => {
        row.querySelectorAll("input, select").forEach((field) => {
            if (field.name) {
                field.name = field.name.replace(new RegExp(`${listName}\\[\\d+\\]`), `${listName}[${i}]`);
            }
        });
    });
    if (listName === "Ingredients") ingredientIndex = rows.length;
    if (listName === "Steps") stepIndex = rows.length;
}

IngredientsBtn.addEventListener("click", (btn) => {
  IngredientsDiv.insertAdjacentHTML(
    "beforeend",
    `<div class="row mb-2 align-items-center"> 
        <div class="col-5">
            <input name="Ingredients[${ingredientIndex}].Name" type="text" placeholder="Nazwa składnika"/>
            <span data-valmsg-for="Ingredients[${ingredientIndex}].Name" class="text-danger small" data-valmsg-replace="true"></span>
        </div>
        <div class="col-3">
            <input name="Ingredients[${ingredientIndex}].Amount" type="number" step="0.1" placeholder="Ilość"/>
            <span data-valmsg-for="Ingredients[${ingredientIndex}].Amount" class="text-danger small" data-valmsg-replace="true"></span>
        </div>
        <div class="col-3">
            <select name="Ingredients[${ingredientIndex}].Measurement">
                <option>g</option><option>dag</option><option>kg</option><option>ml</option><option>l</option>
                <option>szklanka</option><option>łyżka</option><option>łyżeczka</option><option>szczypta</option>
                <option>sztuka</option><option>do smaku</option>
            </select>
            <span data-valmsg-for="Ingredients[${ingredientIndex}].Measurement" class="text-danger small" data-valmsg-replace="true"></span>
        </div>
        <div class="col-1 text-end">
            <button type="button" class="btn btn-sm btn-outline-danger remove-btn border-0 fs-5" title="Usuń">❌</button>
        </div>
    </div>`
  );
  ingredientIndex++;
});

StepsBtn.addEventListener("click", (btn) => {
  StepsDiv.insertAdjacentHTML(
    "beforeend",
    `<div class="row mb-2 align-items-center"> 
        <div class="col-2">
            <input name="Steps[${stepIndex}].StepNumber" type="number" placeholder="Nr" value="${stepIndex + 1}"/>
            <span data-valmsg-for="Steps[${stepIndex}].StepNumber" class="text-danger small" data-valmsg-replace="true"></span>
        </div>
        <div class="col-9">
            <input name="Steps[${stepIndex}].StepDescription" type="text" placeholder="Opisz ten krok..."/>
            <span data-valmsg-for="Steps[${stepIndex}].StepDescription" class="text-danger small" data-valmsg-replace="true"></span>
        </div>
        <div class="col-1 text-end">
            <button type="button" class="btn btn-sm btn-outline-danger remove-btn border-0 fs-5" title="Usuń">❌</button>
        </div>
    </div>`
  );
  stepIndex++;
});

document.addEventListener("click", function(e) {
    if (e.target.classList.contains("remove-btn")) {
        const row = e.target.closest(".row");
        const container = row.closest("#Ingredients, #Steps");
        
        if (container.querySelectorAll(".row").length > 1) {
            row.remove();
            if (container.id === "Ingredients") updateCreateIndexes("Ingredients", "Ingredients");
            if (container.id === "Steps") updateCreateIndexes("Steps", "Steps");
        } else {
            row.querySelectorAll("input").forEach(input => input.value = "");
        }
    }
});