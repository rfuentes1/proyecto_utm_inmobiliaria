function estaLleno() {
    let campos = new FormData(document.forms.formulario);
    for(let campo of campos.keys()){
        if(!campos.get(campo) || (campo === 'fotos' && campos.get(campo).size<=0)){
            alert('Todos los campos son obligatorios.');
            return false;
        }
    }
    return true;
}

