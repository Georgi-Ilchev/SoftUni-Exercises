//33 points at Judge
function toggle() {
    let buttn = document.getElementsByClassName("button")[0]
    let info = document.getElementById("extra");

    if (buttn.textContent == "More") {
        info.style.display = `block`;
        buttn.textContent = `Less`;
    } else if (buttn.textContent == "Less") {
        info.style.display = `none`;
        buttn.textContent = `Мore`;
    }
}

//100 points at Judge
function toggle() {
    let buttn = document.getElementsByClassName("button")[0]
    let info = document.getElementById("extra")

    info.style.display = info.style.display == "none" ? "block" : "none"

    buttn.textContent = buttn.textContent == "Less" ? "More" : "Less"
}