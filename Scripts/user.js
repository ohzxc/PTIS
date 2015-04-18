function displayhc() {

    document.getElementById("hcframe").style.display = "block";
    document.getElementById("xlframe").style.display = "none";
    document.getElementById("zdframe").style.display = "none";
    document.getElementById("divhc").style.fontWeight = "bold";
    document.getElementById("divxl").style.fontWeight = "normal";
    document.getElementById("divzd").style.fontWeight = "normal";
    document.cookie = "iframe=hccx";
}
function displayxl() {
    document.getElementById("hcframe").style.display = "none";
    document.getElementById("xlframe").style.display = "block";
    document.getElementById("zdframe").style.display = "none";
    document.getElementById("divhc").style.fontWeight = "normal";
    document.getElementById("divxl").style.fontWeight = "bold";
    document.getElementById("divzd").style.fontWeight = "normal";
    document.cookie = "iframe=xlcx";
}
function displayzd() {
    document.getElementById("hcframe").style.display = "none";
    document.getElementById("xlframe").style.display = "none";
    document.getElementById("zdframe").style.display = "block";
    document.getElementById("divhc").style.fontWeight = "normal";
    document.getElementById("divxl").style.fontWeight = "normal";
    document.getElementById("divzd").style.fontWeight = "bold";
    document.cookie = "iframe=zdcx";
}
