function testFunction() {
    alert('Hello world');
}

function getBooks() {
    // 1. Создаём новый объект XMLHttpRequest
    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'http://localhost:8080/api/bookshop', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);

            var list = document.getElementById("bookList");
            response.forEach(book => {
                var text = "Название: " + book.name + "\nАвтор: " + book.author + "\nСтоимость: " + book.price + "\nРейтинг: " + book.rating;
                var li = document.createElement("li");
                li.innerText = text;
                list.appendChild(li);
            });
        };
    };

    xhr.send();
}