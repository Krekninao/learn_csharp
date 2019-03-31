var response = null;

function initController() {
    var bookShopModule = angular.module("bookShopApp", []);
    bookShopModule.controller("bookShopController", function ($scope, $http) {
        $scope.books = [];
        function loadData() {
            $http.get('http://localhost:8080/api/bookshop').
                then(function success(res) {
                    $scope.books = res.data;

                });
        }

        loadData();

        $scope.deleteBook = function (ID) {
            var url = 'http://localhost:8080/api/bookshop/' + ID;
            $http.delete(url).
                success(function (res) {
                    $scope.books = $scope.books.filter(book => book.productIdentificator !== ID);
                });

        };
        $scope.editBook = function (ID) {
            // var url = 'http://localhost:8080/api/bookshop/' + ID;
            // $http.get(url).
            //     then(function success (res) {
            //         console.log(res);
            //     });
            var book = $scope.books.filter(book => book.productIdentificator === ID)[0];
            $scope.ID = book.productIdentificator;
            $scope.name = book.name;
            $scope.author = book.author;
            $scope.rating = book.rating;
            $scope.price = book.price;


        };
        $scope.saveBook = function () {
            var book = {
                productIdentificator: $scope.ID,
                name: $scope.name,
                author: $scope.author,
                rating: $scope.rating,
                price: $scope.price
            };
            var url = 'http://localhost:8080/api/bookshop';
            $http.put(url, book).then(function success(res) {
                var book = $scope.books.filter(book => book.productIdentificator === $scope.ID)[0];
                book.name = $scope.name;
                book.author = $scope.author;
                book.rating = $scope.rating;
                book.price = $scope.price;

                $scope.ID = "";
                $scope.name = "";
                $scope.author = "";
                $scope.rating = "";
                $scope.price = "";
            })
        }

    });
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

