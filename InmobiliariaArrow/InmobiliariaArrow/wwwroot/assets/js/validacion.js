function estaLleno() {
    if(!validarPrecioYSuperficie())
        return false;
    let campos = new FormData(document.forms.formulario);
    for(let campo of campos.keys()){
        if(!campos.get(campo) || (campo === 'fotos' && campos.get(campo).size<=0)){
            alert('Todos los campos son obligatorios.');
            return false;
        }
    }
    return true;
}

function validarPrecioYSuperficie() {
    let precio = document.getElementById('preciocasa').value;
    let superficie = document.getElementById('terreno').value;
    if(isNaN(precio) || precio < 0 )
    {
        alert("El campo precio debe ser número positivo.");
        return false;
    }
    if (isNaN(superficie) || superficie < 0 )
    {
        alert(" El campo superficie debe ser número positivo.");
        return false;
    }
    return true;
}