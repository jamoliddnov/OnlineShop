const imgInput = document.querySelector("#image-input");
const imgInput2 = document.querySelector("#image-input2");
const imgInput3 = document.querySelector("#image-input3");

var uploadedImg = "";


imgInput.addEventListener("change", function () {
    const reader = new FileReader();
    reader.addEventListener("load", () => {
        uploadedImg = reader.result;
        document.querySelector("#display-img").style.backgroundImage = `url(${uploadedImg})`;
        document.querySelector("#addimg").style.display = 'none';
        document.querySelector("#image-input").style.display = 'none';
    });
    reader.readAsDataURL(this.files[0]);
});
imgInput2.addEventListener("change", function () {
    const reader = new FileReader();
    reader.addEventListener("load", () => {
        uploadedImg = reader.result;
        document.querySelector("#display-img2").style.backgroundImage = `url(${uploadedImg})`;
        document.querySelector("#addimg2").style.display = 'none';
        document.querySelector("#image-input2").style.display = 'none';
    });
    reader.readAsDataURL(this.files[0]);
});
imgInput3.addEventListener("change", function () {
    const reader = new FileReader();
    reader.addEventListener("load", () => {
        uploadedImg = reader.result;
        document.querySelector("#display-img3").style.backgroundImage = `url(${uploadedImg})`;
    }); document.querySelector("#addimg3").style.display = 'none';
    document.querySelector("#image-input3").style.display = 'none';
    reader.readAsDataURL(this.files[0]);
});