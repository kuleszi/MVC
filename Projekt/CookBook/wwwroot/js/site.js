const searchBarInput = document.getElementById("searchBar");
const searchResults = document.getElementById("searchResults");

searchBarInput.addEventListener("input", () => {
  const query = searchBarInput.value;
  if(query.length === 0) { searchResults.style.display = "none";
    return;
  }

  fetch(`/Recipe/Search/?SearchTerm=${query}`)
    .then((response) => response.json())
    .then((data) => {
      if (data) {
        searchResults.innerHTML = "";
        searchResults.style.display = 'none';
        data.forEach((recipe) => {
          const dropdownItem = document.createElement("a");
          searchResults.style.display = 'block';
          dropdownItem.href = `/Recipe/Details/${recipe.id}`;
          dropdownItem.className = "dropdown-item";
          dropdownItem.textContent = recipe.name;
          searchResults.appendChild(dropdownItem);
        });
      }
    });
});
