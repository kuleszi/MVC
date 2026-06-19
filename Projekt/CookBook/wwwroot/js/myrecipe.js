let recipeIdToDelete = null;
const banner = document.getElementById("deleteBanner");
const DeleteBtns = document.getElementsByClassName("delete-trigger");
const deleteMessage = document.getElementById('deleteMessage');
const bannerButtons = document.getElementById('bannerButtons');

for (const btn of DeleteBtns) {
  btn.addEventListener("click", function () {
    recipeIdToDelete = this.dataset.id;
    banner.classList.remove("d-none");
  });
}

document
  .getElementById("cancelDeleteBtn")
  .addEventListener("click", () => banner.classList.add("d-none"));
document.getElementById("confirmDeleteBtn").addEventListener("click", () =>
  fetch(`/Recipe/Delete/${recipeIdToDelete}`, { method: "POST" })
    .then((response) => response.json())
    .then((data) => {
      if (data.success) {
        deleteMessage.innerText = "Przepis został usunięty";
        bannerButtons.classList.add("d-none");
        setTimeout(() => {
          window.location.reload();
        }, 1500);
      }
    }),
);
