var slideIndex = 1;
showSlides(slideIndex);

// Xử lý nút Next/Prev
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Xử lý khi click vào dot
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    // Ẩn toàn bộ các slide
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    // Deactive toàn bộ Dots
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    // Hiển thị ảnh slide current
    slides[slideIndex - 1].style.display = "block";
    // Đánh dấu active cho dot current
    dots[slideIndex - 1].className += " active";
}