$(document).ready(function () {
    $(Window).scroll(function () {
        var trend3 = document.getElementById("caption");
        var trend4 = document.getElementById("caption1");
        var trend5 = document.getElementById("caption2");
        var trend6 = document.getElementById("caption3");
        var slider = document.getElementById("slider");
        if (window.pageYOffset > 280) {
            trend3.classList.add("box_caption");
        }
        if (window.pageYOffset > 350) {
            trend4.classList.add("box_caption");
        }
        if (window.pageYOffset > 400) {
            trend5.classList.add("box_caption");
        }
        if (window.pageYOffset > 480) {
            trend6.classList.add("box_caption");
        }
        if (window.pageYOffset > 3200) {
            slider.classList.add("slider_render");
        } else if (window.pageYOffset < 280) {
            trend3.classList.remove("box_caption");
        }
        if (window.pageYOffset < 350) {
            trend4.classList.remove("box_caption");
        }
        if (window.pageYOffset < 400) {
            trend5.classList.remove("box_caption");
        }
        if (window.pageYOffset < 480) {
            trend6.classList.remove("box_caption");
        }
    });
});
var index = 0;
var imgs = [
    "/images/slider1-aero3-1920x943.jpg",
    "/images/slider2-aero3-1920x943.jpg",
    "/images/slider3-aero3-1920x943.jpg",
];
prev = function () {
    if (index <= 0) index = imgs.length;
    index--;
    document.getElementById("img").src = imgs[index];
};
next = function () {
    if (index >= imgs.length - 1) {
        index = -1;
    }
    index++;
    document.getElementById("img").src = imgs[index];
};
var slide1 = document.getElementById("slide1");
var slide2 = document.getElementById("slide2");
index = 0;
slider_left = function () {
    if (index <= 0) {
        slide1.classList.remove("first");
        slide2.classList.add("first");
    }
};
slider_right = function () {
    slide1.classList.add("first");
};
var title = document.getElementById("title");
var title1 = document.getElementById("title1");
click = function () {
    title.classList.add("active");
    title1.classList.remove("active");
};
click1 = function () {
    title1.classList.add("active");
    title.classList.remove("active");
};