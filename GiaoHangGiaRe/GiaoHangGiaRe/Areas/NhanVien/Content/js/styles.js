var loadFile = function(event) {

    oldimg = $('.preview').attr('src');
    var preview = document.getElementById('preview');
    preview.src = URL.createObjectURL(event.target.files[0]);
    newimg = preview.src;
    if(newimg.indexOf('/null') > -1) {
        preview.src = oldimg;
    }
    
};

// var myFunction = function(event) {

//     $.get("http://localhost:8080/bds_project/public/getlo/"+$('#test').val()+"", function(data, status){
//         alert("Data: " + data[1].TenLo + "\nStatus: " + status);
//         for(var i = 0, l = options.length; i < l; i++){
// 		  var option = options[i];
// 		  selectBox.options.add( new Option(option.text, option.value, option.selected) );
// }
//     });
    
// };