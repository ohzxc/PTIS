function displayhc() {
    var gethc = document.getElementById("hcframe");
    var getxl = document.getElementById("xlframe");
    var getzd = document.getElementById("zdframe");
    gethc.style.display = "block";
    getxl.style.display = "none";
    getzd.style.display = "none";
}
function displayxl() {
    document.getElementById("hcframe").style.display = "none";
    document.getElementById("xlframe").style.display = "block";
    document.getElementById("zdframe").style.display = "none";
}
function displayzd() {
    var gethc = document.getElementById("hcframe");
    var getxl = document.getElementById("xlframe");
    var getzd = document.getElementById("zdframe");
    gethc.style.display = "none";
    getxl.style.display = "none";
    getzd.style.display = "block";
}
/*function btnExchange_Click() {
    var tmp = document.getElementById("textqd").value;
    document.getElementById("textqd").value = document.getElementById("textzd").value;
    document.getElementById("textzd").value = tmp;   
}*/