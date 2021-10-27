function estaLleno() {
    let campos = new FormData(document.forms.loginForm);
    for(let campo of campos.keys()){
        if(!campos.get(campo)){
            alert('El usuario y password son obligatorios.');
            return false;
        }
    }
    return true;
}

