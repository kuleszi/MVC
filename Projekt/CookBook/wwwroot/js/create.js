let ingredientIndex = 1;
let stepIndex = 1;

const IngredientsBtn = document.getElementById("IngredientsBtn");
const IngredientsDiv = document.getElementById("Ingredients");
const StepsBtn = document.getElementById("StepsBtn");
const StepsDiv = document.getElementById("Steps");

IngredientsBtn.addEventListener('click', btn => {
    IngredientsDiv.insertAdjacentHTML('beforeend', `<div class="row"> <div class="col-6"><input name="Ingredients[${ingredientIndex}].Name" type="text"/><span asp-validation-for="Ingredients[${ingredientIndex}].Name" class="text-danger" ></span></div>
        <div class="col-3">
        <input name="Ingredients[${ingredientIndex}].Amount" type="number"/><span asp-validation-for="Ingredients[${ingredientIndex}].Amount" class="text-danger" ></span></div>
        <div class="col-3">
        <select name="Ingredients[${ingredientIndex}].Measurment"><option>g</option><option>dag</option><option>kg</option><option>ml</option><option>l</option><option>szklanka</option><option>łyżka</option><option>łyżeczka</option><option>szczypta</option><option>sztuka</option><option>do smaku</option></select><span asp-validation-for="Ingredients[${ingredientIndex}].Measurment" class="text-danger" ></span></div></div>`)
    ingredientIndex++;
});

StepsBtn.addEventListener('click', btn => {
    StepsDiv.insertAdjacentHTML('beforeend', `<div class="row"> <div class="col-3"><input name="Steps[${stepIndex}].StepNumber" type="number"/><span asp-validation-for="Steps[${stepIndex}].StepNumber" class="text-danger" ></span></div>
        <div class="col-9"><input name="Steps[${stepIndex}].StepDescription" type="text"/><span asp-validation-for="Steps[${stepIndex}].StepDescription" class="text-danger" ></span></div></div>
        `)
    stepIndex++;
})