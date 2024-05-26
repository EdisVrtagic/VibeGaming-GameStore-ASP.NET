let lastScrollTop = 0;
const header = document.getElementById("header");
const menu = document.querySelector(".menu");
const glossy = document.querySelector(".glossy");

window.addEventListener("scroll", function () {
    let currentScroll = window.scrollY || document.documentElement.scrollTop;
    if (currentScroll > lastScrollTop) {
        if (!header.classList.contains("header-hidden")) {
            header.classList.add("header-hidden");
            menu.style.top = "31%";
            header.style.backgroundColor = "rgba(0, 0, 0,0.75)";
            header.style.backdropFilter = "blur(60px)";
        }
    } else {
        if (currentScroll <= header.offsetHeight) {
            header.classList.remove("header-hidden");
            menu.style.top = "50%";
            header.style.backgroundColor = "rgba(0, 0, 0, 0)";
            header.style.backdropFilter = "none";
            glossy.style.backdropFilter = "blur(60px) saturate(100%)";
        }
    }
    lastScrollTop = currentScroll <= 0 ? 0 : currentScroll;
});