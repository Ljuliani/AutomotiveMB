// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Estado del popup
const popup = document.getElementById("popup");
const popupText = document.getElementById("popup-text");
const closeBtn = popup.querySelector(".close-btn");

// Abrir popup al hacer clic en una tarjeta
document.querySelectorAll(".car-card").forEach(card => {
    card.addEventListener("click", () => {
        const info = card.getAttribute("data-info") || "Sin información disponible.";
        popupText.textContent = info;
        popup.classList.remove("popup-hidden");
        popup.setAttribute("aria-hidden", "false");
    });
});

// Cerrar por botón
closeBtn.addEventListener("click", () => {
    popup.classList.add("popup-hidden");
    popup.setAttribute("aria-hidden", "true");
});

// Cerrar haciendo clic fuera del contenido
popup.addEventListener("click", (e) => {
    if (e.target === popup) {
        popup.classList.add("popup-hidden");
        popup.setAttribute("aria-hidden", "true");
    }
});

// Cerrar con Escape
document.addEventListener("keydown", (e) => {
    if (e.key === "Escape" && !popup.classList.contains("popup-hidden")) {
        popup.classList.add("popup-hidden");
        popup.setAttribute("aria-hidden", "true");
    }
});