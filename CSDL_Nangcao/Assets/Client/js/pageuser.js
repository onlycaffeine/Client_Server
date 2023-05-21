var subjectObject = {
    "Thành phố Hà Nội": {
        "Quận Hà Đông": ["Phường Quang Trung", "Phường Hà Cầu", "Phường Yên Nghĩa", "Phường La Khê"],
        "Quận Nam Từ Liêm": ["Phường Mỹ Đình 1", "Phường Cầu Diễn", "Phường Mễ Trì", "Phường Trung Văn", "Phường Đại Mỗ"],
        "Quận Cầu Giấy": ["Phường Trung Hòa", "Phường Quan Hoa", "Phường Dịch Vọng", "Phường Nghĩa Tân"]
    },
    "Thành phố Hồ Chí Minh": {
        "Quận Thủ Đức": ["Phường Bình Chiểu", "Phường Bình Chánh", "Phường Hiệp Bình Phước"],
        "Quận 1": ["Phường Bến Nghé", "Phường Bến Thành", "Phường Tân Định"]
    }
}

window.onload = function () {
    var subjectSel = document.getElementById("tp");
    var topicSel = document.getElementById("q");
    var chapterSel = document.getElementById("p");
    for (var x in subjectObject) {
        subjectSel.options[subjectSel.options.length] = new Option(x, x);
    }
    subjectSel.onchange = function () {
        //empty Chapters- and Topics- dropdowns
        chapterSel.length = 1;
        topicSel.length = 1;
        //display correct values
        for (var y in subjectObject[this.value]) {
            topicSel.options[topicSel.options.length] = new Option(y, y);
        }
    }
    topicSel.onchange = function () {
        //empty Chapters dropdown
        chapterSel.length = 1;
        //display correct values
        var z = subjectObject[subjectSel.value][this.value];
        for (var i = 0; i < z.length; i++) {
            chapterSel.options[chapterSel.options.length] = new Option(z[i], z[i]);
        }
    }
}