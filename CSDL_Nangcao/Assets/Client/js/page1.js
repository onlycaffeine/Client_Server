var subjectObject = {
    "Thành phố Hà Nội": {
        "Quận Hà Đông": ["Phường Hà Cầu", "Phường Yên Nghĩa", "Phường La Khê"],
        "Quận Cầu Giấy": ["Phường Trung Hòa", "Phường Dịch Vọng", "Phường Nghĩa Tân"],
        "Quận Nam Từ Liêm": ["Phường Mỹ Đình 1", "Phường Cầu Diễn", "Phường Mễ Trì", "Phường Trung Văn", "Phường Đại Mỗ"]
    },
    "Thành phố Hồ Chí Minh": {
        "Quận Thủ Đức": ["Phường Bình Chiểu", "Phường Tam Bình", "Phường Linh Đông"],
        "Quận 1": ["Phường Đa Kao", "Phường Bến Thành", "Phường Tân Định"]
    },
    "Tỉnh Bắc Ninh": {
        "Huyện Thuận Thành": ["Xã An Bình", "Xã Xuân Lâm"],
        "Huyện Quế Võ": ["Xã Nhân Hòa", "Xã Phù Lương"]
    }
}

window.onload = function () {
    var subjectSel = document.getElementById("subject");
    var topicSel = document.getElementById("topic");
    var chapterSel = document.getElementById("searchString");
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