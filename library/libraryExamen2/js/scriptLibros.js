const body = document.getElementById('body');

librosFunction();

const table = (libro) => {

    for (i = 0; i < libro.length; i++) {
        htmlCode = '<tr>' +
            "<td>" + libro[i].bookTitulo + "</td>" +
            "<td>" + libro[i].authorNombre + "</td>" +
            "<td>" + libro[i].chapters + "</td>" +
            "<td>" + libro[i].pages + "</td>" +
            "<td> $ " + libro[i].price + "</td>" +
            "</tr>";
        body.insertAdjacentHTML("beforeend", htmlCode);
        htmlCode = "";
    }
};

//funcion fetch
function librosFunction() {
    fetch('http://localhost:5085/api/AuthorBook')
        .then(listLibro => listLibro.json())
        .then(listLibro => table(listLibro));
}