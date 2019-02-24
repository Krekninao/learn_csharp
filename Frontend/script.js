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

function addBook() {
    var bookName = document.getElementById("bookName").value;
    var author = document.getElementById("author").value;
    var rating = document.getElementById("rating").value;
    var price = document.getElementById("price").value;

    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'http://localhost:8080/api/bookshop', true);
    xhr.setRequestHeader('Content-type', 'application/json');

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            var list = document.getElementById("bookList");
            var text = "Название: " + bookName + "\nАвтор: " + author + "\nСтоимость: " + price + "\nРейтинг: " + rating;
            var li = document.createElement("li");
            li.innerText = text;
            list.appendChild(li);
            document.getElementById("bookName").value = "";
            document.getElementById("author").value = "";
            document.getElementById("rating").value = "";
            document.getElementById("price").value = "";

        };
    };

    var book = {
        name: bookName,
        author: author,
        rating: rating,
        price: price
    };
    var json = JSON.stringify(book);

    xhr.send(json);





}
function deleteBook() {
    var bookID = document.getElementById("ID").value;
    var xhr = new XMLHttpRequest();
    var url = 'http://localhost:8080/api/bookshop/' + bookID;

    xhr.open('DELETE', url, true);

    xhr.setRequestHeader('Content-type', 'application/json');

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            document.getElementById("bookList").innerHTML = "";
            getBooks();
        };
    };

    xhr.send();

}
