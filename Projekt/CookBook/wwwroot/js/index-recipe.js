const categoryLinks = document.querySelectorAll(".category-link");

categoryLinks.forEach((link) => {
  link.addEventListener("click", (event) => {
    event.stopPropagation();
    console.log("Kliknięto link, zdarzenie zatrzymane!");
    const url = event.currentTarget.getAttribute("href");

    window.location.href = url;
  });
});
