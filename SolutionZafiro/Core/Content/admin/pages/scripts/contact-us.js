var ContactUs = function () {

    return {
        init: function () {
			var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#map',
				lat: -6.9383381,
				lng: 107.6129994
			  });
			   var marker = map.addMarker({
		         lat: -6.9383381,
					   lng: 107.6129994,
		            title: 'Nibble Themes.',
		            infoWindow: {
		                content: "<b>Nibble Themes.</b> Lantai Wisma Monex, Jl. Asia Afrika No.9<br>Kota Bandung, Indonesia 40112"
		            }
		        });

			   marker.infoWindow.open(map, marker);
			});
        }
    };

}();