function leerimagen(input) {
    if (input.files && input.files[0]) {
        var lector = new FileReader();

        lector.onload = function (e) {
            var previsualizacion = document.createElement('img');
            previsualizacion.id = 'img_prev';
            /*e.target.result contiene los datos base de la imagen cargada*/
            previsualizacion.src = e.target.result;
            console.log(e.target.result);

            var vista = document.getElementById('vista_previa');
            vista.appendChild(previsualizacion);
        }

        lector.readAsDataURL(input.files[0]);
    }
}

var subir_img = document.getElementById('subir_img');
subir_img.onchange = function (e) {
    leerimagen(e.srcElement);
}