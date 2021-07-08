function iniciarMap(){
    var coord = {lat:20.9688837 ,lng: -89.6634522};
    var map = new google.maps.Map(document.getElementById('mapa'),{
      zoom: 12,
      center: coord
    });
    var marker = new google.maps.Marker({
        map: map,
        draggable: true,
        position: coord,
        
    });

    marker.addListener('dragend',function(event){
        document.getElementById("latitud").value = this.getPosition().lat();
        document.getElementById("longitud").value = this.getPosition().lng();
    })
}